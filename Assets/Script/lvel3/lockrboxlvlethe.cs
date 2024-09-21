using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class lockrboxlvlethe : MonoBehaviour
{
    public Bboxlvlethelock boxlvlethelock; // Reference to the MaskLock script
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
        if (boxlvlethelock.CanChangeNumbers)
        {
            RotateSprite();
        }
    }

    private void RotateSprite()
    {
        boxlvlethelock.currentIndividualIndex[slotIndex]++;
        Sprite[] currentSprites = boxlvlethelock.GetNumberSpritesForIndex(slotIndex);
        if (boxlvlethelock.currentIndividualIndex[slotIndex] >= currentSprites.Length)
        {
            boxlvlethelock.currentIndividualIndex[slotIndex] = 0;
        }

        UpdateSprite();
    }

    private void UpdateSprite()
    {
        Sprite[] currentSprites = boxlvlethelock.GetNumberSpritesForIndex(slotIndex);
        if (currentSprites != null && boxlvlethelock.currentIndividualIndex[slotIndex] < currentSprites.Length)
        {
            GetComponent<SpriteRenderer>().sprite = currentSprites[boxlvlethelock.currentIndividualIndex[slotIndex]];
        }
        else
        {
            Debug.LogError("Invalid index for NumberSprites array at slotIndex " + slotIndex);
        }
    }

    private void OnEnable()
    {
        // Subscribe to the locker unlocked event
        Bboxlvlethelock.OnLockerUnlocked += HandleLockerUnlocked;
    }

    private void OnDisable()
    {
        // Unsubscribe from the locker unlocked event
        Bboxlvlethelock.OnLockerUnlocked -= HandleLockerUnlocked;
    }

    // Handle the event
    private void HandleLockerUnlocked()
    {
        Debug.Log("Locker is unlocked! Perform actions here.");




    }
}
