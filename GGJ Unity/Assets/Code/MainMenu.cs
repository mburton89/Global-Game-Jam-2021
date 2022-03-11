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

    [SerializeField] GameObject diploma;

    private void Awake()
    {
        Instance = this;
        //PlayerPrefs.DeleteAll();
    }

    private void Start()
    {
        if (PlayerPrefs.GetInt("Wave20Assignment") == 1)
        {
            diploma.SetActive(true);
        }
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
            PlayerPrefs.SetInt("Wave", 1);
            SceneManager.LoadScene(1);
        }
    }
}
