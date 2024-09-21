using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager303 : MonoBehaviour
{
    public Button[] buttons; // جميع الأزرار العشرة
    public GameObject[] objectsToToggle; // الكائنات التي نريد إظهارها وإخفاءها
    public int[] requiredButtonIndices; // الفهارس للأزرار الخمسة المحددة
    public AudioSource audioSource; // مصدر الصوت
    public AudioSource audioSource2;
    public AudioClip buttonClickSound; // صوت الضغط على الزر
    public AudioClip opinmaSound;

    private bool[] buttonStates;
    private bool areObjectsVisible = false; // حالة الكائنات

    void Start()
    {
        buttonStates = new bool[buttons.Length];

        // ربط الأحداث للأزرار
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i; // لتجنب مشكلة متغير الحلقة
            buttons[index].onClick.AddListener(() => OnButtonClick(index));
        }
    }

    void OnButtonClick(int index)
    {
        // تشغيل صوت الضغط
        if (audioSource != null && buttonClickSound != null)
        {
            audioSource.PlayOneShot(buttonClickSound);
        }

        // عكس حالة الزر
        buttonStates[index] = !buttonStates[index];

        // التحقق من حالة الأزرار وتنفيذ الأمر إذا كان الشرط متحققاً
        if (IsRequiredButtonsOn() && !IsAnyUnwantedButtonOn())
        {
            ToggleObjects(true);
            DisableButtons(); // تعطيل الأزرار بعد إظهار الكائنات
            audioSource.PlayOneShot(opinmaSound);
        }
        else
        {
            ToggleObjects(false);
        }
    }

    bool IsRequiredButtonsOn()
    {
        foreach (int index in requiredButtonIndices)
        {
            if (!buttonStates[index])
            {
                return false;
            }
        }
        return true;
    }

    bool IsAnyUnwantedButtonOn()
    {
        for (int i = 0; i < buttonStates.Length; i++)
        {
            if (System.Array.IndexOf(requiredButtonIndices, i) == -1 && buttonStates[i])
            {
                return true;
            }
        }
        return false;
    }

    void ToggleObjects(bool visibility)
    {
        areObjectsVisible = visibility;
        foreach (GameObject obj in objectsToToggle)
        {
            if (obj != null)
            {
                obj.SetActive(visibility);
            }
        }
    }

    void DisableButtons()
    {
        foreach (Button button in buttons)
        {
            button.interactable = false;
        }
    }
}