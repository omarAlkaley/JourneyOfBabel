using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chingebuttenimeg : MonoBehaviour
{
    public Sprite normalIcon;   // الأيقونة الافتراضية
    public Sprite pressedIcon;  // الأيقونة عند الضغط

    private Button button;  // قم بربط الزر
    private bool isPressed = false;  // متغير لتتبع حالة الضغط

    private void Start()
    {
        button = GetComponent<Button>();
        // قم بتعيين الأيقونة الافتراضية
        button.image.sprite = normalIcon;
    }

    // اتصل بهذه الوظيفة عند الضغط على الزر
    public void OnButtonPress()
    {
        // قم بتغيير الأيقونة بناءً على حالة الضغط
        if (isPressed)
        {
            // إذا كان قد تم الضغط، عد إلى الأيقونة الافتراضية
            button.image.sprite = normalIcon;
        }
        else
        {
            // إذا لم يكن قد تم الضغط، قم بتغيير الأيقونة إلى الأيقونة المضغوطة
            button.image.sprite = pressedIcon;
        }

        // قم بتبديل حالة الضغط
        isPressed = !isPressed;
    }
}
