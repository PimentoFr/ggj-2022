using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class KeysList
{
    public static Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>()
    {
        {"A", KeyCode.A },
        {"B", KeyCode.B },
        {"C", KeyCode.C },
        {"D", KeyCode.D },
        {"E", KeyCode.E },
        {"F", KeyCode.F },
        {"G", KeyCode.G },
        {"H", KeyCode.H },
        {"I", KeyCode.I },
        {"J", KeyCode.J },
        {"K", KeyCode.K },
        {"L", KeyCode.L },
        {"M", KeyCode.M },
        {"N", KeyCode.N },
        {"O", KeyCode.O },
        //{"P", KeyCode.P }, // USED FOR PAUSE
        {"Q", KeyCode.Q },
        {"R", KeyCode.R },
        {"S", KeyCode.S },
        {"T", KeyCode.T },
        {"U", KeyCode.U },
        {"V", KeyCode.V },
        {"X", KeyCode.X },
        {"Y", KeyCode.Y },
        {"Z", KeyCode.Z },
    };

    public static List<string> GetKeys() {
        return new List<string>(KeysList.keys.Keys);
    }

    public static List<KeyCode> GetValues() {
        return new List<KeyCode>(KeysList.keys.Values);
    }

    public static string GetRandom() {
        List<string> k = KeysList.GetKeys();
        return k[Random.Range(0, k.Count)];
    }
}