using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(TouchTest))]
public class Molecule : MonoBehaviour
{
    public MoleculeType myType;
    public bool isSnapping = false;

    private TouchTest touchInput;
    private QuizTarget myTarget;

    void Awake()
    {
        touchInput = GetComponent<TouchTest>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (!isSnapping)
        {
            if (other.CompareTag("Trigger zone"))
            {
                QuizTarget target = other.GetComponent<QuizTarget>();
                if (target != null)
                {
                    if (target.assignedMolecule == MoleculeType.None)
                    {
                        target.assignedMolecule = myType;
                        myTarget = target;
                        isSnapping = true;
                        transform.position = other.transform.position;
                        touchInput.isTouching = false;
                    }
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Trigger zone"))
        {
            QuizTarget target = other.GetComponent<QuizTarget>();
            if (target != null)
            {
                if (target == myTarget)
                {
                    target.assignedMolecule = MoleculeType.None;
                    myTarget = null;
                    isSnapping = false;
                }
            }
        }
    }
}

public enum MoleculeType
{
    None,
    Bromium,
    Hydrogen,
    Oxygen,
    Methan,
    CO2,
    Nitrogen,
    Helium,
    Ammonia
}