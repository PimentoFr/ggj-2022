using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QteItemUI : MonoBehaviour
{

    public string action_label = "";
    private Text action_text;
    private GameObject keys_obj;
    public AudioType clip {get; set;}

    void Awake()
    {
        action_text = transform.Find("action").GetComponent<Text>();
        keys_obj = transform.Find("keys").gameObject;
        action_text.text = action_label;
    }

    public void SetActionLabel(string action_label)
    {
        action_text.text = action_label;
    }

    public void GenerateKeys(List<string> keys_type)
    {
        int i = 0;
        foreach(string key_type in keys_type)
        {
            KeyUI key_ui = keys_obj.GetComponent<KeysListUI>().SpawnKey(i);
            KeyUISprite key_ui_sprite = KeyUISprite.UP;
            if (key_type.Length == 1)
            {
                key_ui.SetKeyText(key_type);
            } 
            else
            {

                switch (key_type)
                {
                    case "UP":
                        key_ui_sprite = KeyUISprite.UP;
                        break;
                    case "DOWN":
                        key_ui_sprite = KeyUISprite.DOWN;
                        break;
                    case "LEFT":
                        key_ui_sprite = KeyUISprite.LEFT;
                        break;
                    case "RIGHT":
                        key_ui_sprite = KeyUISprite.RIGHT;
                        break;
                    default:
                        Debug.Log("Bad key " + key_type);
                        break;
                }
                key_ui.SetIconIndex(key_ui_sprite);
            }
            i++;
        }
        keys_obj.GetComponent<KeysListUI>().hide();
    }

    public GameObject GetKeysObj()
    {
        return keys_obj;
    }

    /* Propagate keyboard event to Key list */
    public bool PropageKeyboardEvent(KeyUISprite key_type)
    {
        return keys_obj.GetComponent<KeysListUI>().TriggerKeyboardEvent(key_type);
    }
}
