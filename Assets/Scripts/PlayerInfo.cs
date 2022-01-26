using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    private float stress = 0.0f;
    bool actionDoing = false;
    PlayerMoves playerMove;

    public ScenesGest sceneGest;

    public float onSightTickMultiplier = 5.0f;
    public float riseStressTickPeriodS = 5.0f;
    public float incrementStressValueByTick = 1.0f;
    public float lastTick;
    public bool isTricking = false;

    public GameObject UIQTE;
    public GameObject UITrick;

    TrickType currentTrickType;
    public TrickMission trickMission;
    public float trickStartTime { get; }

    //bool canEnterTrickingMode = false;
    // Start is called before the first frame update
    void Start()
    {
        playerMove = gameObject.GetComponent<PlayerMoves>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isTricking && ((Time.realtimeSinceStartup - lastTick) >= riseStressTickPeriodS)) {
            AddStress(incrementStressValueByTick);
            lastTick = Time.realtimeSinceStartup;
        }
    }

    public void AddStress(float amount)
    {
        stress = Mathf.Clamp(stress + amount, 0.0f, 100.0f);
        Debug.Log("Stress : " + stress);
        if (stress >= 100.0f)
        {
            Lose();
        }
    }

    public float GetStress()
    {
        return stress;
    }

    public bool IsActionDoing()
    {
        return actionDoing;
    }

    public void Freeze()
    {
        playerMove.interact(true);
    }

    public void Unfreeze()
    {
        playerMove.interact(false);
    }

    public void SetActionDoing(bool actived)
    {
        actionDoing = actived;
        if(actived)
        {
            Freeze();
        } else
        {
            Unfreeze();
        }
    }

    public void SetIsTricking(bool _isTricking)
    {
        isTricking = _isTricking;

        /* Update sound */
        SoundAmbiance ambiance = GameObject.FindWithTag("UI_SoundAmbiance").GetComponent<SoundAmbiance>();
        ambiance.SetAmbiance((isTricking) ? AudioType.AMBIANCE_PUNK : AudioType.AMBIANCE_LOOP);
    }

    public void ToggleIsTricking()
    {
        SetIsTricking(!isTricking);
    }

    public bool GetIsTricking()
    {
        return isTricking;
    }

    public void Lose()
    {
        Debug.Log("To much stress, loooosser");
        sceneGest.LostGame();
    }
}
