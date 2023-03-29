using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public PlanetTag activePlanet = PlanetTag.None;

    public delegate void PlanetChange();
    public PlanetChange planetChange;

    public static GameManager Instance;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
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