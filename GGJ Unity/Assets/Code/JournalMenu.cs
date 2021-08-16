using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JournalMenu : MonoBehaviour
{
    public static JournalMenu Instance;
    [SerializeField] Button container;

    void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        container.onClick.AddListener(Deactivate);
    }

    private void OnDisable()
    {
        container.onClick.RemoveListener(Deactivate);
    }

    public void Activate()
    {
        container.gameObject.SetActive(true);
    }

    void Deactivate()
    {
        PauseMenu.Instance.Resume();
        container.gameObject.SetActive(false);
    }
}
