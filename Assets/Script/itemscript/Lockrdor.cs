using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lockrdor : MonoBehaviour
{
    public Dorlock dorlock; // Reference to the MaskLock script
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
        if (dorlock.CanChangeNumbers)
        {
            RotateSprite();
        }
    }

    private void RotateSprite()
    {
        dorlock.currentIndividualIndex[slotIndex]++;
        Sprite[] currentSprites = dorlock.GetNumberSpritesForIndex(slotIndex);
        if (dorlock.currentIndividualIndex[slotIndex] >= currentSprites.Length)
        {
            dorlock.currentIndividualIndex[slotIndex] = 0;
        }

        UpdateSprite();
    }

    private void UpdateSprite()
    {
        Sprite[] currentSprites = dorlock.GetNumberSpritesForIndex(slotIndex);
        if (currentSprites != null && dorlock.currentIndividualIndex[slotIndex] < currentSprites.Length)
        {
            GetComponent<SpriteRenderer>().sprite = currentSprites[dorlock.currentIndividualIndex[slotIndex]];
        }
        else
        {
            Debug.LogError("Invalid index for NumberSprites array at slotIndex " + slotIndex);
        }
    }

    private void OnEnable()
    {
        // Subscribe to the locker unlocked event
        Dorlock.OnLockerUnlocked += HandleLockerUnlocked;
    }

    private void OnDisable()
    {
        // Unsubscribe from the locker unlocked event
        Dorlock.OnLockerUnlocked -= HandleLockerUnlocked;
    }

    // Handle the event
    private void HandleLockerUnlocked()
    {
        Debug.Log("Locker is unlocked! Perform actions here.");




    }
}
