using UnityEngine;

public class SetLayerAboveAll : MonoBehaviour
{
    void Start()
    {
        // الحصول على جميع الطبقات المتاحة في Unity
        int[] allLayers = new int[32];
        for (int i = 0; i < 32; i++)
        {
            allLayers[i] = i;
        }

        // تحديد الليرة العليا (أعلى طبقة متاحة)
        int highestLayer = Mathf.Max(allLayers);

        // تعيين الكائن للطبقة العليا
        gameObject.layer = highestLayer;

        // جعل الكائن الحالي فوق جميع الأشياء في السيناريو
        Renderer rendererComponent = GetComponent<Renderer>();
        if (rendererComponent != null)
        {
            rendererComponent.sortingLayerName = "AboveAllLayers";
            rendererComponent.sortingOrder = 1;
        }
    }
}
