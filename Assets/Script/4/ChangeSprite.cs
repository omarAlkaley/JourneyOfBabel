using UnityEngine;
using UnityEngine.UI;

public class ChangeSprite : MonoBehaviour
{
    public Button yourButton; // مرجع إلى الزر
    public SpriteRenderer spriteRenderer; // مرجع إلى Sprite Renderer
    public Sprite newSprite; // الصورة الجديدة

    private Sprite originalSprite; // لتخزين الصورة الأصلية
    private bool isUsingNewSprite = false; // لتتبع الحالة الحالية للصورة

    void Start()
    {
        // التأكد من تعيين المراجع الصحيحة
        if (yourButton != null)
        {
            yourButton.onClick.AddListener(ChangeSpriteImage);
        }

        // تخزين الصورة الأصلية
        if (spriteRenderer != null)
        {
            originalSprite = spriteRenderer.sprite;
        }
    }

    void ChangeSpriteImage()
    {
        if (spriteRenderer != null && newSprite != null)
        {
            if (isUsingNewSprite)
            {
                // العودة إلى الصورة الأصلية
                spriteRenderer.sprite = originalSprite;
            }
            else
            {
                // تغيير إلى الصورة الجديدة
                spriteRenderer.sprite = newSprite;
            }

            // تبديل الحالة
            isUsingNewSprite = !isUsingNewSprite;
        }
    }
}
