using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class TapOnBullet : MonoBehaviour, IPointerClickHandler
{
    private PlanetTag planetTag;
    public BulletList bulletTag;
    public Transform transformList;
    public GameObject BulletAttached;
    public GameObject rotatingCircle;
    public float duration;
    public AnimationCurve animationCurve;


    public void OnPointerClick(PointerEventData eventData)
    {

        GameManager.Instance.ChangeBullet(bulletTag);
        StartCoroutine(RotateCircleOverTime(duration, animationCurve));

        for (int i = 0; i < transformList.childCount; i++)
        {
            if (transformList.GetChild(i).gameObject.tag == GameManager.Instance.activePlanet.ToString())
            //if (GameManager.Instance.activePlanet == PlanetTag.Mars)
            {
                for (int j = 0; j < transformList.GetChild(i).childCount; j++)
                {
                    if (transformList.GetChild(i).GetChild(j).CompareTag(bulletTag.ToString()))
                    {
                        transformList.GetChild(i).GetChild(j).gameObject.SetActive(true);
                    }
                    else
                    {
                        transformList.GetChild(i).GetChild(j).gameObject.SetActive(false);
                    }
                }

            }
            else
            {
                for (int j = 0; j < transformList.GetChild(i).childCount; j++)
                {
                    if (transformList.GetChild(i).GetChild(j).CompareTag(bulletTag.ToString()))
                    {
                        transformList.GetChild(i).GetChild(j).gameObject.SetActive(false);
                    }
                }
            }
        }


    }

    public IEnumerator RotateCircleOverTime(float duration, AnimationCurve animationCurve)
    {
        float timeElapsed = 0f;
        Vector3 initialRotation = rotatingCircle.transform.rotation.eulerAngles;
        Vector3 targetRotation = initialRotation;

        if (GameManager.Instance.activeBullet == BulletList.SecondBullet)
        {
            targetRotation.z = 50f;
        }
        else if (GameManager.Instance.activeBullet == BulletList.ThirdBullet)
        {
            targetRotation.z = 70f;
        }
        else if (GameManager.Instance.activeBullet == BulletList.FourthBullet)
        {
            targetRotation.z = 90f;
        }
        else if (GameManager.Instance.activeBullet == BulletList.FifthBullet)
        {
            targetRotation.z = 110f;
        }
        else if (GameManager.Instance.activeBullet == BulletList.FirstBullet)
        {
            targetRotation.z = 30f;
        }

        while (timeElapsed < duration)
        {
            float t = timeElapsed / duration;
            t = animationCurve.Evaluate(t);
            Vector3 currentRotation = Vector3.Lerp(initialRotation, targetRotation, t);
            rotatingCircle.transform.rotation = Quaternion.Euler(currentRotation);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        rotatingCircle.transform.rotation = Quaternion.Euler(targetRotation);
    }


}
