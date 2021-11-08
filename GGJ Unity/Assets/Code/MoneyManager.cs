using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager Instance;
    [SerializeField] TextMeshProUGUI moneyText;
    [SerializeField] GameObject zero1;
    [SerializeField] GameObject zero2;

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
            AddMoney(.50f);
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

        //if (amountOfMoney >= 1f)
        //{
        //    zero1.SetActive(false);
        //    zero2.SetActive(false);
        //}
        //else if (amountOfMoney >= .1f)
        //{
        //    zero1.SetActive(false);
        //    zero2.SetActive(true);
        //}
        //else
        //{
        //    zero1.SetActive(true);
        //    zero2.SetActive(true);
        //}
    }
}
