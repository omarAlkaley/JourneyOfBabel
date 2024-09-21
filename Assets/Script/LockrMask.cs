using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockrMask : MonoBehaviour
{
    public MaskLock maskLock; // Reference to the MaskLock script
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
        if (maskLock.CanChangeNumbers)
        {
            RotateSprite();
        }
    }

    private void RotateSprite()
    {
        maskLock.currentIndividualIndex[slotIndex]++;
        Sprite[] currentSprites = maskLock.GetNumberSpritesForIndex(slotIndex);
        if (maskLock.currentIndividualIndex[slotIndex] >= currentSprites.Length)
        {
            maskLock.currentIndividualIndex[slotIndex] = 0;
        }

        UpdateSprite();
    }

    private void UpdateSprite()
    {
        Sprite[] currentSprites = maskLock.GetNumberSpritesForIndex(slotIndex);
        if (currentSprites != null && maskLock.currentIndividualIndex[slotIndex] < currentSprites.Length)
        {
            GetComponent<SpriteRenderer>().sprite = currentSprites[maskLock.currentIndividualIndex[slotIndex]];
        }
        else
        {
            Debug.LogError("Invalid index for NumberSprites array at slotIndex " + slotIndex);
        }
    }

    private void OnEnable()
    {
        // Subscribe to the locker unlocked event
        MaskLock.OnLockerUnlocked += HandleLockerUnlocked;
    }

    private void OnDisable()
    {
        // Unsubscribe from the locker unlocked event
        MaskLock.OnLockerUnlocked -= HandleLockerUnlocked;
    }

    // Handle the event
    private void HandleLockerUnlocked()
    {
        Debug.Log("Locker is unlocked! Perform actions here.");
        
    }
}
