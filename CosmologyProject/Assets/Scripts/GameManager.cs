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
        if (activeBullet != null)
        {
            bulletChange();
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