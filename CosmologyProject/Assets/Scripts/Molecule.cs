using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.UI;

[RequireComponent(typeof(TouchTest))]
public class Molecule : MonoBehaviour
{
    public MoleculeType myType;
    public bool isSnapping = false;
    public Vector3 originalPosition;
    private TouchTest touchInput;
    private QuizTarget myTarget;
    public Button buttonToCheck;
    public AudioClip snapSound;
    private AudioSource audioSource;
    public AudioManager audioManager;


    void Awake()
    {
        touchInput = GetComponent<TouchTest>();
    }

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        originalPosition = transform.position;
        buttonToCheck.onClick.AddListener(ResetPosition);
    }

    public void ResetPosition()
    {
        transform.position = originalPosition;
        //Debug.Log("original position 02: " + originalPosition);
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
                        audioManager.PlaySFX("ColliderSound");
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
    Bromine,
    Hydrogen,
    Oxygen,
    Methane,
    CO2,
    Nitrogen,
    Helium,
    Ammonia
}