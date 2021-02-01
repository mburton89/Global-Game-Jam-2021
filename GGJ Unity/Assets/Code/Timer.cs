using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeLeft;
    public TextMeshProUGUI timeText;
    private const string TIME_PREFIX = "00:";
    private bool _canShowWin;
    public Button pause;

    private void Awake()
    {
        _canShowWin = true;
    }

    private void OnEnable()
    {
        pause.onClick.AddListener(Pause);
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

    void Pause()
    {
        PauseMenu.Instance.Pause();
    }
}
