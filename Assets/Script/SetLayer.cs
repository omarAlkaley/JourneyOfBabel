using UnityEngine;

public class SetLayer : MonoBehaviour
{
    public int newLayer;

    void Start()
    {
        // قم بتحديد رقم اللير الجديد لهذا الكائن عند بدء التشغيل
        gameObject.layer = newLayer;
    }
}
