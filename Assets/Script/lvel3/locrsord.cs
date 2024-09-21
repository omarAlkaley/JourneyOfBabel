using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class locrsord : MonoBehaviour
{
    public sordlocr sordlocr; // Reference to the MaskLock script
    public int slotIndex; // Index of the slot associated with this LockerNumber
    public AudioClip incorrect;
    public AudioSource source;

    private bool rotateBackward = false;

    private void Start()
    {
        UpdateSprite();
    }

    private void OnMouseDown()
    {
        source.clip = incorrect;
        source.Play();
        if (sordlocr.CanChangeNumbers)
        {
            RotateSprite();
        }
    }

    private void RotateSprite()
    {
        sordlocr.currentIndividualIndex[slotIndex] += rotateBackward ? -1 : 1;
        Sprite[] currentSprites = sordlocr.GetNumberSpritesForIndex(slotIndex);

        if (sordlocr.currentIndividualIndex[slotIndex] >= currentSprites.Length)
        {
            // إذا وصل الفهرس إلى آخر صورة، قم بتعيينه ليكون الصورة الأولى
            sordlocr.currentIndividualIndex[slotIndex] = 0;
        }

        if (sordlocr.currentIndividualIndex[slotIndex] < 0)
        {
            // إذا وصل الفهرس إلى الصورة الأولى من الاتجاه العكسي، قم بتعيينه ليكون آخر صورة
            sordlocr.currentIndividualIndex[slotIndex] = currentSprites.Length - 1;
        }

        UpdateSprite();

        // التبديل بين الاتجاهين عند الوصول إلى أي من الحدود
        if (sordlocr.currentIndividualIndex[slotIndex] == 0 || sordlocr.currentIndividualIndex[slotIndex] == currentSprites.Length - 1)
        {
            rotateBackward = !rotateBackward;
        }
    }




    private void UpdateSprite()
    {
        Sprite[] currentSprites = sordlocr.GetNumberSpritesForIndex(slotIndex);
        if (currentSprites != null && sordlocr.currentIndividualIndex[slotIndex] < currentSprites.Length)
        {
            GetComponent<SpriteRenderer>().sprite = currentSprites[sordlocr.currentIndividualIndex[slotIndex]];
        }
        else
        {
            Debug.LogError("Invalid index for NumberSprites array at slotIndex " + slotIndex);
        }
    }

    private void OnEnable()
    {
        // Subscribe to the locker unlocked event
        sordlocr.OnLockerUnlocked += HandleLockerUnlocked;
    }

    private void OnDisable()
    {
        // Unsubscribe from the locker unlocked event
        sordlocr.OnLockerUnlocked -= HandleLockerUnlocked;
    }

    // Handle the event
    private void HandleLockerUnlocked()
    {
        Debug.Log("Locker is unlocked! Perform actions here.");




    }
}

