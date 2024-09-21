using UnityEngine;

public class DisableTouchOnObjectVisible : MonoBehaviour
{
    public GameObject targetObject;
    private bool inputDisabled = false;

    void Update()
    {
        if (targetObject.activeInHierarchy && !inputDisabled)
        {
            // تعطيل جميع أوامر الضغط والإدخال
            DisableAllInput();
            inputDisabled = true;
        }
        else if (!targetObject.activeInHierarchy && inputDisabled)
        {
            // إعادة تفعيل جميع أوامر الضغط والإدخال
            inputDisabled = false;
        }
    }

    void DisableAllInput()
    {
        // تعطيل المس باللمس
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.GetTouch(i);
                touch.phase = TouchPhase.Canceled;
            }
        }

        // تعطيل الإدخال من لوحة المفاتيح
        if (Input.anyKeyDown)
        {
            // لا يتم اتخاذ أي إجراء
        }

        // تعطيل النقر بزر الماوس الأيمن
        if (Input.GetMouseButtonDown(1)) // 1 هو لزر الماوس الأيمن
        {
            // إلغاء التأثير الناتج عن النقر بزر الماوس الأيمن
            Event currentEvent = Event.current;
            currentEvent.Use();
        }
    }
}
