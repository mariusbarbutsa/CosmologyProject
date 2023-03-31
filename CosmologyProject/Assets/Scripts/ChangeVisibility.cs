using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeVisibility : MonoBehaviour
{

    public GameObject miniPlanets;
    public GameObject uiContent01;
    public PlanetTag planetTag;
    public float fadeInTime = 2f;

    void Start()
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

    private void ChangeVisibilityPlanets()
    {
        Debug.Log("the method works");

        if (GameManager.Instance.activePlanet != PlanetTag.None)
        {
            Debug.Log("MiniPlanets are visible");
            miniPlanets.SetActive(true);
            uiContent01.SetActive(true);
        }
        else
        {
            miniPlanets.SetActive(false);
            uiContent01.SetActive(false);
        }
    }



}
