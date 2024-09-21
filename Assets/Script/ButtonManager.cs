using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public AudioClip incorrect;
    public AudioSource source;
    public Button button1;
    public Button button2;
    public GameObject hiddenObject;
    public GameObject hiddenObject1;

    public Button button3;
    public Button button4;
    public GameObject hiddenObject2;
    public GameObject hiddenObject3;

    public GameObject blackObject1;
    public GameObject blackObject2;
    public GameObject blackObject3;
    public GameObject blackObject4;
    public GameObject blackObject5;
    public GameObject blackObject6;
    public GameObject blackObject7;
    public GameObject blackObject8;
    public GameObject blackObject9;
    public GameObject blackObject10;
    public GameObject blackObject11;
    public GameObject blackObject12;
    public GameObject blackObject13;





    public Button buttonlait1;
    public Button buttonlait2;
    public Button buttonlait3;
    public Button buttonlait4;
    private bool button1Clicked = false;
    private bool button2Clicked = false; // تم إضافة متغير للتحقق من تنفيذ button2
    private bool button3Clicked = false;

    private void Start()
    {
        hiddenObject.SetActive(false);
        hiddenObject1.SetActive(false);
        hiddenObject2.SetActive(false);
        hiddenObject3.SetActive(false);


        
        button4.gameObject.SetActive(false);


        buttonlait2.gameObject.SetActive(false);
        buttonlait3.gameObject.SetActive(false);
        buttonlait4.gameObject.SetActive(false);


        button1.onClick.AddListener(OnButton1Click);
        button2.onClick.AddListener(OnButton2Click);
        button3.onClick.AddListener(OnButton3Click);
        button4.onClick.AddListener(OnButton4Click);
    }

    public void OnButton1Click()
    {
        
        button1Clicked = true;
        Debug.Log("Button 1 Clicked");
    }

    public void OnButton2Click()
    {
        source.clip = incorrect;
        source.Play();
        if (button1Clicked)
        {
            Debug.Log("Button 2 Clicked after Button 1");
            hiddenObject.SetActive(true);
            hiddenObject1.SetActive(true);

            button3.gameObject.SetActive(true);
            button4.gameObject.SetActive(true);
            buttonlait2.gameObject.SetActive(true);

            Destroy(blackObject10.gameObject);
            Destroy(blackObject6.gameObject);




            Destroy(button1.gameObject);
            Destroy(button2.gameObject);
            Destroy(buttonlait1.gameObject);
            button2Clicked = true; // تم تنفيذ button2
        }
        else
        {
            Debug.Log("Button 2 Clicked without Button 1");
        }
    }

    public void OnButton3Click()
    {
       
        if (button2Clicked) // تحقق من تنفيذ button2 قبل تنفيذ button3
        {
            button3Clicked = true;
            Debug.Log("Button 3 Clicked after Button 2");
        }
        else
        {
            Debug.Log("Button 3 Clicked without Button 2");
        }
    }

    public void OnButton4Click()
    {
        source.clip = incorrect;
        source.Play();
        if (button3Clicked)
        {
            Debug.Log("Button 4 Clicked after Button 3");
            hiddenObject2.SetActive(true);
            hiddenObject3.SetActive(true);
            buttonlait3.gameObject.SetActive(true);



            Destroy(blackObject4.gameObject);

            Destroy(blackObject11.gameObject);
            Destroy(blackObject1.gameObject);


            Destroy(buttonlait2.gameObject);
            Destroy(button3.gameObject);
            Destroy(button4.gameObject);
        }
        else
        {
            Debug.Log("Button 4 Clicked without Button 3");
        }
    }
}

