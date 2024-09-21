using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeButtonColor : MonoBehaviour
{
    public Sprite[] images;
    private int currentImageIndex = 0;
    private Image lastClickedImage;
    public Image[] targetImages;

    void Start()
    {
        if (images == null || images.Length == 0)
        {
            Debug.LogError("No images assigned.");
            return;
        }

        if (targetImages != null && targetImages.Length > 0)
        {
            foreach (Image targetImage in targetImages)
            {
                if (targetImage != null)
                {
                    targetImage.sprite = images[0]; // تعيين الصورة الأصلية
                }
                else
                {
                    Debug.LogError("Target Image is not set up correctly.");
                }
            }
        }
        else
        {
            Debug.LogError("No target Images assigned.");
        }
    }

    public void OnButtonClick(Image clickedImage)
    {
        if (clickedImage != null && System.Array.Exists(targetImages, img => img == clickedImage))
        {
            Debug.Log("Image clicked: " + clickedImage.gameObject.name);

            // إعادة الصورة الأصلية للكائن السابق إذا كان مختلفًا عن الحالي
            if (lastClickedImage != null && lastClickedImage != clickedImage)
            {
                lastClickedImage.sprite = images[0];
            }

            // تغيير الصورة للكائن الحالي
            currentImageIndex = (currentImageIndex + 1) % images.Length;
            clickedImage.sprite = images[currentImageIndex];

            // تعيين الكائن الحالي كآخر كائن تم النقر عليه
            lastClickedImage = clickedImage;
        }
        else
        {
            Debug.Log("Clicked object is not a target Image.");
        }
    }
}
