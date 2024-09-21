using System;
using UnityEngine;

public class ItemInteraction : MonoBehaviour
{
    public Transform[] slotss1;
    public Transform[] slotss2;
    public Transform[] slotss3;

    public Transform[][] allSlots; // مصفوفة تحتوي على جميع السلوتات
    private int currentSlotIndex = 0; // تحديد السلوت الحالية

    public bool[] shouldMoveToSlotGroup1;
    public bool[] shouldMoveToSlotGroup2;
    public bool[] shouldMoveToSlotGroup3;

    void Start()
    {
        // ملء المصفوفة allSlots بالسلوتات من slotss1 و slotss2 و slotss3
        allSlots = new Transform[][] { slotss1, slotss2, slotss3 };

        // تهيئة متغيرات التحكم بالانتقال
        shouldMoveToSlotGroup1 = new bool[slotss1.Length];
        shouldMoveToSlotGroup2 = new bool[slotss2.Length];
        shouldMoveToSlotGroup3 = new bool[slotss3.Length];

        // تعيين قيم افتراضية لجميع المصفوفات
        Array.Fill(shouldMoveToSlotGroup1, true);
        Array.Fill(shouldMoveToSlotGroup2, true);
        Array.Fill(shouldMoveToSlotGroup3, true);

        // إذا كان هناك فتحة فارغة في slotss1، نضع العنصر الحالي داخلها
        if (slotss1.Length > 0)
        {
            foreach (Transform slot in slotss1)
            {
                // التأكد من أن الفتحة فارغة
                if (slot.childCount == 0)
                {
                    // نقل العنصر إلى الفتحة الفارغة في slotss1
                    transform.SetParent(slot);
                    transform.localPosition = Vector3.zero;
                    break;
                }
            }
        }
    }

    public void OnClickii()
    {
        // Determine the next slot group index
        int nextSlotGroupIndex = (currentSlotIndex + 1) % allSlots.Length;

        // Get the appropriate boolean array based on the next slot group index
        bool[] shouldMoveToNextSlotGroup = null;
        switch (nextSlotGroupIndex)
        {
            case 0:
                shouldMoveToNextSlotGroup = shouldMoveToSlotGroup1;
                break;
            case 1:
                shouldMoveToNextSlotGroup = shouldMoveToSlotGroup2;
                break;
            case 2:
                shouldMoveToNextSlotGroup = shouldMoveToSlotGroup3;
                break;
            // Add additional cases if needed for more slot groups
            default:
                Debug.LogError("Invalid next slot group index!");
                return;
        }

        // Check if there are any available and visible empty slots in the next slot group
        bool foundEmptySlot = false;
        for (int i = 0; i < shouldMoveToNextSlotGroup.Length; i++)
        {
            // Check if the slot is empty, visible, and flagged for moving
            if (shouldMoveToNextSlotGroup[i] && allSlots[nextSlotGroupIndex][i].childCount == 0 &&
                allSlots[nextSlotGroupIndex][i].gameObject.GetComponent<Renderer>() != null &&
                allSlots[nextSlotGroupIndex][i].gameObject.GetComponent<Renderer>().isVisible)
            {
                // Move the item to the empty slot
                transform.SetParent(allSlots[nextSlotGroupIndex][i]);
                transform.localPosition = Vector3.zero;
                foundEmptySlot = true;
                break;
            }
        }

        // If no empty slots were found in the next slot group, log a message
        if (!foundEmptySlot)
        {
            Debug.Log("No visible empty slot in the next slot group!");
        }

        // Update the current slot group index
        currentSlotIndex = nextSlotGroupIndex;
    }
}
