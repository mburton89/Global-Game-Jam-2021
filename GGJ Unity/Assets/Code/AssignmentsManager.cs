using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignmentsManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _assignments;
    public GameObject currentAssignment;

    void Start()
    {
        ChooseRandomAssigment();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChooseRandomAssigment()
    {
        int rand = Random.Range(0, _assignments.Count);

        currentAssignment = _assignments[rand];
    }
}
