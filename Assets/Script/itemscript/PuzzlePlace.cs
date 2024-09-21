using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePlace : MonoBehaviour
{
    private GameObject placedPiece;
    public AudioSource audioSource;

    public AudioClip correctSound;
    public AudioClip incorrectSound;

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PuzzlePiece puzzlePiece = collision.GetComponent<PuzzlePiece>();
        if (puzzlePiece != null)
        {
            if (placedPiece == null && puzzlePiece.IsTargetPlace(gameObject))
            {
                placedPiece = puzzlePiece.gameObject;
                puzzlePiece.SetPlaced(true);
                PlaySound(correctSound);
                PuzzleManager puzzleManager = GetComponentInParent<PuzzleManager>();
                if (puzzleManager != null)
                {
                    puzzleManager.PiecePlacedCorrectly();
                }
            }
            else if (!puzzlePiece.IsPlaced())
            {
                puzzlePiece.ResetToStartPosition();
                PlaySound(incorrectSound);
            }
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

    public void RemovePiece()
    {
        placedPiece = null;
    }
}
