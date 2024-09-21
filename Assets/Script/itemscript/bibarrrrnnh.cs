using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bibarrrrnnh : MonoBehaviour
{
    public GameObject[] objectsToToggle;
    private bool areObjectsVisible = false;

    void Start()
    {
        // قم بإخفاء الأشياء عند بدء التشغيل
        HideObjects();
    }

    public void ToggleVisibility()
    {
        // التحقق من رؤية الكائن bookkkkk
        GameObject BookObject = GameObject.Find("Book");

        // تحقق من رؤية الكائن bookkkkk قبل تبديل حالة الأشياء
        if (BookObject != null && BookObject.activeSelf)
        {
            // إذا كان الكائن bookkkkk مرئي، لا تقم بتغيير حالة الأشياء
            Debug.Log("لا يمكن تبديل الرؤية لأن كائن Book مرئي.");
        }
        else
        {
            // تغيير حالة الأشياء بين الظهور والاختفاء
            areObjectsVisible = !areObjectsVisible;

            // تحديد ما إذا كان يجب إظهار أو إخفاء الأشياء
            if (areObjectsVisible)
            {
                ShowObjects();
            }
            else
            {
                HideObjects();
            }
        }
    }

    // دالة لإظهار أو إخفاء الأشياء
    void ShowObjects()
    {
        ToggleObjectVisibility(true);
    }

    void HideObjects()
    {
        ToggleObjectVisibility(false);
    }

    // دالة لتبديل رؤية الأشياء بناءً على الحالة المحددة
    void ToggleObjectVisibility(bool visibility)
    {
        foreach (GameObject obj in objectsToToggle)
        {
            // التحقق من وجود الكائن قبل تغيير حالته
            if (obj != null)
            {
                obj.SetActive(visibility);
            }
        }
    }
}
