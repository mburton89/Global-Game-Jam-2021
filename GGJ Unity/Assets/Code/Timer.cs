using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeLeft;
    public TextMeshProUGUI timeText;
    private const string TIME_PREFIX = "00:";
    private bool _canShowWin;

    private void Awake()
    {
        _canShowWin = true;
    }

    void Update()
    {
        if (timeLeft < 0 && _canShowWin)
        {
            timeText.SetText("00:00");
            GameSoundManager.Instance.Music.Stop();
            GameSoundManager.Instance.SchoolBell.Play();
            _canShowWin = false;
            ReportCard.Instance.ShowYouWin();
        }
        else
        {
            timeLeft -= Time.deltaTime;
            string timeString = timeLeft.ToString().Substring(0, 2);
            timeText.SetText(TIME_PREFIX + timeString);
        }
    }
}
