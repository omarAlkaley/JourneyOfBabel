using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class imegbockswoitch : MonoBehaviour
{
    public GameObject[] images; // مصفوفة تحتوي على جميع الصور
    private int activeImageIndex = 0; // متغير لتتبع الصورة النشطة حاليًا

    void Start()
    {
        // عرض الصورة الأولى عند بدء التشغيل
        SetActiveImage(activeImageIndex);
    }

    public void NextImage()
    {
        // التحقق مما إذا كانت الصورة النشطة هي الصورة الأخيرة
        if (activeImageIndex < images.Length - 1)
        {
            // الانتقال إلى الصورة التالية فقط إذا لم تكن الصورة الأخيرة
            activeImageIndex++;
            SetActiveImage(activeImageIndex);
        }
    }

    public void PreviousImage()
    {
        // التحقق مما إذا كانت الصورة النشطة هي الصورة الأولى
        if (activeImageIndex > 0)
        {
            // الانتقال إلى الصورة السابقة فقط إذا لم تكن الصورة الأولى
            activeImageIndex--;
            SetActiveImage(activeImageIndex);
        }
    }

    private void SetActiveImage(int index)
    {
        // إخفاء جميع الصور ثم إظهار الصورة المحددة بواسطة الفهرس (index)
        for (int i = 0; i < images.Length; i++)
        {
            images[i].SetActive(i == index);
        }
    }
}