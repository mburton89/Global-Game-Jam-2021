using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class Projector : MonoBehaviour
{
    [SerializeField] Transform projectorPivot;
    [SerializeField] TextMeshProUGUI captionText;
    [SerializeField] Button nextSlideButton;
    [SerializeField] Button skipButton;
    [SerializeField] AudioSource nextSlideAudioSource;
    [SerializeField] List<AudioClip> nextSlideClips;
    [SerializeField] List<AudioSource> slideClips;
    [SerializeField] List<Image> slides;
    [SerializeField] List<string> captions;
    [SerializeField] float secondsToSwitchSlides;
    [SerializeField] Ease ease;
    [SerializeField] Transform lightFlicker;
    int currentSlideIndex;
    bool canGoToNextSlide;

    private void Awake()
    {
        canGoToNextSlide = true;
    }

    void OnEnable()
    {
        nextSlideButton.onClick.AddListener(GoToNextSlide);
        skipButton.onClick.AddListener(Skip);
    }

    void OnDisable()
    {
        nextSlideButton.onClick.RemoveListener(GoToNextSlide);
        skipButton.onClick.RemoveListener(Skip);
    }

    void GoToNextSlide()
    {
        if (currentSlideIndex < slides.Count - 1 && canGoToNextSlide)
        {
            StartCoroutine(nameof(GoToNextSlideCo));
        }
        else
        {
            Skip();
        }
    }

    private IEnumerator GoToNextSlideCo()
    {
        canGoToNextSlide = false;
        lightFlicker.localScale = Vector3.zero;
        nextSlideAudioSource.clip = nextSlideClips[Random.Range(0, nextSlideClips.Count - 1)];
        nextSlideAudioSource.Play();
        slides[currentSlideIndex].DOFade(0.33f, .1f);
        projectorPivot.DORotate(new Vector3(0, 0, projectorPivot.eulerAngles.z - 30), secondsToSwitchSlides, RotateMode.Fast).SetEase(ease);
        yield return new WaitForSeconds(secondsToSwitchSlides);
        currentSlideIndex++;
        lightFlicker.localScale = Vector3.one;
        slides[currentSlideIndex].DOFade(1f, .1f);
        captionText.SetText(captions[currentSlideIndex]);
        slideClips[currentSlideIndex].Play();
        yield return new WaitForSeconds(.1f);
        canGoToNextSlide = true;
    }

    void Skip()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
