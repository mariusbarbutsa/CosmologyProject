using UnityEngine;

public class Draggable : MonoBehaviour
{
    public GameObject snapObject;
    private bool isDragging;
    private Vector3 offset;
    private float zCoord = 0f;
    public float snapDistance = 5f;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPos = new Vector3(touch.position.x, touch.position.y, 0); // set z to 0

            if (touch.phase == TouchPhase.Began)
            {
                zCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
                offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(touchPos);
                isDragging = true;
            }
            else if (touch.phase == TouchPhase.Moved && isDragging)
            {
                transform.position = Camera.main.ScreenToWorldPoint(touchPos) + offset;
                if (Vector3.Distance(transform.position, snapObject.transform.position) <= snapDistance)
                {
                    transform.position = snapObject.transform.position;
                }
            }
            else if (touch.phase == TouchPhase.Ended && isDragging)
            {
                isDragging = false;
                if (Vector3.Distance(transform.position, snapObject.transform.position) <= snapDistance)
                {
                    transform.position = snapObject.transform.position;
                }
            }
        }
    }
}