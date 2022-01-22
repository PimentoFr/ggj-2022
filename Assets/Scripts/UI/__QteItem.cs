using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
public enum Keys
{
    LEFT = 0,
    RIGHT = 1,
    UP = 2,
    DOWN = 3
}

public class QteItem : MonoBehaviour
{

    public string PartName { get; set; }
    List<Keys> keys = new List<Keys>();
    int current_keys_index = 0;
    
    public void reroll(int nb_keys)
    {
        Random rnd = new Random();
        keys.Clear();
        for (int i = 0; i < nb_keys; i++)
        {
            keys.Add((Keys) Random.Range(0, 4));
        }
    }

    public override string ToString()
    {
        return "Action: " + Action + ",keys: " + keys.ToString();
    }

    public void getKeys()
    {
        return keys;
    }

    public bool actionIsFinished()
    {
        return current_keys_index >= keys.Count;
    }

    public bool keyTypedIsGood(Keys key_pressed)
    {
        if(current_keys_index >= keys.Count)
        {
            return true;
        }

        if(key_pressed == keys[current_keys_index])
        {
            // Key is good
            current_keys_index++;
            return true;
        } else
        {
            // Key is wrong
            current_keys_index = 0;
            return false;
        }
    }
}
*/
