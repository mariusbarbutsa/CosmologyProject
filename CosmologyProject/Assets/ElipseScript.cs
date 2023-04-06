using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElipseScript : MonoBehaviour
{
    public Transform activeBullets;


    void Start()
    {

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

}


