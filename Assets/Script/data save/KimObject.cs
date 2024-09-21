using UnityEngine;

public class KimObject : MonoBehaviour
{
    public float timeToDestroy = 5f; // تعيين الوقت الذي تريد فيه حذف الكيم أوبجكت بعد انتهاء التايم لاين

    void Start()
    {
        // استدعاء دالة لحذف الكائن بعد انتهاء الفترة الزمنية
        Invoke("DestroyObject", timeToDestroy);
    }

    void DestroyObject()
    {
        // حذف الكائن
        Destroy(gameObject);
    }
}
