using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class TapOnBullet : MonoBehaviour, IPointerClickHandler
{

    public BulletList bulletTag;
    public Transform transformList;
    public GameObject BulletAttached;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!CompareTag(GameManager.Instance.activeBullet.ToString()))
        {
            for (int i = 0; i < transformList.childCount; i++)
            {
                if (transformList.GetChild(i).CompareTag(bulletTag.ToString()))
                {
                    //transformList.GetChild(i).gameObject.SetActive(true);
                }
                else
                {
                    //transformList.GetChild(i).gameObject.SetActive(false);
                }
            }

            GameManager.Instance.ChangeBullet(bulletTag);
        }
        else if (CompareTag(GameManager.Instance.activeBullet.ToString()))
        {
            GameManager.Instance.ChangeBullet(BulletList.None);

            for (int i = 0; i < transformList.childCount; i++)
            {
                //transformList.GetChild(i).gameObject.SetActive(true);
            }
        }
    }


}
