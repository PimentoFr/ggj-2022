using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeysListUI : MonoBehaviour
{
    public GameObject prefab_key;
    public List<KeyUI> keys_ui = new List<KeyUI>();
    int current_key_index = 0;

    public KeyUI SpawnKey(int index)
    {
        // new Vector3(transform.position.x + (prefab_key.transform.width + 5) * index, transform.position.y, transform.position.z)
        Vector3 positionKey = new Vector3(88 * index, 0, 0);
        KeyUI key_ui = Instantiate(prefab_key, new Vector3(0,0,0), Quaternion.identity).GetComponent<KeyUI>();
        key_ui.transform.parent = transform;
        key_ui.transform.localPosition = positionKey;
        keys_ui.Add(key_ui);
        return key_ui;
    }

    public List<KeyUI> GetKeyUIList()
    {
        return keys_ui;
    }


    public bool TriggerKeyboardEvent(KeyUISprite key_type)
    {
        if(current_key_index >= keys_ui.Count)
        {
            return true;
        }

        KeyUI key = keys_ui[current_key_index];
        bool result = key.IsCorrectKeyPressed(key_type);
        if(result)
        {
            key.Valid();
            current_key_index++;
        } else
        {
            key.Error();
            current_key_index = 0;
        }
        return result;
    }

    /* Check if all keys asked are received and valid */
    public bool KeysListIsComplete()
    {
        return current_key_index >= keys_ui.Count;
    }

    public void cleanKeys()
    {
        foreach(KeyUI key_ui in keys_ui)
        {
            key_ui.ClearColor();
        }
    }
}
