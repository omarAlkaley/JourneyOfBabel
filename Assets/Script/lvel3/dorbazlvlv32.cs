using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dorbazlvlv32 : MonoBehaviour
{
    public AudioClip incorrect;
    public AudioSource source;

    public GameObject[] hiddenObject;
    public GameObject hiddenObject1;
    public GameObject hiddenObject2;
    public GameObject hiddenObject3;
    public GameObject hiddenObject4;

    public float timeToDestroy = 5f;




    private SpriteRenderer[] spriteRenderers; // تم إضافة مصفوفة من مكونات SpriteRenderer







    public Button button1;
    public Button button2;

    private bool button1Clicked = false;
    private bool button2Clicked = false; // تم إضافة متغير للتحقق من تنفيذ button2


    private void Start()
    {






        button1.onClick.AddListener(OnButton1Click);
        button2.onClick.AddListener(OnButton2Click);

    }

    public void OnButton1Click()
    {

        button1Clicked = true;
        Debug.Log("Button 1 Clicked");
    }

    public void OnButton2Click()
    {

        if (button1Clicked)
        {


            hiddenObject3.SetActive(true);
            Invoke("SetActivegameObject", timeToDestroy);






        }
        else
        {
            Debug.Log("Button 2 Clicked without Button 1");
        }
    }

    void SetActivegameObject()
    {
        Debug.Log("Button 2 Clicked after Button 1");
        hiddenObjectt();
        hiddenObject1.SetActive(false);
        hiddenObject2.SetActive(false);
        hiddenObject4.SetActive(false);


        source.clip = incorrect;
        source.Play();



        Destroy(button1.gameObject);
        Destroy(button2.gameObject);

        Debug.Log("hiiiii");
    }
    private void hiddenObjectt()
    {
        if (hiddenObject != null && hiddenObject.Length > 0)
        {
            foreach (GameObject obj in hiddenObject)
            {
                obj.SetActive(true);
            }
        }
    }
}
