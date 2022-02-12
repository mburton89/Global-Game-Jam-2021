using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignmentsManager : MonoBehaviour
{
    public static AssignmentsManager Instance;

    [SerializeField] GameObject singleEraserKillCheckMark;
    [SerializeField] GameObject doubleSplodeKillCheckMark;
    [SerializeField] GameObject tripleSharpKillCheckMark;
    [SerializeField] GameObject quadroupleDodgeballKillCheckMark;
    [SerializeField] GameObject hitstreak50Checkmark;
    [SerializeField] GameObject hitstreak100Checkmark;
    [SerializeField] GameObject wave10Checkmark;
    [SerializeField] GameObject wave20Checkmark;

    const string SINGLE_ERASER_ASSIGNMENT = "SingleEraserAssignment";
    const string DOUBLE_SPLODES_ASSIGNMENT = "DoubleSplodeAssignment";
    const string TRIPLE_SHARP_ASSIGNMENT = "TripleSharpAssignment";
    const string QUADROUPLE_DODGEBALL_ASSIGNMENT = "QuadroupleDodgeballAssignment";
    const string HITSTREAK_50_ASSIGNMENT = "Hitstreak50";
    const string HITSTREAK_100_ASSIGNMENT = "Hitstreak100";
    const string WAVE_10_ASSIGNMENT = "Wave10Assignment";
    const string WAVE_20_ASSIGNMENT = "Wave20Assignment";

    [SerializeField] AudioSource assignmentCompleteSound;

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
        //PlayerPrefs.DeleteAll();
    }

    public void CompleteEraserKillAssignment()
    {
        if (PlayerPrefs.GetInt(SINGLE_ERASER_ASSIGNMENT) != 1)
        {
            PlayerPrefs.SetInt(SINGLE_ERASER_ASSIGNMENT, 1);
            assignmentCompleteSound.Play();
            //TODO Unlock Lucky Eraser
        }
    }

    public void CompleteDoubleSplodeKillAssignment()
    {
        if (PlayerPrefs.GetInt(DOUBLE_SPLODES_ASSIGNMENT) != 1)
        {
            PlayerPrefs.SetInt(DOUBLE_SPLODES_ASSIGNMENT, 1);
            assignmentCompleteSound.Play();
            //TODO Unlock Phat Wallet
        }
    }

    public void CompleteTripleSharpKillAssignment()
    {
        if (PlayerPrefs.GetInt(TRIPLE_SHARP_ASSIGNMENT) != 1)
        {
            PlayerPrefs.SetInt(TRIPLE_SHARP_ASSIGNMENT, 1);
            assignmentCompleteSound.Play();
            //TODO Unlock Pack o Pencils
        }
    }

    public void CompleteQuadroupleDodgeballKillAssignment()
    {
        if (PlayerPrefs.GetInt(QUADROUPLE_DODGEBALL_ASSIGNMENT) != 1)
        {
            PlayerPrefs.SetInt(QUADROUPLE_DODGEBALL_ASSIGNMENT, 1);
            assignmentCompleteSound.Play();
            //TODO Unlock Super Dodgeball
        }
    }

    public void CompleteHitstreak50Assignment()
    {
        PlayerPrefs.SetInt(HITSTREAK_50_ASSIGNMENT, 1);
    }

    public void CompleteHitstreak100Assignment()
    {
        PlayerPrefs.SetInt(HITSTREAK_100_ASSIGNMENT, 1);
    }

    public void CompleteWave10Assignment()
    {
        PlayerPrefs.SetInt(WAVE_10_ASSIGNMENT, 1);
    }

    public void CompleteWave20Assignment()
    {
        PlayerPrefs.SetInt(WAVE_20_ASSIGNMENT, 1);
    }

    public void DetermineAssignmentStatus()
    {
        if (PlayerPrefs.GetInt(SINGLE_ERASER_ASSIGNMENT) == 1)
        {
            singleEraserKillCheckMark.SetActive(true);
        }
        if (PlayerPrefs.GetInt(DOUBLE_SPLODES_ASSIGNMENT) == 1)
        {
            doubleSplodeKillCheckMark.SetActive(true);
        }
        if (PlayerPrefs.GetInt(TRIPLE_SHARP_ASSIGNMENT) == 1)
        {
            tripleSharpKillCheckMark.SetActive(true);
        }
        if (PlayerPrefs.GetInt(QUADROUPLE_DODGEBALL_ASSIGNMENT) == 1)
        {
            quadroupleDodgeballKillCheckMark.SetActive(true);
        }
        if (PlayerPrefs.GetInt(HITSTREAK_50_ASSIGNMENT) == 1)
        {
            hitstreak50Checkmark.SetActive(true);
        }
        if (PlayerPrefs.GetInt(HITSTREAK_100_ASSIGNMENT) == 1)
        {
            hitstreak100Checkmark.SetActive(true);
        }
        if (PlayerPrefs.GetInt(WAVE_10_ASSIGNMENT) == 1)
        {
            wave10Checkmark.SetActive(true);
        }
        if (PlayerPrefs.GetInt(WAVE_20_ASSIGNMENT) == 1)
        {
            wave20Checkmark.SetActive(true);
        }
    }
}
