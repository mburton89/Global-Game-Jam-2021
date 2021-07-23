using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PostWaveMenu : MonoBehaviour
{
    public static PostWaveMenu Instance;

    [SerializeField] GameObject container;
    [SerializeField] Button nextWaveButton;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnEnable()
    {
        nextWaveButton.onClick.AddListener(GoToNextWave);
    }

    void OnDisable()
    {
        nextWaveButton.onClick.RemoveListener(GoToNextWave);
    }

    public void Activate()
    {
        container.SetActive(true);
    }

    public void Deactivate()
    {
        container.SetActive(false);
    }

    void GoToNextWave()
    {
        ReportCard.Instance.ShowYouWin(); //TODO fixe the bugs
    }
}
