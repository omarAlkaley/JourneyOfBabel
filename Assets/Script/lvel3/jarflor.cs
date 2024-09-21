using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class jarflor : MonoBehaviour
{
   // public AudioClip incorrect;
   // public AudioSource source;
    public VideoPlayer videoPlayer;

    public GameObject hiddenObject;
    public GameObject hiddenObject1;
    public GameObject hiddenObject2;
    public GameObject hiddenObject3;
    public GameObject gameObject2;

    public AudioSource audioSource;
    public AudioClip fadeInSound;



    private SpriteRenderer[] spriteRenderers; // تم إضافة مصفوفة من مكونات SpriteRenderer







    public Button button1;
    public Button button2;

    private bool button1Clicked = false;
    private bool button2Clicked = false; // تم إضافة متغير للتحقق من تنفيذ button2


    private void Start()
    {



        videoPlayer.loopPointReached += OnVideoFinished;


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
            Debug.Log("Button 2 Clicked after Button 1");


            // source.clip = incorrect;
            // source.Play();

            PlayVideo();

            Destroy(button1.gameObject);
            Destroy(button2.gameObject);
            hiddenObject2.SetActive(false);
            Debug.Log("hiiiii");









        }
        else
        {
            Debug.Log("Button 2 Clicked without Button 1");
        }
    }

    private void PlayVideo()
    {
        if (videoPlayer != null)
        {
            gameObject2.SetActive(false);
            videoPlayer.gameObject.SetActive(true);
            videoPlayer.Play();



        }
    }






    void OnVideoFinished(VideoPlayer vp)
    {
        // عند انتهاء الفيديو، قم بإخفاء وحذف GameObject الخاص به
        videoPlayer.gameObject.SetActive(false);
        Destroy(videoPlayer.gameObject);
        gameObject2.SetActive(true);
        hiddenObject3.SetActive(true);
        hiddenObject.SetActive(true);
        hiddenObject1.SetActive(false);
        hiddenObject2.SetActive(false);
        audioSource.PlayOneShot(fadeInSound);
    }



}


