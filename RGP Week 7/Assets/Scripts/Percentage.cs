using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Percentage : MonoBehaviour
{
    private Timer timer;
    public TextMeshProUGUI TText;

    void Start()
    {
        timer = GetComponent<Timer>();
    }

    void Update()
    {
        float percentage = ColourChanger.counter;
        percentage = (percentage / 111) *100;
        TText.text = percentage.ToString("F2")+ "%";

        if (timer.TValue <= 0)
        {
            PlayerInfo.playerShieldPercentage = percentage;
            SceneManager.LoadScene(2);
        }
    }
}
