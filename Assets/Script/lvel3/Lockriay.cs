using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lockriay : MonoBehaviour
{
    public Iaylock iaylock; // Reference to the MaskLock script
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
        if (iaylock.CanChangeNumbers)
        {
            RotateSprite();
        }
    }

    private void RotateSprite()
    {
        iaylock.currentIndividualIndex[slotIndex]++;
        Sprite[] currentSprites = iaylock.GetNumberSpritesForIndex(slotIndex);
        if (iaylock.currentIndividualIndex[slotIndex] >= currentSprites.Length)
        {
            iaylock.currentIndividualIndex[slotIndex] = 0;
        }

        UpdateSprite();
    }

    private void UpdateSprite()
    {
        Sprite[] currentSprites = iaylock.GetNumberSpritesForIndex(slotIndex);
        if (currentSprites != null && iaylock.currentIndividualIndex[slotIndex] < currentSprites.Length)
        {
            GetComponent<SpriteRenderer>().sprite = currentSprites[iaylock.currentIndividualIndex[slotIndex]];
        }
        else
        {
            Debug.LogError("Invalid index for NumberSprites array at slotIndex " + slotIndex);
        }
    }

    private void OnEnable()
    {
        // Subscribe to the locker unlocked event
        Iaylock.OnLockerUnlocked += HandleLockerUnlocked;
    }

    private void OnDisable()
    {
        // Unsubscribe from the locker unlocked event
        Iaylock.OnLockerUnlocked -= HandleLockerUnlocked;
    }

    // Handle the event
    private void HandleLockerUnlocked()
    {
        Debug.Log("Locker is unlocked! Perform actions here.");




    }
}
