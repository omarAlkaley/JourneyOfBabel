using UnityEngine;
using UnityEngine.UI;

public class ChangeSpriteOnButtonClick : MonoBehaviour
{
    public Sprite normalSprite;   // الصورة الافتراضية
    public Sprite pressedSprite;  // الصورة عند الضغط

    private Button button;  // مكون الزر
    private SpriteRenderer spriteRenderer;  // مكون السبرايت رندر
    private bool isPressed = false;  // متغير لتتبع حالة الضغط

    private void Start()
    {
        button = GetComponent<Button>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        // قم بتعيين الصورة الافتراضية
        spriteRenderer.sprite = normalSprite;
    }

    // اتصل بهذه الوظيفة عند الضغط على الزر
    public void OnButtonPress()
    {
        // قم بتغيير الصورة بناءً على حالة الضغط
        if (isPressed)
        {
            // إذا كان قد تم الضغط، عد إلى الصورة الافتراضية
            spriteRenderer.sprite = normalSprite;
        }
        else
        {
            // إذا لم يكن قد تم الضغط، قم بتغيير الصورة إلى الصورة المضغوطة
            spriteRenderer.sprite = pressedSprite;
        }

        // قم بتبديل حالة الضغط
        isPressed = !isPressed;
    }
}