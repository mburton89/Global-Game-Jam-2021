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

    [HideInInspector] public const string SINGLE_ERASER_ASSIGNMENT = "SingleEraserAssignment";
    [HideInInspector] public const string DOUBLE_SPLODES_ASSIGNMENT = "DoubleSplodeAssignment";
    [HideInInspector] public const string TRIPLE_SHARP_ASSIGNMENT = "TripleSharpAssignment";
    [HideInInspector] public const string QUADROUPLE_DODGEBALL_ASSIGNMENT = "QuadroupleDodgeballAssignment";
    [HideInInspector] public const string HITSTREAK_50_ASSIGNMENT = "Hitstreak50";
    [HideInInspector] public const string HITSTREAK_100_ASSIGNMENT = "Hitstreak100";
    [HideInInspector] public const string WAVE_10_ASSIGNMENT = "Wave10Assignment";
    [HideInInspector] public const string WAVE_20_ASSIGNMENT = "Wave20Assignment";

    [SerializeField] AudioSource assignmentCompleteSound;

    [SerializeField] MeshRenderer aimer1;
    [SerializeField] MeshRenderer aimer2;

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

    private void Start()
    {
        DetermineAssignmentStatus();
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
        if (PlayerPrefs.GetInt(HITSTREAK_50_ASSIGNMENT) != 1)
        {
            PlayerPrefs.SetInt(HITSTREAK_50_ASSIGNMENT, 1);
            assignmentCompleteSound.Play();
            aimer1.enabled = true;
            aimer2.enabled = true;
        }
    }

    public void CompleteHitstreak100Assignment()
    {
        if (PlayerPrefs.GetInt(QUADROUPLE_DODGEBALL_ASSIGNMENT) != 1)
        {
            PlayerPrefs.SetInt(QUADROUPLE_DODGEBALL_ASSIGNMENT, 1);
            assignmentCompleteSound.Play();
            //TODO Add 5th line to aiming
        }
        PlayerPrefs.SetInt(HITSTREAK_100_ASSIGNMENT, 1);
    }

    public void CompleteWave10Assignment()
    {
        if (PlayerPrefs.GetInt(QUADROUPLE_DODGEBALL_ASSIGNMENT) != 1)
        {
            PlayerPrefs.SetInt(QUADROUPLE_DODGEBALL_ASSIGNMENT, 1);
            assignmentCompleteSound.Play();
            //TODO Make Items Sway less
        }
        PlayerPrefs.SetInt(WAVE_10_ASSIGNMENT, 1);
    }

    public void CompleteWave20Assignment()
    {
        if (PlayerPrefs.GetInt(QUADROUPLE_DODGEBALL_ASSIGNMENT) != 1)
        {
            PlayerPrefs.SetInt(QUADROUPLE_DODGEBALL_ASSIGNMENT, 1);
            assignmentCompleteSound.Play();
            //TODO Increase Slingshot Speed
        }
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
            aimer1.enabled = true;
            aimer2.enabled = true;
        }
        if (PlayerPrefs.GetInt(WAVE_20_ASSIGNMENT) == 1)
        {
            wave20Checkmark.SetActive(true);
        }
    }
}
