using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum TrickType
{
    ASS_COPY = 0,
    PLANT_STRIKE = 1,
    RUN_YOUTUBE = 2,
    THROW_FILL = 3,
    PRANK_PHONE = 4,
    POISON_MUG = 5,
    THROW_PENS = 6,
    PLAY_WITH_CLIP = 7,
    PAPER_PLANE = 87,
    TAG = 9,
    FART_PILLOW = 10,
    DRAW_PAPERBOARD = 11,



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
        {TrickType.POISON_MUG,       new TrickMission(
            "Bleu de m�thyl�ne", -20, 20, false, 5, null
        )},
        { TrickType.ASS_COPY,       new TrickMission(
            "Scanner son cul", -30, 80, true, 10, null
        )},
        { TrickType.PLANT_STRIKE,       new TrickMission(
            "Renverser la plante", -30, 80, true, 10, null
        )},
        { TrickType.FART_PILLOW,       new TrickMission(
            "Coussin p�teur", -30, 80, true, 10, null
        )},
    };
}

