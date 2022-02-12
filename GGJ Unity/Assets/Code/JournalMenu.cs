using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JournalMenu : MonoBehaviour
{
    public static JournalMenu Instance;
    [SerializeField] Button overlayButton;

    [SerializeField] Button howToPlayButton;
    [SerializeField] Button itemsButton;
    [SerializeField] Button assignmentsButton;

    [SerializeField] GameObject howToPlayContainer;
    [SerializeField] GameObject itemsContainer;
    [SerializeField] GameObject assignmentsContainer;

    void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        overlayButton.onClick.AddListener(Deactivate);
        howToPlayButton.onClick.AddListener(HandleHowToPlayPressed);
        itemsButton.onClick.AddListener(HandleItemsPressed);
        assignmentsButton.onClick.AddListener(HandleAssignmentsPressed);
    }

    private void OnDisable()
    {
        overlayButton.onClick.RemoveListener(Deactivate);
        howToPlayButton.onClick.RemoveListener(HandleHowToPlayPressed);
        itemsButton.onClick.RemoveListener(HandleItemsPressed);
        assignmentsButton.onClick.RemoveListener(HandleAssignmentsPressed);
    }

    public void Activate()
    {
        overlayButton.gameObject.SetActive(true);
        HandleItemsPressed();
    }

    void Deactivate()
    {
        PauseMenu.Instance.Resume();
        overlayButton.gameObject.SetActive(false);
    }

    void HandleHowToPlayPressed()
    {
        howToPlayButton.transform.SetAsLastSibling();
        itemsButton.transform.SetAsFirstSibling();
        assignmentsButton.transform.SetAsFirstSibling();

        howToPlayContainer.SetActive(true);
        itemsContainer.SetActive(false);
        assignmentsContainer.SetActive(false);
    }

    void HandleItemsPressed()
    {
        howToPlayButton.transform.SetAsFirstSibling();
        itemsButton.transform.SetAsLastSibling();
        assignmentsButton.transform.SetAsFirstSibling();

        howToPlayContainer.SetActive(false);
        itemsContainer.SetActive(true);
        assignmentsContainer.SetActive(false);
    }

    void HandleAssignmentsPressed()
    {
        AssignmentsManager.Instance.DetermineAssignmentStatus();

        howToPlayButton.transform.SetAsFirstSibling();
        itemsButton.transform.SetAsFirstSibling();
        assignmentsButton.transform.SetAsLastSibling();

        howToPlayContainer.SetActive(false);
        itemsContainer.SetActive(false);
        assignmentsContainer.SetActive(true);
    }
}
