using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QteItemUI : MonoBehaviour
{

    public string action_label = "";
    private Text action_text;
    private GameObject keys_obj;
    // Start is called before the first frame update
    void Start()
    {
        action_text = transform.Find("action").GetComponent<Text>();
        keys_obj = transform.Find("keys").gameObject;
        action_text.text = action_label;

        Test();
    }

    void SetActionLabel(string action_label)
    {
        action_text.text = action_label;
    }

    void Test()
    {
        //keys_obj.transform.Find("Key").GetComponent<KeyUI>().SetKeyText("A");
        GenerateKeys();
    }

    void GenerateKeys()
    {
        string test = "ABC";
        for (int i = 0; i < 3; i++)
        {
            KeyUI key_ui = keys_obj.GetComponent<KeysListUI>().SpawnKey(i);
            //key_ui.SetKeyText(test[i].ToString());
            key_ui.SetIconIndex(i);
        }
    }
}
