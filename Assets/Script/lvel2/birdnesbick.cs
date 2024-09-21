using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdnesbick : MonoBehaviour
{
    public Transform[] specificSlots;
    public GameObject bipr1; // هذا المتغير يظهر في الإنسبكتور
    public GameObject myGameObject1;
    public GameObject myGameObject2;
    public Vector3 newSize = new Vector3(1f, 1f, 0f);
    private bool itemMoved = false;

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
                Destroy(gameObject);
                myGameObject1.SetActive(true);

                bipr1.SetActive(true);
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

                    myGameObject2.SetActive(true);
                }
                else
                {
                    Debug.LogError("GameObject 'bipr1' not assigned in the inspector.");
                }

                // انهاء الحلقة بمجرد نقل العنصر
                break;
            }
        }
    }
}
