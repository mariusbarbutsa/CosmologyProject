using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(TouchTest))]
public class Molecule : MonoBehaviour
{
    public MoleculeType myType;
    public bool isSnapping = false;
    public Vector3 originalPosition;
    public GameObject Composite;

    private TouchTest touchInput;
    private QuizTarget myTarget;

    void Awake()
    {
        touchInput = GetComponent<TouchTest>();
        originalPosition = transform.position;
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


    public void TransformOrigin()
    {
        transform.position = originalPosition;
    }
}



public enum MoleculeType
{
    None,
    Bromine,
    Hydrogen,
    Oxygen,
    Methane,
    CO2,
    Nitrogen,
    Helium,
    Ammonia
}