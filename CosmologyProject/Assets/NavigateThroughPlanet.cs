using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NavigateThroughPlanet : MonoBehaviour
{
    public PlanetTag planetTag;
    public float animationDuration = 1.0f;
    public float scaleSize;
    public float xPosition;
    public float yPosition;
    TapOnPlanet TapOnPlanet = new TapOnPlanet();
    public Transform transformList;


    void Start()
    {

    }

    void Awake()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.planetChange += MakeActiveBigger;
        }
        else
        {
            Debug.LogError("GameManager.Instance is null");
        }
    }

    void OnDestroy()
    {
        GameManager.Instance.planetChange -= MakeActiveBigger;
    }

    void OnEnable()
    {

    }

    void OnDisable()
    {

    }

    private void MakeActiveBigger()
    {
        Debug.Log("navigate works");

        for (int i = 0; i < transformList.childCount; i++)
        {
            if (transformList.GetChild(i).CompareTag(GameManager.Instance.activePlanet.ToString()))
            {
                TapOnPlanet.ScaleAndChangePosition(scaleSize, xPosition, yPosition);
            }


        }
    }
}
