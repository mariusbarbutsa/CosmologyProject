using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeVisibility : MonoBehaviour
{

    public GameObject miniPlanets;



    void Awake()
    {
        GameManager.Instance.planetChange += ChangeVisibilityPlanets;
    }

    void OnDestroy()
    {
        GameManager.Instance.planetChange -= ChangeVisibilityPlanets;
    }

    void OnEnable()
    {

    }

    void OnDisable()
    {
        GameManager.Instance.planetChange += ChangeVisibilityPlanets;
    }

    private void ChangeVisibilityPlanets()
    {
        Debug.Log("noppeeee!");
        miniPlanets.SetActive(true);
    }
}
