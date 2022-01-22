using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeysListUI : MonoBehaviour
{
    public GameObject prefab_key;
    public List<KeyUI> keys_ui = new List<KeyUI>();


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
}
