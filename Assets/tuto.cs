using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class tuto : MonoBehaviour
{
    public List<string> textes;
    public List<Sprite> images;
    public Sprite finishButton;
    public Sprite nextButton;
    public GameObject textbox;
    public GameObject imagebox;
    public GameObject next;
    public GameObject prev;
    public GameObject UImenu;

    int step;

    void Start()
    {
        step = 0;
        imagebox.GetComponent<Image>().sprite = images[step];
        textbox.GetComponent<TextMeshProUGUI>().SetText(textes[step]);

        prev.GetComponent<Image>().enabled = false;
    }

    public void nextTuto()
    {
        if (step < (textes.Count - 1))
        {
            step++;

            imagebox.GetComponent<Image>().sprite = images[step];
            textbox.GetComponent<TextMeshProUGUI>().SetText(textes[step]);

            if (step > 0)
            {
                prev.GetComponent<Image>().enabled = true;
            }
            else
            {
                prev.GetComponent<Image>().enabled = false;
            }

            if (step == textes.Count - 1)
            {
                next.GetComponent<Image>().sprite = finishButton;
            }
            else
            {
                next.GetComponent<Image>().sprite = nextButton;
            }
        }
        else
        {
            ExitTuto();
        } 
    }

    public void PreviousTuto()
    {
        if (step > 0)
        {
            step--;
        }

        imagebox.GetComponent<Image>().sprite = images[step];
        textbox.GetComponent<TextMeshProUGUI>().SetText(textes[step]);

        if (step == 0)
        {
            prev.GetComponent<Image>().enabled = false;
        }
    }

    public void ExitTuto()
    {
        step = 0;
        imagebox.GetComponent<Image>().sprite = images[step];
        textbox.GetComponent<TextMeshProUGUI>().SetText(textes[step]);
        next.GetComponent<Image>().sprite = nextButton;
        gameObject.SetActive(false);
        UImenu.SetActive(true);
    }
}
