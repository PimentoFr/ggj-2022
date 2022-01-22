using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeysListUI : MonoBehaviour
{
    public GameObject prefab_key;
    public List<KeyUI> keys_ui = new List<KeyUI>();
    int current_key_index = 0;

    public float shakeDurationInS = 1.0f;
    public float shakeMaxAmplitude = 20.0f;
    public int shakeBounceNumber = 4;
    bool shakeAsked = false;
    float startShakeAsked;
    Vector3 originPosition;

    void Update()
    {
        if(shakeAsked)
        {
            if((Time.realtimeSinceStartup - startShakeAsked) >= shakeDurationInS) {
                transform.position = originPosition;
                shakeAsked = false;
            }
            else
            {
                Vector3 editedPosition = transform.position;
                float deltaT = Time.realtimeSinceStartup - startShakeAsked;
                editedPosition.x = originPosition.x + shakeMaxAmplitude * Mathf.Cos(2 * Mathf.PI * deltaT / (shakeDurationInS / shakeBounceNumber)) * (1 - (deltaT / shakeDurationInS));
                transform.position = editedPosition;
            }            
        }
    }

    public KeyUI SpawnKey(int index)
    {
        // new Vector3(transform.position.x + (prefab_key.transform.width + 5) * index, transform.position.y, transform.position.z)
        Vector3 positionKey = new Vector3(88 * index, 0, 0);
        KeyUI key_ui = Instantiate(prefab_key, new Vector3(0,0,0), Quaternion.identity).GetComponent<KeyUI>();
        key_ui.transform.SetParent(transform);
        key_ui.transform.localPosition = positionKey;
        keys_ui.Add(key_ui);
        return key_ui;
    }

    public void reroll()
    {
        foreach(KeyUI key_ui in keys_ui)
        {
            key_ui.reroll();
        }
    }

    public List<KeyUI> GetKeyUIList()
    {
        return keys_ui;
    }

    public void Shake()
    {
        if(shakeAsked)
        {
            return;
        }
        shakeAsked = true;
        startShakeAsked = Time.realtimeSinceStartup;
        originPosition = transform.position;
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
            key_ui.Clear();
        }
    }

    public void hide()
    {
        gameObject.SetActive(false);
    }

    public void show()
    {
        gameObject.SetActive(true);
    }
}
