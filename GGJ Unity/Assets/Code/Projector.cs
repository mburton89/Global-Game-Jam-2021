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

    [SerializeField] Image fadeOverlay;

    [SerializeField] GameObject tapIndicator;

    private void Awake()
    {
        canGoToNextSlide = true;
        fadeOverlay.DOFade(1, 0);
    }

    private void Start()
    {
        fadeOverlay.DOFade(0, 1f);
        StartCoroutine(nameof(TypeSentence));
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
        tapIndicator.SetActive(false);

        if (currentSlideIndex < slides.Count - 1)
        {
            if (canGoToNextSlide)
            {
                StartCoroutine(nameof(GoToNextSlideCo));
            }
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


        StopCoroutine(nameof(TypeSentence));
        captionText.text = "";

        yield return new WaitForSeconds(secondsToSwitchSlides);

        currentSlideIndex++;
        StartCoroutine(nameof(TypeSentence));

        lightFlicker.localScale = Vector3.one;
        slides[currentSlideIndex].DOFade(1f, .1f);
        //captionText.SetText(captions[currentSlideIndex]);
        slideClips[currentSlideIndex].Play();
        yield return new WaitForSeconds(.1f);
        canGoToNextSlide = true;
    }

    void Skip()
    {
        StartCoroutine(FadeAndSkip());
    }

    private IEnumerator FadeAndSkip()
    {
        fadeOverlay.DOFade(1, 1);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator TypeSentence()
    {
        string sentence = captions[currentSlideIndex];
        foreach (char letter in sentence.ToCharArray())
        {
            captionText.text += letter;
            yield return new WaitForSeconds(0.02f);
        }
    }
}
