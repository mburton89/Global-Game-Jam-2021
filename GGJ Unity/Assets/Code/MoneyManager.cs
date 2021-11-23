
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager Instance;
    [SerializeField] TextMeshProUGUI moneyText;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        UpdateUI();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            PlayerPrefs.SetFloat("money", 0f);
            AddMoney(0f);
        }
    }

    public void AddMoney(float moneyToAdd)
    {
        float currentMoney = PlayerPrefs.GetFloat("money");
        PlayerPrefs.SetFloat("money", currentMoney + moneyToAdd);
        UpdateUI();
    }

    public void SubtractMoney(float moneyToSubtract)
    {
        float currentMoney = PlayerPrefs.GetFloat("money");
        if (moneyToSubtract > currentMoney)
        {
            moneyToSubtract = currentMoney;
        }
        PlayerPrefs.SetFloat("money", currentMoney - moneyToSubtract);
        UpdateUI();
    }

    void UpdateUI()
    {
        float amountOfMoney = PlayerPrefs.GetFloat("money");
        moneyText.SetText(amountOfMoney.ToString("C"));
    }
}
