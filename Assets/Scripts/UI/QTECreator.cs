using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class QTEItem
{
    public string action_label { get; set; }
    public List<string> keys_type { get; set; }
    public AudioClip clip;

    public QTEItem(string _action_label, List<string> _keys_type, AudioClip _clip)
    {
        action_label = _action_label;
        keys_type = _keys_type;
        clip = _clip;
    }
}

public enum QteKeyboardKey {
    UP = 0,
    RIGHT = 1,
    DOWN = 2,
    LEFT = 3,
    LEAVE = 4
}

public class QTECreator : MonoBehaviour
{
    public GameObject prefabQteItem;
    List<QteItemUI> qteItemUiList = new List<QteItemUI>();
    public KeyCode leftKey;
    public KeyCode rightKey;
    public KeyCode upKey;
    public KeyCode downKey;
    public KeyCode leaveKey;

    public AudioClip swipeUpAudioClip;
    public AudioClip errorAudioClip;
    public float delayClean = 0.4F;

    int current_item_index = 0;

    bool askClean = false;
    float startAskClean;

    /* For Slide Up animation */
    public float slideUpDurationInS = 1.0f;
    public float slideUpDistance = 3000.0f;
    bool askSlideUp;
    float startAskSlideUp;
    Vector3 originPosition;

    /* Sound*/
    AudioSource audioSource;

    GameObject box;
    Transform boxTrans;

    GameObject pauseGameObject;


    public TaskInteractible caller_callback;
    void Awake()
    {
        box = transform.Find("Box").gameObject;
        boxTrans = box.GetComponent<Transform>();
        audioSource = GetComponent<AudioSource>();
        pauseGameObject = GameObject.FindWithTag("BG_music");
        SetHardcoreMode(false);
    }


    static List<string> GenerateKeys(int number)
    {

        List<string> listKeys = KeysList.GetKeys();
        List<string> list = new List<string>();
        for(int i = 0; i < number; i++)
        {
            list.Add(listKeys[Random.Range(0, listKeys.Count)]);
        }
        return list;
    }

    public void SetCallerCallback(TaskInteractible caller) {
        caller_callback = caller;
    }

    public static QTECreator LaunchQTE2(GameObject UI_QTE,List<string> listActions, List<AudioClip> listAudioClip, int nbKeys, Color backgroundColor, string stressDescription, TaskInteractible caller_callback)
    {
        GameObject qte =  Instantiate(UI_QTE, new Vector3(0, 0, 0), Quaternion.identity);

        List<QTEItem> list = new List<QTEItem>();
        for(int i = 0; i < listActions.Count; i++) {
            List<string> keys = GenerateKeys(nbKeys);
            list.Add(new QTEItem(listActions[i], keys, listAudioClip[i]));
        }

        //Set color of the background
        GameObject go = qte.transform.Find("Box").Find("background").gameObject;
        go.GetComponent<Image>().color = backgroundColor;
        //Set stress text
        qte.transform.Find("Box").Find("StressDescription").gameObject.GetComponent<TextMeshProUGUI>().text = stressDescription;

        QTECreator qteCreator = qte.GetComponent<QTECreator>();

        qteCreator.SetCallerCallback(caller_callback);
        qteCreator.CreateItems(list);
        qteCreator.SetHardcoreMode(false);
        qteCreator.CleanKeyList(false);

        return qteCreator;
    }

    KeyCode GetButtonPressed() {
        KeyCode keyPressed = KeyCode.None;
        foreach(var keycode in KeysList.GetValues()) {
            if(Input.GetKeyDown(keycode)) {
                keyPressed = keycode;
                break;
            }
        }
        return keyPressed;
    }
    bool ButtonIsPressed(QteKeyboardKey key)
    {
       switch(key)
       {
            case QteKeyboardKey.DOWN:
                return Input.GetKeyDown(downKey);
            case QteKeyboardKey.UP:
                return Input.GetKeyDown(upKey);
            case QteKeyboardKey.RIGHT:
                return Input.GetKeyDown(rightKey);
            case QteKeyboardKey.LEFT:
                return Input.GetKeyDown(leftKey);
            case QteKeyboardKey.LEAVE:
                return Input.GetKeyDown(leaveKey);
            default:
                Debug.Log("Bad state " + key);
                return false;
       }
    }

    void Update()
    {
        if(askClean)
        {
            if((Time.realtimeSinceStartup - startAskClean) >= delayClean)
            {
                CleanKeyList(true);
            }
            return;
        }
        if(askSlideUp)
        {
            float deltaT = (Time.realtimeSinceStartup - startAskSlideUp);
            if (deltaT >= slideUpDurationInS)
            {
                askSlideUp = false;
                Destroy(gameObject);
                return;
            }

            Vector3 editedPosition = boxTrans.position;
            float t = deltaT / slideUpDurationInS;
            float sqt = t * t;
            float bezierFactor = sqt / (2.0f * (sqt - t) + 1.0f);

            editedPosition.y = originPosition.y + slideUpDistance * bezierFactor;//Mathf.Sin(0.5f * Mathf.PI * (deltaT / slideUpDurationInS));
            boxTrans.position = editedPosition;
        }

        // Check if the game is paused
        if(!pauseGameObject.GetComponent<Pause>().getPaused()){
            KeyCode kc = GetButtonPressed();
            if(kc != KeyCode.None)
            {
                EventKeyTrigger(kc);
            }
            else if (ButtonIsPressed(QteKeyboardKey.LEAVE))
            {
                Leave();
                /* Do maybe something more to continue game */
            }
        }

    }

    public void CreateItems(List<QTEItem> qteitems)
    {
        int i = 0;
        foreach(QTEItem qteitem in qteitems) {
            Vector3 positionItemUi = new Vector3(0, 100 -i * 40, 0);
            QteItemUI qteItemUi = Instantiate(prefabQteItem, new Vector3(0, 0, 0), Quaternion.identity).GetComponent<QteItemUI>();
            qteItemUi.transform.SetParent(box.transform);
            qteItemUi.transform.localPosition = positionItemUi;
            qteItemUi.SetActionLabel(qteitem.action_label);
            qteItemUi.GenerateKeys(qteitem.keys_type);
            qteItemUi.clip = qteitem.clip;
            qteItemUiList.Add(qteItemUi);
            i++;
        }

        /* Show the first key list */
        qteItemUiList[0].GetKeysObj().GetComponent<KeysListUI>().show();
    }

    void CleanKeyList(bool withReroll)
    {
        KeysListUI keyListUi = qteItemUiList[current_item_index].GetKeysObj().GetComponent<KeysListUI>();
        /* Reroll keys */
        if(withReroll)
        {
            keyListUi.reroll();
        }
        /* Remove colors */
        keyListUi.cleanKeys();
        askClean = false;
    }

    void AskCleanKeyList()
    {
        askClean = true;
        startAskClean = Time.realtimeSinceStartup;
        qteItemUiList[current_item_index].GetKeysObj().GetComponent<KeysListUI>().Shake();
    }

    void EventKeyTrigger(KeyCode key)
    {
        QteItemUI qteItemUi = qteItemUiList[current_item_index];
        bool res = qteItemUi.PropageKeyboardEvent(key);
        if(res == false)
        {
            /* The key is wrong ... reset */
            playSound(errorAudioClip);
            AskCleanKeyList();
            return;
        } 
        if(qteItemUi.GetKeysObj().GetComponent<KeysListUI>().KeysListIsComplete())
        {

            playSound(qteItemUi.clip);
            
            /* Hide success key list */
            qteItemUiList[current_item_index].GetKeysObj().GetComponent<KeysListUI>().hide();
            /* Go to next item list */
            current_item_index++;
            if(current_item_index >= qteItemUiList.Count)
            {
                /* All finished */
                Success();
                return;
            }

            /* Show new key list */
            qteItemUiList[current_item_index].GetKeysObj().GetComponent<KeysListUI>().show();
        }
    }

    void Success()
    {
        Debug.Log("All QTE finished and correct");
        //TODO: call callack success
        caller_callback.OnQuitQTE(true);
        SlideUp();
    }
    void Leave()
    {
        Debug.Log("Leave QTE");
        caller_callback.OnQuitQTE(false);
        playSound(swipeUpAudioClip);
        SlideUp();
    }

    void SlideUp()
    {
        askSlideUp = true;
        startAskSlideUp = Time.realtimeSinceStartup;
        originPosition = boxTrans.position;
    }

    void playSound(AudioClip sound)
    {
        if(sound != null) {
            audioSource.volume = GameObject.FindGameObjectWithTag("BG_music").GetComponent<BG_music>().GetEffectVolume();
            audioSource.PlayOneShot(sound);
        }
    }

    void SetHardcoreMode(bool hardcore)
    {
        foreach(QteItemUI qteItemUi in qteItemUiList)
        {
            foreach(KeyUI key_ui in qteItemUi.GetKeysObj().GetComponent<KeysListUI>().GetKeyUIList())
            {
                key_ui.SetHardcoreMode(hardcore);
            }
        }
    }
}
