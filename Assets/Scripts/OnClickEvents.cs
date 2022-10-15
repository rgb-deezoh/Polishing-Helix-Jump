using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OnClickEvents : MonoBehaviour
{

    public TextMeshProUGUI soundTexts;
    // Start is called before the first frame update
    void Start()
    {/*
        if (GameManager.mute)
        {
            GameManager.mute = false;
            soundTexts.text = "";
        }
        else
        {
            soundTexts.text = "/";
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MuteSounds()
    {
        if (GameManager.mute)
        {
            GameManager.mute = false;
            soundTexts.text = "";
        }
        else
        {
            GameManager.mute = true;
            soundTexts.text = "/";
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
