using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public static Timer Instance;

    public float timeLeft;
    public TextMeshProUGUI timeText;
    private const string TIME_PREFIX = "00:";
    private bool _canCountDown;
    public Button pause;

    private void Awake()
    {
        Instance = this;
        _canCountDown = true;
    }

    private void Start()
    {
        GameSoundManager.Instance.Music.volume = GameSoundManager.Instance.Music.volume * 2;
    }

    private void OnEnable()
    {
        pause.onClick.AddListener(Pause);
    }

    void Update()
    {
        if (_canCountDown)
        {
            if (timeLeft <= 0)
            {
                timeText.SetText("00:00");
                //GameSoundManager.Instance.Music.Stop();
                GameSoundManager.Instance.Music.volume = GameSoundManager.Instance.Music.volume / 2;
                GameSoundManager.Instance.SchoolBell.Play();
                _canCountDown = false;
                //ReportCard.Instance.ShowYouWin();
                //PostWaveMenu.Instance.Activate();

                ReportCard.Instance.ShowYouWin();
                ReportCard.Instance.ShowWaveTransition();

                Zombie[] zombies = FindObjectsOfType<Zombie>();
                foreach (Zombie zombie in zombies)
                {
                    zombie.walkSpeed = 0;
                }

                ZombieSpawner zombieSpawner = FindObjectOfType<ZombieSpawner>();
                zombieSpawner.EndWave();
            }
            else
            {
                timeLeft -= Time.deltaTime;
                if (timeLeft > 10)
                {
                    string timeString = timeLeft.ToString().Substring(0, 2);
                    timeText.SetText(TIME_PREFIX + timeString);
                }
                else
                {
                    string timeString = "0" + timeLeft.ToString().Substring(0, 1);
                    timeText.SetText(TIME_PREFIX + timeString);
                }
            }
        }
    }

    void Pause()
    {
        PauseMenu.Instance.Pause();
    }
}
