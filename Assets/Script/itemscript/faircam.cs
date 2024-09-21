using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class faircam : MonoBehaviour
{
    public Sprite[] sprites; // قم بتعيين السبرايتات هنا في واجهة Unity
    public float changeInterval = 1.0f; // تعيين الوقت بين تغيير الصور

    private SpriteRenderer spriteRenderer;
    private int currentSpriteIndex = 0;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // إعداد تكرار تنفيذ دالة ChangeSprite بانتظام
        InvokeRepeating("ChangeSprite", 0.0f, changeInterval);
    }

    void ChangeSprite()
    {
        // تغيير السبرايت إلى السبرايت التالي في التسلسل
        spriteRenderer.sprite = sprites[currentSpriteIndex];

        // زيادة الفهرس بشكل عادي
        currentSpriteIndex++;

        // التحقق من الفهرس
        if (currentSpriteIndex >= sprites.Length)
        {
            // إذا كان آخر سبرايت في التسلسل، عد إلى الصورة الأولى
            currentSpriteIndex = 0;
        }
    }
}
