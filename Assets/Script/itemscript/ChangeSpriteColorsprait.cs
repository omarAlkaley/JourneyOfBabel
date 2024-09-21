using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpriteColor : MonoBehaviour
{
    public Sprite[] sprites;
    private int currentSpriteIndex = 0;
    private SpriteRenderer lastClickedSpriteRenderer;
    public SpriteRenderer[] targetSpriteRenderers;

    void Start()
    {
        if (sprites == null || sprites.Length == 0)
        {
            Debug.LogError("No sprites assigned.");
            return;
        }

        if (targetSpriteRenderers != null && targetSpriteRenderers.Length > 0)
        {
            foreach (SpriteRenderer targetSpriteRenderer in targetSpriteRenderers)
            {
                if (targetSpriteRenderer != null)
                {
                    targetSpriteRenderer.sprite = sprites[0]; // تعيين الصورة الأصلية
                }
                else
                {
                    Debug.LogError("Target SpriteRenderer is not set up correctly.");
                }
            }
        }
        else
        {
            Debug.LogError("No target SpriteRenderers assigned.");
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hitCollider = Physics2D.OverlapPoint(mousePosition);

            if (hitCollider != null)
            {
                SpriteRenderer targetSpriteRenderer = hitCollider.GetComponent<SpriteRenderer>();

                if (targetSpriteRenderer != null && System.Array.Exists(targetSpriteRenderers, sr => sr == targetSpriteRenderer))
                {
                    Debug.Log("SpriteRenderer clicked: " + targetSpriteRenderer.gameObject.name);

                    // إعادة الصورة الأصلية للكائن السابق إذا كان مختلفًا عن الحالي
                    if (lastClickedSpriteRenderer != null && lastClickedSpriteRenderer != targetSpriteRenderer)
                    {
                        lastClickedSpriteRenderer.sprite = sprites[0];
                    }

                    // تغيير الصورة للكائن الحالي
                    currentSpriteIndex = (currentSpriteIndex + 1) % sprites.Length;
                    targetSpriteRenderer.sprite = sprites[currentSpriteIndex];

                    // تعيين الكائن الحالي كآخر كائن تم النقر عليه
                    lastClickedSpriteRenderer = targetSpriteRenderer;

                    // لا داعي للاستمرار في الفحص بعد العثور على الهدف
                    return;
                }
                else
                {
                    Debug.Log("Clicked object is not a target SpriteRenderer.");
                }
            }
            else
            {
                Debug.Log("No collider hit at mouse position.");
            }
        }

        // فحص الأطفال في كل إطار
        CheckChildren();
    }

    bool HasChildren(GameObject gameObject)
    {
        return gameObject.transform.childCount > 0;
    }

    void RestoreOriginalSprites()
    {
        foreach (SpriteRenderer targetSpriteRenderer in targetSpriteRenderers)
        {
            if (targetSpriteRenderer != null)
            {
                targetSpriteRenderer.sprite = sprites[0];
            }
        }
    }

    void CheckChildren()
    {
        foreach (SpriteRenderer targetSpriteRenderer in targetSpriteRenderers)
        {
            if (targetSpriteRenderer != null && !HasChildren(targetSpriteRenderer.gameObject))
            {
                targetSpriteRenderer.sprite = sprites[0];
            }
        }
    }
}
