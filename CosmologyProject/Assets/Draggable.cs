using UnityEngine;

public class Draggable : MonoBehaviour
{
    private bool isDragging;
    private Vector3 offset;
    private float zCoord;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPos = new Vector3(touch.position.x, touch.position.y, zCoord);

            if (touch.phase == TouchPhase.Began)
            {
                zCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
                offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(touchPos);
                isDragging = true;
            }
            else if (touch.phase == TouchPhase.Moved && isDragging)
            {
                transform.position = Camera.main.ScreenToWorldPoint(touchPos) + offset;
            }
            else if (touch.phase == TouchPhase.Ended && isDragging)
            {
                isDragging = false;
            }
        }
    }
}