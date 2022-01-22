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

    const float DELAY_CLEAN_S = 1.0f;
    public string key_label = "";
    public Sprite[] icon_array;
    public int index_icon = -1;
    Text text;
    Image icon;
    Image key;

    bool isHardcoreMode = false;

    Vector3 originPosition;
    RectTransform rectTrans;
    // Start is called before the first frame update
    void Awake()
    {

        text = transform.Find("text").gameObject.GetComponent<Text>();
        icon = transform.Find("img").gameObject.GetComponent<Image>();
        key = GetComponent<Image>();
        rectTrans = GetComponent<RectTransform>();
        text.gameObject.SetActive(false);
        icon.gameObject.SetActive(false);

        if(key_label.Length > 0)
        {
            SetKeyText(key_label);
        }

        if(index_icon != -1)
        {
            SetIconIndex(index_icon);
        }
    }

    void Update()
    {
    }

    public void SetKeyText(string str)
    {
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

    public void Clear()
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

    public void reroll()
    {
        SetIconIndex(Random.Range(0, 4));
    }

    public void SetHardcoreMode(bool hardcoreMode)
    {
        isHardcoreMode = hardcoreMode;
    }

    public void ShowArrow()
    {
        if (!isHardcoreMode)
        {
            return;
        }
        icon.gameObject.SetActive(true);
    }

    public void HideArrow()
    {
        if(!isHardcoreMode)
        {
            return;
        }
        icon.gameObject.SetActive(false);
    }
    
}
