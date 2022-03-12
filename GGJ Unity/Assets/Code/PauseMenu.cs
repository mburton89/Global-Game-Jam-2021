using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu Instance;
    public GameObject container;
    public Button resumeButton;
    public Button journalButton;
    public Button exitButton;
    public GameObject drag;
    public GameObject slingshot;
    public AudioSource click;

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        resumeButton.onClick.AddListener(Resume);
        journalButton.onClick.AddListener(ShowJournal);
        exitButton.onClick.AddListener(Exit);
    }

    private void OnDisable()
    {
        resumeButton.onClick.RemoveListener(Resume);
        journalButton.onClick.RemoveListener(ShowJournal);
        exitButton.onClick.RemoveListener(Exit);
    }

    public void Pause()
    {
        drag.SetActive(false);
        slingshot.SetActive(false);
        container.SetActive(true);
        Time.timeScale = 0;
        GameSoundManager.Instance.Music.volume = GameSoundManager.Instance.Music.volume / 2;
        click.Play();
    }

    public void Pause(bool showPauseMenu)
    {
        if (showPauseMenu)
        {
            container.SetActive(true);
        }
        drag.SetActive(false);
        slingshot.SetActive(false);
        Time.timeScale = 0;
        GameSoundManager.Instance.Music.volume = GameSoundManager.Instance.Music.volume / 2;
        click.Play();
    }

    public void Resume()
    {
        drag.SetActive(true);
        slingshot.SetActive(true);
        container.SetActive(false);
        Time.timeScale = 1;
        GameSoundManager.Instance.Music.volume = GameSoundManager.Instance.Music.volume * 2;
        click.Play();
    }

    public void ShowJournal()
    {
        JournalMenu.Instance.Activate();
    }

    void Exit()
    {
        GameSoundManager.Instance.Music.Stop();
        Time.timeScale = 1;
        click.Play();
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
