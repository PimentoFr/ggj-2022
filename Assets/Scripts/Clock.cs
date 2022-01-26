using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    public GameObject pausing;
    public int clockSpeed = 2;
    public Text TimerText;

    public ScenesGest sceneGest;
    //HEURES EN MINUTES : 8h = 480, 18h = 1080
    float hourInMinutes = 480f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (!pausing.GetComponent<Pause>().getPaused())
        {
            hourInMinutes += (Time.fixedDeltaTime * clockSpeed);

            int hours = Mathf.FloorToInt(hourInMinutes / 60);
            int mins = Mathf.FloorToInt(hourInMinutes) - (hours * 60);

            TimerText.text = $"{hours.ToString("D2")}:{mins.ToString("D2")}";

            if (hourInMinutes > 1080)
            {
                hourInMinutes = 1080;
                TimerText.text = "18:00";

                //GAMEOVER
                Debug.Log("End of the day, Game Over");
                sceneGest.LostGame();
            }
        }
            

    }
}
