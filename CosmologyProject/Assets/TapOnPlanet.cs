using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class TapOnPlanet : MonoBehaviour, IPointerClickHandler
{
    // The duration of the scale animation
    public float animationDuration = 1.0f;
    public float scaleSize;
    public float xPosition;
    public float yPosition;
    public PlanetTag planetTag;
    public Transform transformList;
    public GameObject miniPlanets;


    // The animation curve to use for the scale animation
    public AnimationCurve animationCurve;

    // Function that scales the object and changes its position with an animation curve
    public void ScaleAndChangePosition(float scaleSize, float xPosition, float yPosition)
    {
        // Get the current scale of the object
        Vector3 currentScale = transform.localScale;

        // Calculate the target scale based on the scaleSize parameter
        Vector3 targetScale = currentScale + Vector3.one * scaleSize;

        // Calculate the target position based on the x and y position parameters
        Vector3 targetPosition = new Vector3(xPosition, yPosition, transform.position.z);

        // Start a coroutine to smoothly scale the object over time
        StartCoroutine(ScaleAndMoveOverTime(targetScale, targetPosition, animationDuration));
    }

    // Coroutine that scales the object and changes its position over time
    private IEnumerator ScaleAndMoveOverTime(Vector3 targetScale, Vector3 targetPosition, float duration)
    {
        Vector3 startPosition = transform.position;
        Vector3 startScale = transform.localScale;
        float elapsedTime = 0.0f;

        while (elapsedTime < duration)
        {
            // Calculate the current time based on the animation curve
            float normalizedTime = Mathf.Clamp01(elapsedTime / duration);
            float curveValue = animationCurve.Evaluate(normalizedTime);

            // Calculate the current scale and position based on the animation curve
            Vector3 currentScale = Vector3.Lerp(startScale, targetScale, curveValue);
            Vector3 currentPosition = Vector3.Lerp(startPosition, targetPosition, curveValue);

            // Update the scale and position of the object
            transform.localScale = currentScale;
            transform.position = currentPosition;

            // Wait for the next frame
            yield return null;

            // Increment the elapsed time
            elapsedTime += Time.deltaTime;
        }

        // Set the final scale and position of the object
        transform.localScale = targetScale;
        transform.position = targetPosition;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("clicked");
        GameManager.Instance.ChangePlanet(planetTag);

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

        if (transform.localScale.x == 0.6f)
        {
            ScaleAndChangePosition(scaleSize, xPosition, yPosition);
        }

    }



    void Awake()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.planetChange += PrintStuff;
        }
        else
        {
            Debug.LogError("GameManager.Instance is null");
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
