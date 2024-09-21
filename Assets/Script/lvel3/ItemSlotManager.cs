using UnityEngine;

public class ItemSlotManager : MonoBehaviour
{
    private GameObject selectedItem; // العنصر المحدد
    public Transform[] slots; // مصفوفة من الفتحات

    void Update()
    {
        // افحص إذا تم النقر على زر الماوس الأيسر
        if (Input.GetMouseButtonDown(0))
        {
            // راجع الكائن المحدد بواسطة إطلاق الأشعة
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // إذا كان هناك تصادم مع الكائن
            if (Physics.Raycast(ray, out hit))
            {
                // التأكد من أن الكائن المصطدم هو كائن العنصر
                if (hit.collider.CompareTag("Item"))
                {
                    // جعل العنصر المحدد يساوي الكائن المصطدم
                    selectedItem = hit.collider.gameObject;

                    // ابحث عن أول فتحة فارغة وقم بوضع العنصر فيها
                    foreach (Transform slot in slots)
                    {
                        if (slot.childCount == 0)
                        {
                            selectedItem.transform.parent = slot;
                            selectedItem.transform.localPosition = Vector3.zero;
                            break;
                        }
                    }
                }
            }
        }
    }
}
