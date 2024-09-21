using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bookhidn : MonoBehaviour
{
    public GameObject[] objectsToToggle;
    private bool areObjectsVisible = true;

    // تعريف المفتاح لتخزين حالة الرؤية
   // private const string visibilityKey = "ObjectsVisibility";

    void Start()
    {
        // استرجاع حالة الرؤية المحفوظة عند بدء التشغيل
      //  if (PlayerPrefs.HasKey(visibilityKey))
      //  {
      //      areObjectsVisible = PlayerPrefs.GetInt(visibilityKey) == 1;
      //      SetObjectsVisibility(areObjectsVisible);
     //   }
    }

    public void ToggleVisibility()
    {
        areObjectsVisible = !areObjectsVisible;
        SetObjectsVisibility(areObjectsVisible);

        // حفظ حالة الرؤية بعد التبديل
       // PlayerPrefs.SetInt(visibilityKey, areObjectsVisible ? 1 : 0);
      //  PlayerPrefs.Save();
    }

    // دالة لتعيين رؤية الكائنات
    private void SetObjectsVisibility(bool visible)
    {
        foreach (GameObject obj in objectsToToggle)
        {
            obj.SetActive(visible);
        }
    }
}
