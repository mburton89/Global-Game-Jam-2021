using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeLeft;
    public TextMeshProUGUI timeText;
    private const string TIME_PREFIX = "00:";

    void Update()
    {
        timeLeft -= Time.deltaTime;
        string timeString = timeLeft.ToString().Substring(0, 2);
        timeText.SetText(TIME_PREFIX + timeString);
        if (timeLeft < 0)
        {
            //GameOver();
        }
    }
}
