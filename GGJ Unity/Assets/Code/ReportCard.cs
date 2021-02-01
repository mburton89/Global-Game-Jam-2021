using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class ReportCard : MonoBehaviour
{
    public static ReportCard Instance;

    public TextMeshProUGUI Grade;
    public TextMeshProUGUI Wave;
    public TextMeshProUGUI Notes;

    public TextMeshProUGUI waveNotes;
    public TextMeshProUGUI waveNotes2;
    public Image waveCoverImage;

    void Awake()
    {
        Instance = this;
        _canShake = true;
    }

    private void Start()
    {
        waveCoverImage.color = Color.black;
        waveCoverImage.DOFade(0, .5f);
        Wave.SetText(PlayerPrefs.GetInt("Wave").ToString());
    }

    public void ShowDoubleKill()
    {
        Grade.SetText("A-");
        Notes.SetText("Double Kill!");
        Shake();
    }

    public void ShowTripleKill()
    {
        Grade.SetText("A+");
        Notes.SetText("Triple Kill!");
        Shake();
    }

    public void ShowChaching()
    {
        Grade.SetText("A");
        Notes.SetText("Cha-CHING $$$");
        Shake();
    }

    public void ShowWaterSplode()
    {
        Grade.SetText("A");
        Notes.SetText("Bottle Splode!");
        Shake();
    }

    public void Lol()
    {
        Grade.SetText(":D");
        Notes.SetText("Lol");
        Shake();
    }

    public void ShowYouWin()
    {
        Grade.SetText("A+");
        Notes.SetText("Wave Complete");
        Shake();
        ShowWaveTransition();
    }

    void Shake()
    {
        StartCoroutine(shake());
    }

    private bool _canShake;
    private IEnumerator shake()
    {
        if (_canShake)
        {
            _canShake = false;
            Notes.transform.DOPunchScale(new Vector3(1.5f, 1.5f, 1.5f), .2f, 10, 1);
            yield return new WaitForSeconds(.3f);
            Notes.transform.localScale = Vector3.one;
            _canShake = true;
        }
    }

    public void ShowWaveTransition()
    {
        StartCoroutine(ShowWaveTransitionCo());
    }

    private IEnumerator ShowWaveTransitionCo()
    {
        Zombie[] zombies = FindObjectsOfType<Zombie>();
        foreach (Zombie zombie in zombies)
        {
            zombie.walkSpeed = 0;
        }

        ZombieSpawner zombieSpawner = FindObjectOfType<ZombieSpawner>();
        zombieSpawner.EndWave();

        yield return new WaitForSeconds(2f);
        waveCoverImage.DOFade(1, 1);
        waveNotes.SetText("Get ready for wave " + (PlayerPrefs.GetInt("Wave") + 1).ToString());
        waveNotes.DOFade(1, 1);
        waveNotes2.DOFade(1, 1);
        yield return new WaitForSeconds(1f);

        PlayerPrefs.SetInt("Wave", PlayerPrefs.GetInt("Wave") + 1);
        yield return new WaitForSeconds(2f);

        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
}
