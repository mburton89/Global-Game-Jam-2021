using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;

public class GameOverMenu : MonoBehaviour
{
    public static GameOverMenu Instance;

    [SerializeField] Image bgImage;
    [SerializeField] Button restartButton;
    [SerializeField] Button mainButton;
    [SerializeField] GameObject container;
    [SerializeField] TextMeshProUGUI reachedWave;
    [SerializeField] TextMeshProUGUI highestWave;
    [SerializeField] TextMeshProUGUI highestWaveLabel;
    [SerializeField] AudioSource buttonClick;

    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        if (!GameSoundManager.Instance.Music.isPlaying)
        {
            GameSoundManager.Instance.Music.Play();
        }
    }

    private void OnEnable()
    {
        restartButton.onClick.AddListener(Restart);
        mainButton.onClick.AddListener(GoToMain);
    }

    private void OnDisable()
    {
        restartButton.onClick.RemoveListener(Restart);
        mainButton.onClick.RemoveListener(GoToMain);
    }

    public void Activate()
    {
        StartCoroutine(GameOver());
    }

    private IEnumerator GameOver()
    {
        Destroy(FindObjectOfType<DragObject>());

        Timer.Instance.canCountDown = false;
        bgImage.DOFade(.75f, .5f);

        Zombie[] zombies = FindObjectsOfType<Zombie>();
        foreach (Zombie zombie in zombies)
        {
            zombie.walkSpeed = 0;
        }

        ZombieSpawner zombieSpawner = FindObjectOfType<ZombieSpawner>();
        zombieSpawner.EndWave();

        GameSoundManager.Instance.Music.Stop();

        yield return new WaitForSeconds(0.5f);

        container.SetActive(true);

        reachedWave.SetText(PlayerPrefs.GetInt("Wave").ToString());

        if (PlayerPrefs.GetInt("Wave") > PlayerPrefs.GetInt("HighestWave"))
        {
            PlayerPrefs.SetInt("HighestWave", PlayerPrefs.GetInt("Wave"));
            highestWaveLabel.SetText("NEW RECORD!");
        }

        highestWave.SetText(PlayerPrefs.GetInt("HighestWave").ToString());

        PlayerPrefs.SetInt("Wave", 1);
    }

    void Restart()
    {
        StartCoroutine(RestartCo());
    }

    private IEnumerator RestartCo()
    {
        buttonClick.Play();
        yield return new WaitForSeconds(.1f);
        GameSoundManager.Instance.Music.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void GoToMain()
    {
        StartCoroutine(GoToMainCo());
    }

    private IEnumerator GoToMainCo()
    {
        buttonClick.Play();
        yield return new WaitForSeconds(.1f);
        SceneManager.LoadScene(0);
    }
}
