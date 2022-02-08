using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static MainMenu Instance;
    public AudioSource buttonHover;
    public AudioSource buttonClick;
    public GameObject loadingContainer;

    private void Awake()
    {
        Instance = this;
        PlayerPrefs.SetInt("Wave", 1);
    }

    public void Play()
    {
        loadingContainer.SetActive(true);
        buttonClick.Play();
        if (PlayerPrefs.GetInt("hasSeenIntro") == 1)
        {
            SceneManager.LoadScene(2);
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }
}
