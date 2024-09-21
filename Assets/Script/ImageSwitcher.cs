using UnityEngine;

public class ImageSwitcher : MonoBehaviour
{
    public GameObject[] images; // مصفوفة تحتوي على جميع الصور
    public GameObject[] associatedObjects; // مصفوفة تحتوي على الكائنات المرتبطة بكل صورة
    private int activeImageIndex = 0; // متغير لتتبع الصورة النشطة حاليًا
    public AudioSource buttonClickSound; // متغير لتخزين مكون الصوت

    void Start()
    {
        // التحقق من تطابق عدد الصور مع عدد الكائنات المرتبطة
        if (images.Length != associatedObjects.Length)
        {
            Debug.LogError("Number of images and associated objects must be the same.");
            return;
        }

        // عرض الصورة الأولى عند بدء التشغيل
        SetActiveImage(activeImageIndex);
    }

    public void NextImage()
    {
        // التحقق مما إذا كانت الصورة النشطة هي الصورة الأخيرة
        if (activeImageIndex < images.Length - 1)
        {
            int nextImageIndex = activeImageIndex + 1;

            // التحقق مما إذا كان الكائن المرتبط بالصورة التالية محذوف أو مرئي
            if (associatedObjects[nextImageIndex] == null || associatedObjects[nextImageIndex].activeSelf)
            {
                activeImageIndex = nextImageIndex;
                SetActiveImage(activeImageIndex);
                // تشغيل الصوت عند الضغط على الزر
                if (buttonClickSound != null)
                {
                    buttonClickSound.Play();
                }
            }
            else
            {
                Debug.Log("Cannot move to the next image because the associated object is hidden but not deleted.");
            }
        }
    }

    public void PreviousImage()
    {
        // التحقق مما إذا كانت الصورة النشطة هي الصورة الأولى
        if (activeImageIndex > 0)
        {
            activeImageIndex--;
            SetActiveImage(activeImageIndex);
            // تشغيل الصوت عند الضغط على الزر
            if (buttonClickSound != null)
            {
                buttonClickSound.Play();
            }
        }
    }

    private void SetActiveImage(int index)
    {
        // إخفاء جميع الصور
        for (int i = 0; i < images.Length; i++)
        {
            images[i].SetActive(false);
        }

        // عرض الصورة النشطة بغض النظر عن حالة الكائن المرتبط
        images[index].SetActive(true);

        // التحقق مما إذا كان الكائن المرتبط بالصورة النشطة مرئيًا
        if (associatedObjects[index] != null && associatedObjects[index].activeSelf)
        {
            // حذف الكائن المرتبط بالصورة النشطة إذا كان مرئيًا
            Destroy(associatedObjects[index]);
            // حفظ حالة الكائن في PlayerPrefs
            PlayerPrefs.SetInt("ObjectDeleted" + index, 1);
        }
        else
        {
            // حفظ حالة الصورة والكائن المرتبط بها
            PlayerPrefs.SetInt("ImageDisplayed" + index, 1);
            if (associatedObjects[index] == null)
            {
                PlayerPrefs.SetInt("ObjectDeleted" + index, 1);
            }
            else
            {
                PlayerPrefs.SetInt("ObjectDeleted" + index, 0);
            }
        }
    }

    public void LoadImageSwitcherData()
    {
        // استرجاع البيانات المحفوظة
        for (int i = 0; i < images.Length; i++)
        {
            int isDisplayed = PlayerPrefs.GetInt("ImageDisplayed" + i, 0);
            int isDeleted = PlayerPrefs.GetInt("ObjectDeleted" + i, 0);

            if (isDisplayed == 1)
            {
                images[i].SetActive(true);
            }
            else
            {
                images[i].SetActive(false);
            }

            if (isDeleted == 1)
            {
                if (associatedObjects[i] != null)
                {
                    Destroy(associatedObjects[i]);
                }
            }
        }

        // استرجاع الفهرس النشط
        activeImageIndex = PlayerPrefs.GetInt("ActiveImageIndex", 0);
        SetActiveImage(activeImageIndex);
        Debug.Log("ImageSwitcher data loaded successfully!");
    }
}
