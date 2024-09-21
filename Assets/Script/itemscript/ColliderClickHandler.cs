using UnityEngine;

public class ColliderClickHandler : MonoBehaviour
{
    public float zoomSpeed = 0.1f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // تحديث حجم الكائن المصنف بمعيار CanvasRenderer
                hit.collider.GetComponent<RectTransform>().localScale += new Vector3(zoomSpeed, zoomSpeed, zoomSpeed);
            }
        }
    }

}
