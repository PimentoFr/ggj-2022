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
    PAPER_PLANE =8,
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
    public AudioType playSound;

    public TrickMission(string _action, float _stressSuccess, float _stressDetected, bool _isCriticalMission, float _durationInS, AudioType _playsound)
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
        { TrickType.ASS_COPY,       new TrickMission(
            "Scan your butty", -30, 100, true, 10,  AudioType.COPIER_ASS
        )},
        { TrickType.PLANT_STRIKE,       new TrickMission(
            "Strike the plant", -5, 5, true, 3,  AudioType.PLANT_FALL
        )},

        {TrickType.RUN_YOUTUBE,       new TrickMission(
            "Run Youtube", -5, 5, false, 3,  AudioType.COMPUTER_RUN_YOUTUBE
        )},

        { TrickType.THROW_FILL,       new TrickMission(
            "Throw files", -5, 5, true, 3,  AudioType.PEN_THROW
        )},
        { TrickType.PRANK_PHONE,       new TrickMission(
            "Prank a client", -30, 100, true, 10,  AudioType.PHONE_PRANK
        )},
        { TrickType.POISON_MUG,       new TrickMission(
            "Drop Methylene blue", -30, 100, true, 10,  AudioType.COFFEE_POISON
        )},
        { TrickType.THROW_PENS,       new TrickMission(
            "Throw pens", -5, 5, true, 3,  AudioType.PEN_THROW
        )},
        { TrickType.PLAY_WITH_CLIP,       new TrickMission(
            "Play with clips", -5, 5, true, 3,  AudioType.AGRAFER_PLAY_CLIPS
        )},
        { TrickType.PAPER_PLANE,       new TrickMission(
            "Do a paper plane", -5, 5, true, 3,  AudioType.PAPER_PLANE
        )},
        { TrickType.TAG,       new TrickMission(
            "Tag the poster", -30, 100, true, 10,  AudioType.POSTER_CHAOS
        )},
        { TrickType.FART_PILLOW,       new TrickMission(
            "Put a farting bag", -5, 5, true, 3,  AudioType.CHAIR_FARTING_BAG
        )},
        { TrickType.DRAW_PAPERBOARD,       new TrickMission(
            "Draw on the paperboard", -30, 100, true, 10,  AudioType.NULL
        )},
    };
}

