using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class Intro : MonoBehaviour
{
    [SerializeField] private List<Sprite> images;
    [SerializeField] private List<string> phrases;
    private int _index;
    public Image image;
    public TextMeshProUGUI text;
    public Image cover;

    public Button button;

    void Start()
    {
        _index = 0;
        image.sprite = images[_index];
        text.SetText(phrases[_index]);
        StartCoroutine(ShowSlides());
        button.onClick.AddListener(LoadMenu);
    }

    private IEnumerator ShowSlides()
    {
        yield return new WaitForSeconds(4);
        _index++;
        if (_index == images.Count)
        {
            //LoadMenu();
            StartCoroutine(End());
        }
        else
        {
            image.sprite = images[_index];
            text.SetText(phrases[_index]);
            StartCoroutine(ShowSlides());
        }
    }

    void LoadMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    private IEnumerator End()
    {
        yield return new WaitForSeconds(1);
        cover.DOFade(1, 2);
        yield return new WaitForSeconds(2);
        LoadMenu();
    }
}
