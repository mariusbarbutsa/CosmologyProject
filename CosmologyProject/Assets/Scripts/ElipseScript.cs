using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElipseScript : MonoBehaviour
{
    public Transform activeBullets;
    public float duration;
    public AnimationCurve animationCurve;
    private Quaternion originalRotation;



    void Start()
    {
        originalRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        ActiveBullet();
        //RotateCircle();
    }

    public void ActiveBullet()
    {
        for (int i = 0; i < activeBullets.childCount; i++)
        {
            if (activeBullets.GetChild(i).gameObject.tag == GameManager.Instance.activeBullet.ToString())

            {
                for (int j = 0; j < activeBullets.GetChild(i).childCount; j++)
                {
                    if (activeBullets.GetChild(i).GetChild(j).gameObject.tag == "ActiveBullet")
                    {
                        activeBullets.GetChild(i).GetChild(j).gameObject.SetActive(true);
                    }
                    else
                    {
                        activeBullets.GetChild(i).GetChild(j).gameObject.SetActive(false);
                    }

                }
            }
            else
            {
                for (int j = 0; j < activeBullets.GetChild(i).childCount; j++)
                {
                    if (activeBullets.GetChild(i).GetChild(j).gameObject.tag == "ActiveBullet")
                    {
                        activeBullets.GetChild(i).GetChild(j).gameObject.SetActive(false);
                    }
                    else
                    {
                        activeBullets.GetChild(i).GetChild(j).gameObject.SetActive(true);
                    }
                }
            }

        }
    }

    /*public void RotateCircle()
    {
        if (GameManager.Instance.activeBullet == BulletList.SecondBullet)
        {
            Vector3 currentRotation = rotatingCircle.transform.rotation.eulerAngles;
            currentRotation.z = 50f;
            rotatingCircle.transform.rotation = Quaternion.Euler(currentRotation);
        }

        else if (GameManager.Instance.activeBullet == BulletList.ThirdBullet)
        {
            Vector3 currentRotation = rotatingCircle.transform.rotation.eulerAngles;
            currentRotation.z = 70f;
            rotatingCircle.transform.rotation = Quaternion.Euler(currentRotation);
        }
        else if (GameManager.Instance.activeBullet == BulletList.FourthBullet)
        {
            Vector3 currentRotation = rotatingCircle.transform.rotation.eulerAngles;
            currentRotation.z = 90f;
            rotatingCircle.transform.rotation = Quaternion.Euler(currentRotation);
        }
        else if (GameManager.Instance.activeBullet == BulletList.FifthBullet)
        {
            Vector3 currentRotation = rotatingCircle.transform.rotation.eulerAngles;
            currentRotation.z = 110f;
            rotatingCircle.transform.rotation = Quaternion.Euler(currentRotation);
        }
        else if (GameManager.Instance.activeBullet == BulletList.FirstBullet)
        {
            Vector3 currentRotation = rotatingCircle.transform.rotation.eulerAngles;
            currentRotation.z = 30f;
            rotatingCircle.transform.rotation = Quaternion.Euler(currentRotation);
        }
    } */

    public IEnumerator RotateCircleOverTime(float duration, AnimationCurve animationCurve)
    {
        float timeElapsed = 0f;
        Vector3 initialRotation = transform.rotation.eulerAngles;
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
            transform.rotation = Quaternion.Euler(currentRotation);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        transform.rotation = Quaternion.Euler(targetRotation);
    }




    public void ResetEllipsePosition()
    {
        transform.rotation = originalRotation;
    }

}


