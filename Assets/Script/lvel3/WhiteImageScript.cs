using UnityEngine;

public class WhiteImageScript : MonoBehaviour
{
    public Transform[] specificSlots;
    public GameObject bipr1; // هذا المتغير يظهر في الإنسبكتور

    public Vector3 newSize = new Vector3(1f, 1f, 0f);
    private bool itemMoved = false;

    // تعطيل السكربت بشكل افتراضي عند البدء
    private void Start()
    {
        enabled = false;
    }

   
    

    private void OnMouseDown()
    {
        if (!itemMoved)
        {
            MoveToEmptySlot();
        }
    }

    private void MoveToEmptySlot()
    {
        foreach (Transform slot in specificSlots)
        {
            if (slot.childCount == 0)
            {
                // نقل العنصر إلى الفتحة الفارغة
                transform.SetParent(slot);
                transform.SetAsLastSibling();
                transform.localPosition = Vector3.zero;

                Renderer renderer = GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.sortingOrder = 6;
                }

                transform.localScale = newSize;

                itemMoved = true;

                // نقل "bipr1" إلى نفس المكان
                if (bipr1 != null)
                {
                    Renderer aliRenderer = bipr1.GetComponent<Renderer>();
                    if (aliRenderer != null)
                    {
                        aliRenderer.sortingOrder = 14;
                    }

                    bipr1.transform.SetParent(slot);
                    bipr1.transform.localPosition = Vector3.zero;
                    bipr1.transform.localScale = newSize;

                }
                else
                {
                    Debug.LogError("GameObject 'bipr1' not assigned in the inspector.");
                }

                // انهاء الحلقة بمجرد نقل العنصر
                break;
            }
        }

        // تعطيل السكربت بمجرد انتهاء الحركة
        // تعطيل السكربت الحالي المرتبط مع هذا الكائن
        enabled = false;

        // تفعيل سكربت الكائن الآخر باستخدام اسمه
        BlackImageScript blackImageScript = GetComponent<BlackImageScript>();
        if (blackImageScript != null)
        {
            blackImageScript.enabled = true;
        }
        else
        {
            Debug.LogError("WhiteImageScript component not found on the GameObject.");
        }
    }
}

