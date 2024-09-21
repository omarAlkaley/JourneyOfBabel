using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    private GameObject targetPlace;
    private Vector2 startPosition;
    private bool placed = false;
    public AudioSource audioSource;
    private Collider2D collider2D;

    public AudioClip correctSound;
    public AudioClip incorrectSound;

    private void Start()
    {
        startPosition = transform.position;
        audioSource = gameObject.GetComponent<AudioSource>();
        collider2D = GetComponent<Collider2D>();
    }

    private void OnMouseDrag()
    {
        if (!placed)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            transform.position = mousePosition;
        }
    }

    private void OnMouseUp()
    {
        if (targetPlace != null)
        {
            float distance = Vector2.Distance(transform.position, targetPlace.transform.position);

            if (distance <= 1)
            {
                transform.position = targetPlace.transform.position;
                placed = true;
                PlaySound(correctSound);

                // تعطيل Collider2D بمجرد وضع القطعة في المكان الصحيح
                collider2D.enabled = false;

                PuzzleManager puzzleManager = GetComponentInParent<PuzzleManager>();
                if (puzzleManager != null)
                {
                    puzzleManager.PiecePlacedCorrectly();
                }
            }
            else
            {
                targetPlace.GetComponent<PuzzlePlace>().RemovePiece();
                ResetToStartPosition();
                PlaySound(incorrectSound);
            }
        }
        else
        {
            Debug.LogError("لم يتم تحديد مكان لقطعة اللغز.");
        }
    }

    private void PlaySound(AudioClip sound)
    {
        if (audioSource != null && sound != null)
        {
            audioSource.clip = sound;
            audioSource.PlayOneShot(sound);
        }
    }

    public void SetPlaced(bool isPlaced)
    {
        placed = isPlaced;
    }

    public void SetTargetPlace(GameObject place)
    {
        targetPlace = place;
    }

    public bool IsTargetPlace(GameObject place)
    {
        return targetPlace == place;
    }

    public bool IsPlaced()
    {
        return placed;
    }

    public void ResetToStartPosition()
    {
        transform.position = startPosition;
    }
}
