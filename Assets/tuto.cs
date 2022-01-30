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
    public GameObject textbox;
    public GameObject imagebox;
    public GameObject button;
    public GameObject UImenu;

    int step;

    void Start()
    {
        step = 0;
    }

    public void nextTuto()
    {
        if (step < textes.Count)
        {
            imagebox.GetComponent<Image>().sprite = images[step];
            textbox.GetComponent<TextMeshProUGUI>().SetText(textes[step]);

            if (step == textes.Count - 1)
                button.GetComponent<Image>().sprite = finishButton;

            step++;
        }
        else
        {
            step = 0;
            gameObject.SetActive(false);
            UImenu.SetActive(true);
        } 
    }
}
