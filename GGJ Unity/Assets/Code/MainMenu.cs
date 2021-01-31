using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static MainMenu Instance;
    public AudioSource buttonHover;
    public AudioSource buttonClick;
    private void Awake()
    {
        Instance = this;
    }
    public void Play()
    {
        buttonClick.Play();
        SceneManager.LoadScene(1);
    }
}
