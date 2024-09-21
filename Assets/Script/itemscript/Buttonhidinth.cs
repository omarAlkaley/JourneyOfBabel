using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Buttonhidinth : MonoBehaviour
{
    public bool showSceneObjects = true;
    public GameObject sceneObjects;
    public Button myButton;

    void Start()
    {
        // ابدأ بإخفاء الزر
        myButton.gameObject.SetActive(false);

        // بعد مرور ثانية واحدة، قم بإظهار الزر
       

        sceneObjects.SetActive(false);
    }

    public void OnButtOnButtonClickonC()
    {
     
        
            SetSceneObjectsActive(showSceneObjects);
        
    }

   

    void SetSceneObjectsActive(bool active)
    {
        if (sceneObjects != null)
        {
            sceneObjects.SetActive(active);
        }
    }
}
