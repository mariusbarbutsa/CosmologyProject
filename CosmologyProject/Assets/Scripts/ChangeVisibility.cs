using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeVisibility : MonoBehaviour
{

    public GameObject miniPlanets;
    public GameObject uiContent01;
    public PlanetTag planetTag;
    public float fadeInTime;
    public CanvasGroup container;
    public GameObject onlyPlanets;
    public float yPosition;
    public float moveDuration;
    private Vector3 originalPosition;
    public GameObject UIPlanet;

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

        originalPosition = onlyPlanets.transform.position;
    }

    void OnDestroy()
    {
        GameManager.Instance.planetChange -= ChangeVisibilityPlanets;
    }


    private void ChangeVisibilityPlanets()
    {
        if (GameManager.Instance.activePlanet != PlanetTag.None)
        {
            //Debug.Log("MiniPlanets are visible");
            UIPlanet.SetActive(true);
            miniPlanets.SetActive(true);
            uiContent01.SetActive(true);
            // Start the coroutine to move the miniPlanets back to their original position
            StartCoroutine(MoveMiniPlanets(yPosition));
            StartCoroutine(FadeInContainer(fadeInTime));
        }
        else
        {
            UIPlanet.SetActive(false);
            miniPlanets.SetActive(false);
            uiContent01.SetActive(false);
            ResetPositionMiniPlanets();

        }
    }

    private IEnumerator MoveMiniPlanets(float yPosition)
    {
        // Store the original position of the Planets GameObject
        Vector3 originalPosition = onlyPlanets.transform.position;

        // Calculate the target position
        Vector3 targetPosition = new Vector3(originalPosition.x, yPosition, originalPosition.z);

        // Move the miniPlanets GameObject over time
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime / moveDuration;
            Vector3 newPosition = Vector3.Lerp(originalPosition, targetPosition, t);
            onlyPlanets.transform.position = newPosition;
            yield return null;
        }
        //Debug.Log(yPosition);
    }

    private void ResetPositionMiniPlanets()

    {
        onlyPlanets.transform.position = originalPosition;
    }

    IEnumerator FadeInContainer(float fadeInTime)
    {
        float elapsedTime = 0f;
        while (elapsedTime < 2f)
        {
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeInTime);
            container.alpha = alpha;
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        container.alpha = 1f; // Just in case the lerp doesn't quite reach 1
    }

}
