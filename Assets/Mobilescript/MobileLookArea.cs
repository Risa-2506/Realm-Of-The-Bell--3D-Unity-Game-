using UnityEngine;
using UnityEngine.EventSystems;

public class MobileLookArea : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public Vector2 lookDelta;
    //public float sensitivity = 0.2f;
    /*#if UNITY_EDITOR
        public float sensitivity = 1f;
    #else
        public float sensitivity = 0.12f;
    #endif*/

    /*#if UNITY_EDITOR
        public float sensitivity = 0.2f;
    #else
    public float sensitivity = 0.1f;
    #endif*/

#if UNITY_EDITOR
    public float sensitivityX = 0.2f;
    public float sensitivityY = 0.2f;
#else
public float sensitivityX = 0.24f;
public float sensitivityY = 0.14f;
#endif

    private Vector2 lastPos;
    private bool dragging;

    /*public void OnPointerDown(PointerEventData eventData)
    {
        dragging = true;
        lastPos = eventData.position;
    }*/

    public void OnPointerDown(PointerEventData eventData)
    {
        dragging = true;
        lastPos = eventData.position;

        lookDelta = Vector2.zero; // 🔥 add this line
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!dragging) return;

        Vector2 currentPos = eventData.position;
        Vector2 delta = currentPos - lastPos;
        lastPos = currentPos;

        float speed = delta.magnitude;
        float accel = Mathf.Clamp(speed * 0.020f, 1f, 3f);
        //lookDelta = new Vector2(delta.x, -delta.y) * sensitivity;
        lookDelta = new Vector2(
    delta.x * sensitivityX,
    -delta.y * sensitivityY);


    }
    /*public void OnDrag(PointerEventData eventData)
    {
        if (!dragging) return;

        Vector2 currentPos = eventData.position;
        Vector2 delta = currentPos - lastPos;
        lastPos = currentPos;

        // Normalize for screen size
        Vector2 normalizedDelta = new Vector2(
            delta.x / Screen.width,
            delta.y / Screen.height
        );

        // Apply sensitivity (NO deltaTime here ❗)
        lookDelta = new Vector2(
            normalizedDelta.x,
            -normalizedDelta.y
        ) * sensitivity * 100f;
    }*/
    public void OnPointerUp(PointerEventData eventData)
    {
        dragging = false;
        lookDelta = Vector2.zero;
    }
}
