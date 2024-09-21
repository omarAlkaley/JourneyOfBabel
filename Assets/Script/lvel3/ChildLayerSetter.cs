using UnityEngine;

public class ChildLayerSetter : MonoBehaviour
{
    public string childObjectName; // اسم الطفل داخل كيم ابوجت

    void Start()
    {
        // التأكد من أن الطفل موجود داخل الكيم ابوجت
        Transform childTransform = transform.Find(childObjectName);
        if (childTransform != null)
        {
            // تحديث طبقة الطفل
            childTransform.gameObject.layer = 9;

            // إذا كان لديه سبرايت رندر، فقم بتحديث طبقة السبرايت رندر أيضًا
            SpriteRenderer spriteRenderer = childTransform.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.gameObject.layer = 9;
            }
            else
            {
                Debug.LogWarning("لم يتم العثور على SpriteRenderer داخل الطفل.");
            }
        }
        else
        {
            Debug.LogWarning("لا يوجد طفل بهذا الاسم داخل الكيم ابوجت.");
        }
    }
}