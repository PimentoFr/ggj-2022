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

    void Start()
    {
        CreateItems(new List<QTEItem>
        {
            new QTEItem("Remplir du papier", new List<string>{"UP", "DOWN", "LEFT", "UP"}),
            new QTEItem("Lancer photocopie", new List<string>{"RIGHT", "DOWN", "LEFT", "RIGHT"}),
            new QTEItem("Recuperer impression", new List<string>{"UP", "UP", "LEFT", "DOWN"}),
        });
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
                CleanKeyList();
            }
            return;
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
            qteItemUi.transform.parent = transform;
            qteItemUi.transform.localPosition = positionItemUi;
            qteItemUi.SetActionLabel(qteitem.action_label);
            qteItemUi.GenerateKeys(qteitem.keys_type);
            qteItemUiList.Add(qteItemUi);
            i++;
        }

        /* Show the first key list */
        qteItemUiList[0].getKeysObj().GetComponent<KeysListUI>().show();
    }

    void CleanKeyList()
    {
        qteItemUiList[current_item_index].getKeysObj().GetComponent<KeysListUI>().cleanKeys();
        askClean = false;
    }

    void AskCleanKeyList()
    {
        askClean = true;
        startAskClean = Time.realtimeSinceStartup;
    }

    void EventKeyTrigger(KeyUISprite key_type)
    {
        Debug.Log("Key_type pressed :" + key_type);
        QteItemUI qteItemUi = qteItemUiList[current_item_index];
        bool res = qteItemUi.PropageKeyboardEvent(key_type);
        if(res == false)
        {
            /* The key is wrong ... reset */
            AskCleanKeyList();
            return;
        } 
        if(qteItemUi.getKeysObj().GetComponent<KeysListUI>().KeysListIsComplete())
        {
            /* Hide success key list */
            qteItemUiList[current_item_index].getKeysObj().GetComponent<KeysListUI>().hide();
            /* Go to next item list */
            current_item_index++;
            if(current_item_index >= qteItemUiList.Count)
            {
                /* All finished */
                Success();
                return;
            }

            /* Show new key list */
            qteItemUiList[current_item_index].getKeysObj().GetComponent<KeysListUI>().show();
        }
    }

    void Success()
    {
        Debug.Log("All QTE finished and correct");
        //TODO: call callack success
        Destroy(gameObject);
    }
    void Leave()
    {
        Debug.Log("Leave QTE");
        //TODO: call callback failed
        Destroy(gameObject);
    }
}
