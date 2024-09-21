using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleManager : MonoBehaviour
{
    public AudioClip correctSound;
    public AudioClip incorrectSound;
    public AudioSource audioSource;

    public PuzzlePlace[] puzzlePlaces;
    public PuzzlePiece[] puzzlePieces;

    private int placedPiecesCount = 0; // تتبع عدد القطع الموضوعة بشكل صحيح

    private void Start()
    {
        if (puzzlePlaces.Length == 0 || puzzlePieces.Length == 0 || puzzlePlaces.Length != puzzlePieces.Length)
        {
            Debug.LogError("يرجى تحديد أماكن الألغاز وقطع الألغاز بشكل صحيح في المحرر.");
            return;
        }

        for (int i = 0; i < puzzlePieces.Length; i++)
        {
            puzzlePieces[i].SetTargetPlace(puzzlePlaces[i].gameObject);
        }

        // تعيين الأصوات لكل PuzzlePlace
        foreach (PuzzlePlace place in puzzlePlaces)
        {
            place.correctSound = correctSound;
            place.incorrectSound = incorrectSound;
        }
    }

    public void PiecePlacedCorrectly()
    {
        placedPiecesCount++;
        Debug.Log("عدد القطع الموضوعة بشكل صحيح: " + placedPiecesCount);

        if (placedPiecesCount == 6)
        {
            Debug.LogError("مرحبًا.");

            // أدخل الإجراء الذي تريد تنفيذه هنا

            float delay = 1f; // تعديل هذا الرقم حسب احتياجاتك
            Invoke("GoToWall", delay);
        }
    }

    private void GoToWall()
    {
        DisplayImage displayImageScript = FindObjectOfType<DisplayImage>();

        // إذا تم العثور على السكربت، قم بتعيين الجدار الحالي إلى 18
        if (displayImageScript != null)
        {
            displayImageScript.OnButtonClick(DisplayImage.ButtonType.GoToWall20);
        }
    }

}
