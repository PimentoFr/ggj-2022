using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum AudioType
{
    AMBIANCE_PUNK,
    AMBIANCE_LOOP,
    POSTER_CLEAN,
    POSTER_PLACE,
    POSTER_CHAOS,
    AGRAFER_USE,
    AGRAFER_COLLECT,
    AGRAFER_PLAY_CLIPS,
    PEN_CHOOSE,
    PEN_MOISTURE,
    PEN_PICK,
    PEN_SIGN,
    PEN_THROW,
    CHAIR_REMOVE,
    CHAIR_MOVE,
    CHAIR_FARTING_BAG,
    FILE_ORDER,
    FILE_BILL,
    FILE_CHAOS,
    COFFEE_MAKE,
    COFFEE_PUT_MUG,
    COFFEE_CLEAN_MUG,
    COFFEE_FILL_WATER,
    COFFEE_POISON,
    COMPUTER_SWITCH_ON,
    COMPUTER_SWITCH_OFF,
    COMPUTER_UPDATE,
    COMPUTER_RUN_YOUTUBE,
    COMPUTER_STOP_YOUTUBE,
    COPIER_DROP_PICTURES,
    COPIER_FILL,
    COPIER_TAKE,
    COPIER_ASS,
    PAPER_ORDER,
    PAPER_UNFOLD,
    PAPER_PLANE,
    PLANT_WATER,
    PLANT_PLACE,
    PLANT_FALL,
    PHONE_BULLSHIT,
    PHONE_TYPE,
    PHONE_CONVINCE,
    PHONE_APOLOGIZE,
    PHONE_PRANK,
    DEFAULT_CORRECT,
    DEFAULT_FAILED,
    DEFAULT_SWIPE,

    NULL
}

public class AudioClipList : MonoBehaviour
{
    public AudioClip ambiancePunk;
    public AudioClip ambianceLoop;

    public AudioClip posterClean;
    public AudioClip posterPlace;
    public AudioClip posterChaos;

    public AudioClip agraferUse;
    public AudioClip agraferCollect;
    public AudioClip agraferPlayClips;

    public AudioClip penChoose;
    public AudioClip penMoisture;
    public AudioClip penPick;
    public AudioClip penSign;
    public AudioClip penThrow;

    public AudioClip chairRemove;
    public AudioClip chairMove;
    public AudioClip chairFartingBag;

    public AudioClip fileOrder;
    public AudioClip fileBill;
    public AudioClip fillChaos;

    public AudioClip coffeeMake;
    public AudioClip coffeePutMug;
    public AudioClip coffeeCleanMug;
    public AudioClip cofferFillWater;
    public AudioClip coffeePoison;

    public AudioClip computerSwitchOn;
    public AudioClip computerSwitchOff;
    public AudioClip computerUpdate;
    public AudioClip computerStopYoutube;
    public AudioClip computerRunYoutube;

    public AudioClip copierDropPhotos;
    public AudioClip copierFill;
    public AudioClip copierTake;
    public AudioClip copierAss;

    public AudioClip paperOrder;
    public AudioClip paperUnfold;
    public AudioClip paperPlane;

    public AudioClip plantWater;
    public AudioClip plantPlace;
    public AudioClip plantFall;

    public AudioClip phoneBullshit;
    public AudioClip phoneType;
    public AudioClip phoneConvince;
    public AudioClip phoneApologize;
    public AudioClip phonePrank;

    public AudioClip DefaultCorrect;
    public AudioClip DefaultFailed;
    public AudioClip DefaultSwipe;

    static public AudioClip GetAudioClipFromAudioType(AudioType type)
    {

        AudioClipList go = GameObject.FindWithTag("ListSound").GetComponent<AudioClipList>();

        Debug.Log("Try to play "+type);
        switch (type)
        {
            case AudioType.AMBIANCE_PUNK: return go.ambiancePunk;
            case AudioType.AMBIANCE_LOOP: return go.ambianceLoop;
            case AudioType.POSTER_CLEAN: return go.posterClean;
            case AudioType.POSTER_PLACE: return go.posterPlace;
            case AudioType.POSTER_CHAOS: return go.posterChaos;
            case AudioType.AGRAFER_USE: return go.agraferUse;
            case AudioType.AGRAFER_COLLECT: return go.agraferCollect;
            case AudioType.AGRAFER_PLAY_CLIPS: return go.agraferPlayClips;
            case AudioType.PEN_CHOOSE: return go.penChoose;
            case AudioType.PEN_MOISTURE: return go.penMoisture;
            case AudioType.PEN_PICK: return go.penPick;
            case AudioType.PEN_THROW: return go.penThrow;
            case AudioType.PEN_SIGN: return go.penSign;
            case AudioType.CHAIR_REMOVE: return go.chairRemove;
            case AudioType.CHAIR_MOVE: return go.chairMove;
            case AudioType.CHAIR_FARTING_BAG: return go.chairFartingBag;
            case AudioType.FILE_ORDER: return go.fileOrder;
            case AudioType.FILE_BILL: return go.fileBill;
            case AudioType.FILE_CHAOS: return go.fillChaos;
            case AudioType.COFFEE_MAKE: return go.coffeeMake;
            case AudioType.COFFEE_PUT_MUG: return go.coffeePutMug;
            case AudioType.COFFEE_CLEAN_MUG: return go.coffeeCleanMug;
            case AudioType.COFFEE_FILL_WATER: return go.cofferFillWater;
            case AudioType.COFFEE_POISON: return go.coffeePoison;
            case AudioType.COMPUTER_SWITCH_ON: return go.computerSwitchOn;
            case AudioType.COMPUTER_SWITCH_OFF: return go.computerSwitchOff;
            case AudioType.COMPUTER_UPDATE: return go.computerUpdate;
            case AudioType.COMPUTER_RUN_YOUTUBE: return go.computerRunYoutube;
            case AudioType.COMPUTER_STOP_YOUTUBE: return go.computerStopYoutube;
            case AudioType.COPIER_DROP_PICTURES: return go.copierDropPhotos;
            case AudioType.COPIER_FILL: return go.copierFill;
            case AudioType.COPIER_TAKE: return go.copierTake;
            case AudioType.COPIER_ASS: return go.copierAss;
            case AudioType.PAPER_ORDER: return go.paperOrder;
            case AudioType.PAPER_UNFOLD: return go.paperUnfold;
            case AudioType.PAPER_PLANE: return go.paperPlane;
            case AudioType.PLANT_WATER: return go.plantWater;
            case AudioType.PLANT_PLACE: return go.plantPlace;
            case AudioType.PLANT_FALL: return go.plantFall;
            case AudioType.PHONE_TYPE: return go.phoneType;
            case AudioType.PHONE_APOLOGIZE: return go.phoneApologize;
            case AudioType.PHONE_PRANK: return go.phonePrank;
            case AudioType.DEFAULT_CORRECT: return go.DefaultCorrect;
            case AudioType.DEFAULT_FAILED: return go.DefaultFailed;
            case AudioType.DEFAULT_SWIPE: return go.DefaultSwipe;
            default:
                Debug.Log("Type not found " + type);
                break;
        }
        return null;
    }
}
