using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightFlicker : MonoBehaviour
{
    private Image _light;
    private float _secondsOn;
    private float _secondsOff;

    private void Awake()
    {
        _light = GetComponent<Image>();
    }

    private void Start()
    {
        StartCoroutine(Flicker());
    }

    private IEnumerator Flicker()
    {
        _secondsOff = Random.Range(0.025f, 0.1f);
        _secondsOn = Random.Range(0.025f, 0.1f);

        _light.color = Color.white;
        yield return new WaitForSeconds(_secondsOn);

        _light.color = new Color(1, 1, 1, Random.Range(0.85f, 1f));
        yield return new WaitForSeconds(_secondsOff);

        StartCoroutine(Flicker());
    }
}