using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
//using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class TapOnPlanet : MonoBehaviour, IPointerClickHandler
{

    public PlanetTag planetTag;
    public Transform transformList;
    public GameObject miniPlanets;
    public GameObject planet;
    private Quaternion originalRotation;
    public AnimationCurve animationCurve;
    public RotateAround rotateAround;
    public GameObject displayedIntroText;
    public GameObject backButton;
    public float duration;
    public float xScale;
    public float yScale;
    public float zScale;
    public float xPosition;
    public float yPosition;
    public float zPosition;
    public Vector3 originalScale;
    public Vector3 originalPosition;
    private Vector3 targetScale;
    private Vector3 targetPosition;
    private Vector2 lastTouchPos;





    void Start()
    {
        // Record the original scale and position of the object
        originalScale = transform.localScale;
        originalPosition = transform.position;
    }

    void Update()
    {

        if (!CompareTag(GameManager.Instance.activePlanet.ToString()))
        {
            ResetSizesAndPosition();
            Debug.Log("maybe you would work now?!");
        }

        /*// Check for touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                // Save the starting touch position
                lastTouchPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                // Calculate the difference in touch position
                Vector2 deltaPos = touch.position - lastTouchPos;

                // Rotate the object based on the touch movement
                transform.Rotate(Vector3.up, -deltaPos.x * 0.5f, Space.World);
                transform.Rotate(Vector3.right, deltaPos.y * 0.5f, Space.World);

                // Save the new touch position
                lastTouchPos = touch.position;
            }
        }*/
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

    public void ChangeScaleAndPositionDefault(float xScale, float yScale, float zScale, float xPosition, float yPosition, float zPosition)
    {
        targetScale = new Vector3(xScale, yScale, zScale);
        targetPosition = new Vector3(xPosition, yPosition, zPosition);
        transform.localScale = targetScale;
        transform.position = targetPosition;
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
        GameManager.Instance.ChangeBullet(BulletList.FirstBullet);

        if (!CompareTag(GameManager.Instance.activePlanet.ToString()))
        {
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

            ChangeScaleAndPosition(xScale, yScale, zScale, xPosition, yPosition, zPosition);
            GameManager.Instance.ChangePlanet(planetTag);
            //SetActiveInfoScreen();
            //rotateAround.enabled = false;
            displayedIntroText.SetActive(false);
            backButton.SetActive(true);

        }
        else if (CompareTag(GameManager.Instance.activePlanet.ToString()))
        {
            GameManager.Instance.ChangePlanet(PlanetTag.None);
            ResetSizesAndPosition();
            //rotateAround.enabled = true;
            for (int i = 0; i < transformList.childCount; i++)
            {
                transformList.GetChild(i).gameObject.SetActive(true);
            }
        }
    }


}
