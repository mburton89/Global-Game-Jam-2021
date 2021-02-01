using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu Instance;
    public GameObject container;
    public Button resume;
    public Button exit;
    public GameObject drag;
    public GameObject slingshot;
    public AudioSource click;

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        resume.onClick.AddListener(Resume);
        exit.onClick.AddListener(Exit);
    }

    private void OnDisable()
    {
        resume.onClick.RemoveListener(Resume);
        exit.onClick.RemoveListener(Exit);
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


    void Resume()
    {
        drag.SetActive(true);
        slingshot.SetActive(true);
        container.SetActive(false);
        Time.timeScale = 1;
        GameSoundManager.Instance.Music.volume = GameSoundManager.Instance.Music.volume * 2;
        click.Play();
    }

    void Exit()
    {
        Time.timeScale = 1;
        click.Play();
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
