using UnityEngine;

public class ZoomInScript : MonoBehaviour
{
    private Camera mainCamera;
    private Canvas canvas;
    private float zoomFactor = 2.0f;

    void Start()
    {
        mainCamera = Camera.main;
        canvas = GetComponentInParent<Canvas>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Input.mousePosition;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, mousePosition, canvas.worldCamera, out Vector2 localPoint);

            if (GetComponent<RectTransform>().rect.Contains(localPoint))
            {
                ZoomIn();
            }
        }
    }

    void ZoomIn()
    {
        mainCamera.orthographicSize /= zoomFactor;
    }
}
