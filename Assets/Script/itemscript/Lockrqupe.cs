using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Lockrqupe : MonoBehaviour
{
    public Qupelock qupelock; // Reference to the MaskLock script
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
        if (qupelock.CanChangeNumbers)
        {
            RotateSprite();
        }
    }

    private void RotateSprite()
    {
        qupelock.currentIndividualIndex[slotIndex]++;
        Sprite[] currentSprites = qupelock.GetNumberSpritesForIndex(slotIndex);
        if (qupelock.currentIndividualIndex[slotIndex] >= currentSprites.Length)
        {
            qupelock.currentIndividualIndex[slotIndex] = 0;
        }

        UpdateSprite();
    }

    private void UpdateSprite()
    {
        Sprite[] currentSprites = qupelock.GetNumberSpritesForIndex(slotIndex);
        if (currentSprites != null && qupelock.currentIndividualIndex[slotIndex] < currentSprites.Length)
        {
            GetComponent<SpriteRenderer>().sprite = currentSprites[qupelock.currentIndividualIndex[slotIndex]];
        }
        else
        {
            Debug.LogError("Invalid index for NumberSprites array at slotIndex " + slotIndex);
        }
    }

    private void OnEnable()
    {
        // Subscribe to the locker unlocked event
        Qupelock.OnLockerUnlocked += HandleLockerUnlocked;
    }

    private void OnDisable()
    {
        // Unsubscribe from the locker unlocked event
        Qupelock.OnLockerUnlocked -= HandleLockerUnlocked;
    }

    // Handle the event
    private void HandleLockerUnlocked()
    {
        Debug.Log("Locker is unlocked! Perform actions here.");
       

      

    }
}
