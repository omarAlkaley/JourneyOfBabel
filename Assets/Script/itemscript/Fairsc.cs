using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Fairsc : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    public AudioClip incorrect;
    public AudioSource source;
    public AudioClip outcorrect;
    public AudioSource source1;
    public Button button1;
    public Button button2;
   
    public Button button3;
    public Button button4;
    public Button button5;
    public Button button6;
    public GameObject hiddenObject;
    public GameObject hiddenObject1;
    public GameObject hiddenObject2;
    public GameObject hiddenObject3;
    public GameObject hiddenObject00;
    public GameObject hiddenObject11;
    public GameObject hiddenObject22;
    public GameObject hiddenObject33;

    public GameObject hiddenObjectall;

    private bool button1Clicked = false;
    private bool button2Clicked = false;
    private bool button3Clicked = false;
    private bool button4Clicked = false;
    private bool button5Clicked = false;
    private bool button6Clicked = false;
    private bool videoHidden = true;
    private void Start()
    {
        hiddenObject.SetActive(true);
        hiddenObject1.SetActive(false);
        hiddenObject2.SetActive(false);
        hiddenObject3.SetActive(false);

        button4.gameObject.SetActive(false);

        videoPlayer.loopPointReached += OnVideoFinished;

        button1.onClick.AddListener(OnButton1Click);
        button2.onClick.AddListener(OnButton2Click);
        button3.onClick.AddListener(OnButton3Click);
        button4.onClick.AddListener(OnButton4Click);
        button5.onClick.AddListener(OnButton5Click);
        button6.onClick.AddListener(OnButton6Click);
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
            Debug.Log("Button 2 Clicked after Button 1");
            hiddenObject1.SetActive(true);
            hiddenObject11.SetActive(true);

            Destroy(hiddenObject.gameObject);
            Destroy(hiddenObject00.gameObject);


            button3.gameObject.SetActive(true);
            button4.gameObject.SetActive(true);
           

         

            Destroy(button1.gameObject);
            Destroy(button2.gameObject);
          
            button2Clicked = true;
        }
        else
        {
            Debug.Log("Button 2 Clicked without Button 1");
        }
    }

    public void OnButton3Click()
    {
        if (button2Clicked)
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
       
        if (button3Clicked)
        {
            Debug.Log("Button 4 Clicked after Button 3");
            hiddenObject2.SetActive(true);
            hiddenObject22.SetActive(true);

            Destroy(hiddenObject1.gameObject);
            Destroy(hiddenObject11.gameObject);

            button5.gameObject.SetActive(true);
            button6.gameObject.SetActive(true);
            hiddenObjectall.SetActive(false);
            PlayVideo();



            Destroy(button3.gameObject);
            Destroy(button4.gameObject);

            button4Clicked = true;
        }
        else
        {
            Debug.Log("Button 4 Clicked without Button 3");
        }
    }

    public void OnButton5Click()
    {
       
        if (button4Clicked)
        {
            button5Clicked = true;

            Debug.Log("Button 5 Clicked after Button 4");
            // يمكنك إضافة الإجراءات التي تريدها عند النقر على الزر 5 بعد النقر على الزر 4 هنا
        }
        else
        {
            Debug.Log("Button 5 Clicked without Button 4");
        }
    }

    public void OnButton6Click()
    {
       
        if (button5Clicked)
        {
            hiddenObject3.SetActive(true);
           
            hiddenObject33.SetActive(true);
            
           
            Destroy(hiddenObject2.gameObject);
            Destroy(hiddenObject22.gameObject);

            source.clip = incorrect;
            source.Play();


            Destroy(button5.gameObject);
            Destroy(button6.gameObject);



            Debug.Log("Button 6 Clicked after Button 5");
            // يمكنك إضافة الإجراءات التي تريدها عند النقر على الزر 6 بعد النقر على الزر 5 هنا
        }
        else
        {
            Debug.Log("Button 6 Clicked without Button 5");
        }
    }
   

    private void PlayVideo()
    {
        if (videoPlayer != null)
        {
           

            source.clip = outcorrect;
            source1.Play();
            videoPlayer.gameObject.SetActive(true);
            videoPlayer.Play();
            videoHidden = false;
        }
    }

    // معالج الانتهاء من الفيديو
    void OnVideoFinished(VideoPlayer vp)
    {
        hiddenObjectall.SetActive(true);
        videoPlayer.gameObject.SetActive(false);
        Destroy(videoPlayer.gameObject);
      
       
    }


}
