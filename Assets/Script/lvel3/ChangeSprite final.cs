using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSpritefinal : MonoBehaviour
{
    public Sprite[] spriteArray; // قم بتعيين الصور الجديدة للسبرايت هنا في Unity Editor
    private int currentIndex = 0;
    private SpriteRenderer spriteRenderer; // قم بتعيين مكون السبرايت هنا في Unity Editor
    private Button button; // قم بتعيين الزر هنا في Unity Editor
    public GameObject myGameObject1;
    public GameObject myGameObject2;
    public GameObject myGameObject3;
    public GameObject myGameObject4;
    public int wallNumber = 17;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // الحصول على مكون السبرايت
        button = GetComponent<Button>(); // الحصول على مكون الزر
        button.onClick.AddListener(Change); // استماع لنقرة الزر وتنفيذ الدالة Change
    }

    void Change()
    {
        currentIndex = (currentIndex + 1) % spriteArray.Length; // التبديل إلى الصورة التالية في مصفوفة الصور

        if (currentIndex == spriteArray.Length - 1) // إذا كانت الصورة الحالية هي الصورة الأخيرة
        {
            Debug.LogError("مرحبا");
            myGameObject1.SetActive(false);
          //  myGameObject2.SetActive(true);
            myGameObject3.SetActive(false);

            myGameObject4.SetActive(true);


            DisplayImage displayImageScript = FindObjectOfType<DisplayImage>();

            // إذا تم العثور على السكربت، قم بتعيين الجدار الحالي إلى الرقم المحدد
            if (displayImageScript != null)
            {
                string buttonType = $"GoToWall{wallNumber}";
                displayImageScript.OnButtonClick((DisplayImage.ButtonType)Enum.Parse(typeof(DisplayImage.ButtonType), buttonType));
            }
        }

        spriteRenderer.sprite = spriteArray[currentIndex]; // تعيين الصورة الجديدة لمكون السبرايت
    }
}