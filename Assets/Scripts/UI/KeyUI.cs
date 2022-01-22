using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum KeyUISprite : ushort {
    UP = 0,
    RIGHT = 1,
    DOWN = 2,
    LEFT = 3
}

public class KeyUI : MonoBehaviour
{


    public string key_label = "";
    public Sprite[] icon_array;
    public int index_icon = -1;
    Text text;
    Image icon;
    Image key;
    // Start is called before the first frame update
    void Awake()
    {

        text = transform.Find("text").gameObject.GetComponent<Text>();
        icon = transform.Find("img").gameObject.GetComponent<Image>();
        key = GetComponent<Image>();
        text.gameObject.SetActive(false);
        icon.gameObject.SetActive(false);
        Debug.Log("Test start");
        Debug.Log(text);

        if(key_label.Length > 0)
        {
            SetKeyText(key_label);
        }

        if(index_icon != -1)
        {
            SetIconIndex(index_icon);
        }
    }

    public void SetKeyText(string str)
    {
        Debug.Log("str" + str);
        Debug.Log(text);
        text.text = str;
        text.gameObject.SetActive(true);
    }

    public void SetIconIndex(int index)
    {
        index_icon = index;
        icon.sprite = icon_array[index];
        icon.gameObject.SetActive(true);
    }

    public void SetIconIndex(KeyUISprite index)
    {
        SetIconIndex((int)index);
    }

    public void ClearColor()
    {
        key.color = new Color(1.0f, 1.0f, 1.0f);
    }

    public void Valid()
    {
        key.color = new Color(0.5f, 0.8f, 0.2f);
    }

    public void Error()
    {
        key.color = new Color(0.8f, 0.1f, 0.1f);
    }

    public bool IsCorrectKeyPressed(KeyUISprite key_type)
    {
        return ((int) key_type == index_icon);
    }
}
