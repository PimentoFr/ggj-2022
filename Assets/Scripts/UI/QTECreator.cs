using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTEItem
{
    public string action_label { get; set; }
    public List<string> keys_type { get; set; }

    public QTEItem(string _action_label, List<string> _keys_type)
    {
        action_label = _action_label;
        keys_type = _keys_type;
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
    public AudioClip failedSound;
    public AudioClip validSound;
    public AudioClip swipeSound;
    AudioSource audioSource;

    RectTransform rect;
    GameObject box;
    Transform boxTrans;

    void Awake()
    {
        rect = GetComponent<RectTransform>();
        box = transform.Find("Box").gameObject;
        boxTrans = box.GetComponent<Transform>();
        audioSource = GetComponent<AudioSource>();

        SetHardcoreMode(false);
    }


    static List<string> GenerateKeys(int number)
    {
        string[] listKeys = { "UP", "DOWN", "RIGHT", "LEFT" };
        List<string> list = new List<string>();
        for(int i = 0; i < number; i++)
        {
            list.Add(listKeys[Random.Range(0, 4)]);
        }
        return list;
    }

    public static void LaunchQTE(GameObject player, TaskType task_type, bool outOfService, GameObject prefabUI)
    {
        Debug.Log("LaunchQTE " + task_type);

        QTEMission mission = QTEMissions.missions[task_type];

        GameObject qte =  Instantiate(prefabUI, new Vector3(0, 0, 0), Quaternion.identity);

        
        int nbKeys = mission.difficulties;

        QTEItem[] items = mission.GetQTEItems(outOfService);
        List<QTEItem> list = new List<QTEItem>();
        foreach(var item in items)
        {
            List<string> keys = GenerateKeys(nbKeys);
            list.Add(new QTEItem(item.action_label, keys));
        }

        qte.GetComponent<QTECreator>().CreateItems(list);
        qte.GetComponent<QTECreator>().SetHardcoreMode(false);
        qte.GetComponent<QTECreator>().CleanKeyList(false);

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

        if (ButtonIsPressed(QteKeyboardKey.DOWN))
        {
            EventKeyTrigger(KeyUISprite.DOWN);
        }
        else if (ButtonIsPressed(QteKeyboardKey.UP))
        {
            EventKeyTrigger(KeyUISprite.UP);
        }
        else if (ButtonIsPressed(QteKeyboardKey.LEFT))
        {
            EventKeyTrigger(KeyUISprite.LEFT);
        }
        else if (ButtonIsPressed(QteKeyboardKey.RIGHT))
        {
            EventKeyTrigger(KeyUISprite.RIGHT);
        }
        else if (ButtonIsPressed(QteKeyboardKey.LEAVE))
        {
            Leave();
            /* Do maybe something more to continue game */
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

    void EventKeyTrigger(KeyUISprite key_type)
    {
        QteItemUI qteItemUi = qteItemUiList[current_item_index];
        bool res = qteItemUi.PropageKeyboardEvent(key_type);
        if(res == false)
        {
            /* The key is wrong ... reset */
            playSound(failedSound);
            AskCleanKeyList();
            return;
        } 
        if(qteItemUi.GetKeysObj().GetComponent<KeysListUI>().KeysListIsComplete())
        {
            playSound(validSound);
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
        SlideUp();
    }
    void Leave()
    {
        Debug.Log("Leave QTE");
        SlideUp();
    }

    void SlideUp()
    {
        askSlideUp = true;
        startAskSlideUp = Time.realtimeSinceStartup;
        originPosition = boxTrans.position;
        playSound(swipeSound);
    }

    void playSound(AudioClip sound)
    {
        audioSource.PlayOneShot(sound);
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
