using UnityEngine;

public class WallVisibilityManager : MonoBehaviour
{
    public GameObject specialObject; // الكائن الذي تريد عرضه أو إخفاءه

    void Start()
    {
        // التحقق مما إذا كان اللاعب قد وصل إلى الجدار رقم 1 من قبل
        bool hasReachedWall1 = SaveSystem.HasReachedWall1();

        // عرض أو إخفاء الكائن بناءً على النتيجة
        specialObject.SetActive(hasReachedWall1);
    }
}
