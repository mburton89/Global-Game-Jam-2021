using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HitStreakManager : MonoBehaviour
{
    public static HitStreakManager Instance;

    public int currentHitStreak;
    public TextMeshProUGUI currentHitStreakText;
    public TextMeshProUGUI bestHitStreakText;

    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        currentHitStreak = PlayerPrefs.GetInt("CurrentHitStreak");
        currentHitStreakText.SetText(PlayerPrefs.GetInt("CurrentHitStreak").ToString());
        bestHitStreakText.SetText(PlayerPrefs.GetInt("BestHitStreak").ToString());
    }

    public void AddToCurrentHitStreak()
    {
        currentHitStreak++;
        PlayerPrefs.SetInt("CurrentHitStreak", currentHitStreak);
        if (currentHitStreak > PlayerPrefs.GetInt("BestHitStreak"))
        {
            PlayerPrefs.SetInt("BestHitStreak", currentHitStreak);
            bestHitStreakText.SetText(currentHitStreak.ToString());
        }
        currentHitStreakText.SetText(currentHitStreak.ToString());

        if (currentHitStreak == 50)
        {
            AssignmentsManager.Instance.CompleteHitstreak50Assignment();
        }

        if (currentHitStreak == 100)
        {
            AssignmentsManager.Instance.CompleteHitstreak100Assignment();
        }
    }

    public void Reset()
    {
        currentHitStreak = 0;
        PlayerPrefs.SetInt("CurrentHitStreak", currentHitStreak);
        currentHitStreakText.SetText(currentHitStreak.ToString());
    }
}
