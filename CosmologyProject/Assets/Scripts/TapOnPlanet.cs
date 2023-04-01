using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class TapOnPlanet : MonoBehaviour, IPointerClickHandler
{

    public PlanetTag planetTag;
    public Transform transformList;
    public GameObject miniPlanets;
    private bool executed = false;
    private Quaternion originalRotation;
    public AnimationCurve animationCurve;
    public RotateAround rotateAround;
    public float duration;
    public float xScale;
    public float yScale;
    public float zScale;
    public float xPosition;
    public float yPosition;
    public float zPosition;
    private Vector3 originalScale;
    private Vector3 originalPosition;
    private Vector3 targetScale;
    private Vector3 targetPosition;

    void Start()
    {
        // Record the original scale and position of the object
        originalScale = transform.localScale;
        originalPosition = transform.position;

        if (GameManager.Instance != null)
        {
            GameManager.Instance.planetChange += PrintStuff;
        }
        else
        {
            Debug.LogError("GameManager.Instance is null");
        }
    }

    public void ResetSizesAndPosition()
    {
        transform.localScale = originalScale;
        transform.position = originalPosition;
    }

    public void ChangeScaleAndPosition(float xScale, float yScale, float zScale, float xPosition, float yPosition, float zPosition)
    {
        // Set the target scale and position
        targetScale = new Vector3(xScale, yScale, zScale);
        targetPosition = new Vector3(xPosition, yPosition, zPosition);

        StartCoroutine(ScaleAndMoveObject());
    }

    IEnumerator ScaleAndMoveObject()
    {
        originalScale = transform.localScale;
        originalPosition = transform.position;

        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            transform.localScale = Vector3.Lerp(originalScale, targetScale, t);
            transform.position = Vector3.Lerp(originalPosition, targetPosition, t);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localScale = targetScale;
        transform.position = targetPosition;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("clicked");

        for (int i = 0; i < transformList.childCount; i++)
        {

            if (transformList.GetChild(i).CompareTag(planetTag.ToString()))
            {
                transformList.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                transformList.GetChild(i).gameObject.SetActive(false);
            }

        }

        print(transform.localScale.x);

        if (!executed)
        {
            ChangeScaleAndPosition(xScale, yScale, zScale, xPosition, yPosition, zPosition);
            GameManager.Instance.ChangePlanet(planetTag);

            executed = true;
            rotateAround.enabled = false;

        }
        else
        {
            GameManager.Instance.ChangePlanet(PlanetTag.None);

            ResetSizesAndPosition();
            executed = false;

            for (int i = 0; i < transformList.childCount; i++)
            {
                transformList.GetChild(i).gameObject.SetActive(true);
            }
            rotateAround.enabled = true;
        }

    }



    void OnDestroy()
    {
        GameManager.Instance.planetChange -= PrintStuff;
    }

    void OnEnable()
    {

    }

    void OnDisable()
    {

    }

    private void PrintStuff()
    {
        Debug.Log("Awesomeness!");
        //miniPlanets.SetActive(true);
    }

}
