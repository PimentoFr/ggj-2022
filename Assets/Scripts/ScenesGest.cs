using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesGest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
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