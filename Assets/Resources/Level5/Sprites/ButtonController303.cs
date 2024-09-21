using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController303 : MonoBehaviour
{
    public Button button1;
    public Button button2;

    public GameObject[] objectsToHide;
    public GameObject[] objectsToShow;

    private bool isButton1Pressed = false;

    void Start()
    {
        button1.onClick.AddListener(OnButton1Click);
        button2.onClick.AddListener(OnButton2Click);
    }

    void OnButton1Click()
    {
        isButton1Pressed = true;
    }

    void OnButton2Click()
    {
        if (isButton1Pressed)
        {
            SetObjectsActive(objectsToHide, false);
            SetObjectsActive(objectsToShow, true);
            isButton1Pressed = false; // إعادة ضبط الحالة
        }
    }

    void SetObjectsActive(GameObject[] objects, bool isActive)
    {
        foreach (GameObject obj in objects)
        {
            obj.SetActive(isActive);
        }
    }
}