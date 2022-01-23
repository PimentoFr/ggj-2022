using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum TrickType
{
    MUG_METHYLEN = 0,
    ASS_COPY = 1,
    PLANT_SMASH = 2,
    FART_PILLOW = 3,

    NULL = 999
}


public class TrickMission
{
    public string action;
    public float stressBonus;
    public float stressDetected;
    public bool isCriticalMission;
    public float durationInS;
    public AudioClip playSound;

    public TrickMission(string _action, float _stressSuccess, float _stressDetected, bool _isCriticalMission, float _durationInS, AudioClip _playsound)
    {
        action = _action;
        stressBonus = _stressSuccess;
        stressDetected = _stressDetected;
        isCriticalMission = _isCriticalMission;
        durationInS = _durationInS;
        playSound = _playsound;
    }
}

public static class TrickMissions
{
    public static Dictionary<TrickType, TrickMission> missions = new Dictionary<TrickType, TrickMission>() {
        {TrickType.MUG_METHYLEN,       new TrickMission(
            "Bleu de méthylène", -20, 20, false, 5, null
        )},
        { TrickType.ASS_COPY,       new TrickMission(
            "Scanner son cul", -30, 80, true, 10, null
        )},
        { TrickType.PLANT_SMASH,       new TrickMission(
            "Renverser la plante", -30, 80, true, 10, null
        )},
        { TrickType.FART_PILLOW,       new TrickMission(
            "Coussin péteur", -30, 80, true, 10, null
        )},
    };
}

