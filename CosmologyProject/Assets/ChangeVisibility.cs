using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeVisibility : MonoBehaviour
{

    public GameObject miniPlanets;
    public PlanetTag planetTag;

    void Awake()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.planetChange += ChangeVisibilityPlanets;
        }
        else
        {
            Debug.LogError("GameManager.Instance is null");
        }
    }

    void OnDestroy()
    {
        GameManager.Instance.planetChange -= ChangeVisibilityPlanets;
    }

    void OnEnable()
    {
        //GameManager.Instance.planetChange += ChangeVisibilityPlanets;
    }

    void OnDisable()
    {
        //GameManager.Instance.planetChange += ChangeVisibilityPlanets;
    }

    private void ChangeVisibilityPlanets()
    {
        Debug.Log("the method works");

        if (GameManager.Instance.activePlanet != PlanetTag.None)
        {
            Debug.Log("miniplanets are visible");
            miniPlanets.SetActive(false);
        }
    }
}
