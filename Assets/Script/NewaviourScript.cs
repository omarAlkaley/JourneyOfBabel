using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class NewaviourScript : MonoBehaviour
{
    public GameObject[] objectsToToggle;
    private bool areObjectsVisible = false;


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
