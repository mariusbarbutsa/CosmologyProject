using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;


public class NavigateThroughPlanet : MonoBehaviour, IPointerClickHandler
{
    public PlanetTag planetTag;
    public float scaleSize;
    private Vector3 originalScale;
    private Vector3 originalScalePlanet;
    private Vector3 originalPositionPlanet;
    public GameObject activeCircle;
    public Transform transformList;
    public GameObject PlanetToSwitch;
    public float xScale;
    public float yScale;
    public float zScale;
    public float xPosition;
    public float yPosition;
    public float zPosition;
    public bool isExecuted = false;


    void Start()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.planetChange += MakeActiveBigger;
            //Debug.Log("My name is: " + gameObject.name);
        }
        else
        {
            Debug.LogError("GameManager.Instance is null");
        }

        originalScale = transform.localScale;
    }

    void OnDestroy()
    {
        GameManager.Instance.planetChange -= MakeActiveBigger;
    }

    /* void OnEnable()
    {
        MakeActiveBigger();
    } */

    void Update()
    {
        MakeActiveBigger();

    }

    void OnDisable()
    {

    }

    private void MakeActiveBigger()
    {
        //Debug.Log("navigate works");

        if (planetTag == GameManager.Instance.activePlanet)
        {
            ScaleAndChangePosition(scaleSize);
            activeCircle.SetActive(true);
        }
        else
        {
            ResetScaleAndChangePosition();
            activeCircle.SetActive(false);
        }
    }


    public void ScaleAndChangePosition(float scaleSize)
    {
        transform.localScale = originalScale + Vector3.one * scaleSize;
    }

    public void ResetScaleAndChangePosition()
    {
        transform.localScale = originalScale;
    }

    public void OnPointerClick(PointerEventData eventData)
    {


        GameManager.Instance.ChangePlanet(planetTag);
        isExecuted = true;

        TapOnPlanet tapOnPlanet = PlanetToSwitch.GetComponent<TapOnPlanet>();
        Vector3 originalScale = tapOnPlanet.originalScale;
        Vector3 originalPosition = tapOnPlanet.originalPosition;
        originalScalePlanet = originalScale;
        originalPositionPlanet = originalPosition;
        Debug.Log(originalScalePlanet + "and " + originalPositionPlanet);

        Debug.Log("This planet has been clicked");

        for (int i = 0; i < transformList.childCount; i++)
        {

            if (transformList.GetChild(i).CompareTag(GameManager.Instance.activePlanet.ToString()))
            {
                transformList.GetChild(i).gameObject.SetActive(true);
                tapOnPlanet.ChangeScaleAndPosition(xScale, yScale, zScale, xPosition, yPosition, zPosition);
            }
            else
            {
                transformList.GetChild(i).gameObject.SetActive(false);
                //tapOnPlanet.transform.localScale = originalScalePlanet;
                //tapOnPlanet.transform.position = originalPositionPlanet;
                Debug.Log(originalScalePlanet + "and " + originalPositionPlanet);
            }
        }



    }

}
