using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskLabel : MonoBehaviour
{
    public GameObject backgroundGO, labelGO, skullsEasyGO, skullsHardGO;
    Text taskTxt;
    Color greenColor, redColor, blueColor;
    Image backgroundImg;

    float percent;

    // Start is called before the first frame update
    void Start()
    {
        backgroundImg = backgroundGO.GetComponent<Image>();

        taskTxt = labelGO.GetComponent<Text>();

        greenColor = Color.green;
        redColor = Color.red;
        blueColor = new Color(0.3f, 0.3f, 1);
        UpdateJinxBar(0.0f);
        HideTaskLabel();
    }

    public void ShowTaskLabel(string text, bool isTricking, bool isLongTask)
    {
        taskTxt.text = text;

        if (isTricking)
        {
            taskTxt.color = redColor;
            backgroundImg.enabled = true;

            skullsEasyGO.SetActive(true);

            if (isLongTask)
            {
                skullsHardGO.SetActive(true);
            }
        }
        else
        {
            taskTxt.color = greenColor;
        }

        if (text == "Take lift")
        {
            taskTxt.color = blueColor;
        }

        UpdateJinxBar(0.0f);
        taskTxt.enabled = true;
    }


    public void HideTaskLabel()
    {
        taskTxt.enabled = false;
        backgroundImg.enabled = false;
        skullsEasyGO.SetActive(false);
        skullsHardGO.SetActive(false);
    }

    public void UpdateJinxBar(float percent)
    {
        //percent entre 0f et 1f
        backgroundImg.fillAmount = percent;
    }
}
