using UnityEngine;
using static Unity.VisualScripting.Member;

public class LockerNumber : MonoBehaviour
{
    public NumberLock numberLock; // Reference to the NumberLock script
    public int slotIndex; // Index of the slot associated with this LockerNumber
    public AudioClip incorrect;
    public AudioSource source;

    private void Start()
    {
        UpdateSprite();
    }

    private void OnMouseDown()
    {
        source.clip = incorrect;
        source.Play();
        if (numberLock.CanChangeNumbers)
        {
            RotateSprite();
        }
    }

    private void RotateSprite()
    {
        numberLock.currentIndividualIndex[slotIndex]++;
        Sprite[] currentSprites = numberLock.GetNumberSpritesForIndex(slotIndex);
        if (numberLock.currentIndividualIndex[slotIndex] >= currentSprites.Length)
        {
            numberLock.currentIndividualIndex[slotIndex] = 0;
        }

        UpdateSprite();
    }

    private void UpdateSprite()
    {
        Sprite[] currentSprites = numberLock.GetNumberSpritesForIndex(slotIndex);
        GetComponent<SpriteRenderer>().sprite = currentSprites[numberLock.currentIndividualIndex[slotIndex]];
    }

    private void OnEnable()
    {
        // اشتراك في حدث فتح القفل
        NumberLock.OnLockerUnlocked += HandleLockerUnlocked;
    }

    private void OnDisable()
    {
        // إلغاء اشتراك في حدث فتح القفل
        NumberLock.OnLockerUnlocked -= HandleLockerUnlocked;
    }

    // التعامل مع الحدث
    private void HandleLockerUnlocked()
    {
        Debug.Log("تم فتح القفل! قم بتنفيذ الإجراءات هنا.");
        Destroy(source.gameObject);
        
    }
}