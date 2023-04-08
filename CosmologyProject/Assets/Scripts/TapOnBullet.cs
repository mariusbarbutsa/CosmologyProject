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
    public Transform infoScreen;
    public GameObject BulletAttached;
    public GameObject rotatingCircle;
    public ElipseScript elipseScript;
    public float duration;
    public AnimationCurve animationCurve;
    public AudioClip snapSound;
    private AudioSource audioSource;
    public AudioManager audioManager;


    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        audioManager.PlaySFX("ChangeBulletSound");
        GameManager.Instance.ChangeBullet(bulletTag);
        elipseScript.StartCoroutine(elipseScript.RotateCircleOverTime(duration, animationCurve));

        for (int i = 0; i < infoScreen.childCount; i++)
        {
            if (infoScreen.GetChild(i).gameObject.tag == GameManager.Instance.activePlanet.ToString())
            //if (GameManager.Instance.activePlanet == PlanetTag.Mars)
            {
                for (int j = 0; j < infoScreen.GetChild(i).childCount; j++)
                {
                    if (infoScreen.GetChild(i).GetChild(j).CompareTag(bulletTag.ToString()))
                    {
                        infoScreen.GetChild(i).GetChild(j).gameObject.SetActive(true);
                    }
                    else
                    {
                        infoScreen.GetChild(i).GetChild(j).gameObject.SetActive(false);
                    }
                }

            }
            else
            {
                for (int j = 0; j < infoScreen.GetChild(i).childCount; j++)
                {
                    if (infoScreen.GetChild(i).GetChild(j).CompareTag(bulletTag.ToString()))
                    {
                        infoScreen.GetChild(i).GetChild(j).gameObject.SetActive(false);
                    }
                }
            }
        }


    }

}
