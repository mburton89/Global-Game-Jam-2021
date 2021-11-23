using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PostWaveMenu : MonoBehaviour
{
    public static PostWaveMenu Instance;

    public int itemsShot;
    public int itemsHit;
    public int accuracy;
    public int multiKills;

    [SerializeField] GameObject container;
    [SerializeField] Button nextWaveButton;
    [SerializeField] TextMeshProUGUI waveText;
    [SerializeField] TextMeshProUGUI gradeText;
    [SerializeField] TextMeshProUGUI accuracyText;
    [SerializeField] TextMeshProUGUI multiKillsText;
    [SerializeField] TextMeshProUGUI itemsLeftText;
    [SerializeField] TextMeshProUGUI itemsLeftNote;

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
        ReportCard.Instance.ShowYouWin();
        StartCoroutine(DelayActivate());
    }

    private IEnumerator DelayActivate()
    {
        yield return new WaitForSeconds(3);
        Destroy(FindObjectOfType<DragObject>());
        container.SetActive(true);
        waveText.SetText("Wave " + PlayerPrefs.GetInt("Wave").ToString() + " of 10");
        accuracy = (int)(((float)itemsHit / (float)itemsShot) * 100f);
        print(itemsHit);
        print(itemsShot);
        print(accuracy);
        accuracyText.SetText(accuracy.ToString() + "%");
        multiKillsText.SetText(multiKills.ToString());
        itemsLeftText.SetText(SlingShotManager.instance.ammosRemaining.ToString());
        PlayerPrefs.SetInt("ItemsRemaining", SlingShotManager.instance.ammosRemaining);
        DetermineGrade();
    }

    public void Deactivate()
    {
        container.SetActive(false);
    }

    void GoToNextWave()
    {
        ReportCard.Instance.ShowYouWin();
        ReportCard.Instance.ShowWaveTransition();
    }

    void DetermineGrade()
    {
        if (accuracy >= 95 && multiKills > 0)
        {
            gradeText.SetText("A+");
        }
        else if (accuracy >= 90)
        {
            gradeText.SetText("A");
        }
        else if (accuracy >= 80)
        {
            gradeText.SetText("B");
        }
        else if (accuracy >= 70)
        {
            gradeText.SetText("C");
        }
        else if (accuracy >= 60)
        {
            gradeText.SetText("D");
        }
        else
        {
            gradeText.SetText("F");
        }
    }

    void DetermineMoney()
    {
        float moneyToGive1 = (float)SlingShotManager.instance.ammosRemaining / 100f;
        MoneyManager.Instance.AddMoney(moneyToGive1);
        float moneyToGive2 = (float)PlayerPrefs.GetInt("Wave") / 100f;
        MoneyManager.Instance.AddMoney(moneyToGive2);
    }
}
