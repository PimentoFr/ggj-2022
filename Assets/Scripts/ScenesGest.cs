using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum ScenesType {
    START_GAME,
    WON_GAME,
    LOST_GAME,
    RESTART_GAME,
    CREDITS,
    CONTROLS,

    NULL
}

public class ScenesGest : MonoBehaviour
{

    public ScenesType SceneOnEscape = ScenesType.NULL;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            GoToScene(SceneOnEscape);
        }
    }

    public void GoToScene(ScenesType sceneType)
    {
        switch(sceneType)
        {
            case ScenesType.START_GAME: StartGame(); break;
            case ScenesType.WON_GAME: WonGame(); break;
            case ScenesType.LOST_GAME: LostGame(); break;
            case ScenesType.RESTART_GAME: RestartGame(); break;
            case ScenesType.CREDITS: Credits(); break;
            case ScenesType.CONTROLS: Controls(); break;
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Scene1");
    }

    public void WonGame()
    {
        SceneManager.LoadScene("WonScene");
    }

    public void LostGame()
    {
        SceneManager.LoadScene("LostScene");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("StartingScene");
    }

    public void Credits()
    {
        SceneManager.LoadScene("CreditsScene");
    }

    public void Controls()
    {
        SceneManager.LoadScene("ControlsScene");
    }
}
