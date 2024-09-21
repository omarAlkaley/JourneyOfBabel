using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpriteSwitcherWithChildren : MonoBehaviour
{
    public GameObject image1;
    public GameObject[] childrenImage1;
    private int currentChildIndex1 = 0;

    public GameObject image2;
    public GameObject[] childrenImage2;
    private int currentChildIndex2 = 0;

    public GameObject[] childrenImage3;
  //  public GameObject[] childrenImage4;

    private bool isImage1 = true;

    void Start()
    {
        // عرض الصورة الأولى والطفل الأول عند بدء التشغيل
        ShowChild(image1, childrenImage1, currentChildIndex1);
        HideChild(image2, childrenImage2);

        // تعيين currentChildIndex1 ليبدأ من الطفل الثاني
        currentChildIndex1 = 1;
    }

    public void SwitchImage()
    {
        // تبديل بين الصور
        isImage1 = !isImage1;

        if (isImage1)
        {
            // إذا كانت الصورة الأولى، عرض الطفل التالي
            ShowChild(image1, childrenImage1, currentChildIndex1);

            // زيادة عداد الأطفال للصورة 1
            currentChildIndex1 = (currentChildIndex1 + 1) % childrenImage1.Length;

            // إخفاء الصورة الثانية والطفل فيها
            HideChild(image2, childrenImage2);
        }
        else
        {
            // إذا كانت الصورة الثانية، عرض الطفل التالي
            ShowChild(image2, childrenImage2, currentChildIndex2);

            // زيادة عداد الأطفال للصورة 2
            currentChildIndex2 = (currentChildIndex2 + 1) % childrenImage2.Length;

            // إخفاء الصورة الأولى والطفل فيها
            HideChild(image1, childrenImage1);
        }

        // إذا انتهت الأطفال في الصورة الحالية، يتم طباعة Debug.Log
        if (isImage1 && currentChildIndex1 == 0)
        {
            Debug.Log("انتهاء الأطفال في الصورة الأولى");
              
        }
        else if (!isImage1 && currentChildIndex2 == 0)
        {
            StartCoroutine(DestroyChildrenAfterDelay(0f, childrenImage3));
            Debug.Log("انتهاء الأطفال في الصورة الثانية");
         
           
        }
    }

    IEnumerator DestroyChildrenAfterDelay(float delay, GameObject[] children)
    {
        yield return new WaitForSeconds(delay);

        foreach (GameObject child in children)
        {
            Destroy(child);
        }
    }

   // IEnumerator ActivateChildrenAfterDelay(float delay, GameObject[] children, bool setActive)
   // {
      //  yield return new WaitForSeconds(delay);

   //     foreach (GameObject child in children)
    //    {
    //        child.SetActive(setActive);
     //   }
  //  }

    void ShowChild(GameObject image, GameObject[] children, int index)
    {
        image.SetActive(true);

        if (index < children.Length)
        {
            for (int i = 0; i < children.Length; i++)
            {
                children[i].SetActive(i == index);
            }
        }
    }

    void HideChild(GameObject image, GameObject[] children)
    {
        image.SetActive(false);

        foreach (GameObject child in children)
        {
            child.SetActive(false);
        }
    }
}
