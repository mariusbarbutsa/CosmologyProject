using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public PlanetTag activePlanet = PlanetTag.None;
    public BulletList activeBullet = BulletList.None;

    public delegate void PlanetChange();
    public PlanetChange planetChange;

    public delegate void BulletChange();
    public BulletChange bulletChange;
    public static GameManager Instance;
    public Transform infoList;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        SetActiveInfoScreen();
    }


    public void ChangePlanet(PlanetTag tag)
    {
        activePlanet = tag;
        if (planetChange != null)
        {
            planetChange();
        }
    }

    public void ChangeBullet(BulletList tag)
    {
        activeBullet = tag;
        if (bulletChange != null)
        {
            bulletChange();
        }
    }

    public void SetActiveInfoScreen()
    {
        for (int i = 0; i < infoList.childCount; i++)
        {
            if (infoList.GetChild(i).gameObject.tag == GameManager.Instance.activePlanet.ToString())
            {
                Debug.Log("something");
                for (int j = 0; j < infoList.GetChild(i).childCount; j++)
                {
                    Debug.Log("this is= " + infoList.GetChild(i).GetChild(j).gameObject.tag == activeBullet.ToString());
                    if (infoList.GetChild(i).GetChild(j).gameObject.tag == activeBullet.ToString())
                    {
                        infoList.GetChild(i).GetChild(j).gameObject.SetActive(true);
                    }
                    else
                    {
                        infoList.GetChild(i).GetChild(j).gameObject.SetActive(false);
                    }
                }

            }
            else
            {
                for (int j = 0; j < infoList.GetChild(i).childCount; j++)
                {
                    if (infoList.GetChild(i).GetChild(j).gameObject.tag == activeBullet.ToString())
                    {
                        infoList.GetChild(i).GetChild(j).gameObject.SetActive(false);
                    }
                }
            }
        }
    }

}

public enum PlanetTag
{
    Mercury,
    Venus,
    Earth,
    Mars,
    Jupiter,
    Saturn,
    Uranus,
    Neptune,
    None
}

public enum BulletList
{
    FirstBullet,
    SecondBullet,
    ThirdBullet,
    FourthBullet,
    FifthBullet,
    None
}