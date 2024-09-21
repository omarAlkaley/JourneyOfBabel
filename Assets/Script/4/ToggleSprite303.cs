using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSprite303 : MonoBehaviour
{
    public Sprite originalSprite;
    public Sprite toggledSprite;
    private SpriteRenderer spriteRenderer;
    private bool isToggled = false;

    private static ToggleSprite303 currentToggledInstance;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = originalSprite;
    }

    void Update()
    {
        // تحقق من إذا كان الكائن لا يحتوي على طفل ويجب إعادة تعيين صورته
        if (transform.childCount == 0 && isToggled)
        {
            ResetSprite();
        }
    }

    void OnMouseDown()
    {
        // تحقق من إذا كان الكائن يحتوي على طفل
        if (transform.childCount > 0)
        {
            // إعادة تعيين صورة الكائن الحالي إذا كان هناك كائن آخر تم تبديل صورته
            if (currentToggledInstance != null && currentToggledInstance != this)
            {
                currentToggledInstance.ResetSprite();
            }

            // تبديل الصورة
            ToggleSpriteImage();
        }
    }

    private void ToggleSpriteImage()
    {
        if (!isToggled)
        {
            spriteRenderer.sprite = toggledSprite;
            isToggled = true;
            currentToggledInstance = this;
        }
        else
        {
            ResetSprite();
        }
    }

    private void ResetSprite()
    {
        spriteRenderer.sprite = originalSprite;
        isToggled = false;
        if (currentToggledInstance == this)
        {
            currentToggledInstance = null;
        }
    }
}