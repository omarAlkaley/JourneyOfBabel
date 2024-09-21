using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class ShowHideR : MonoBehaviour
{
    public GameObject[] objectsToToggle;
    private bool areObjectsVisible = false;
    public GameObject gameObject1;
    public GameObject gameObject2;
    public GameObject gameObject3;
    public GameObject gameObject4;
    void Start()
    {
        // قم بإخفاء الأشياء عند بدء التشغيل
        
    }

    public void ToggleVisibility()
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

    // دالة لإظهار أو إخفاء الأشياء
    void ShowObjects()
    {
        ToggleObjectVisibility(true);
        gameObject1.SetActive(false);
        gameObject2.SetActive(false);
        gameObject3.SetActive(false);
        gameObject4.SetActive(false);
    }

    void HideObjects()
    {
        ToggleObjectVisibility(false);
        gameObject1.SetActive(true);
        gameObject2.SetActive(true);
        gameObject3.SetActive(true);
        gameObject4.SetActive(true);
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
