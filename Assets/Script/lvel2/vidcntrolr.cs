using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;
using UnityEngine.Video;

public class vidcntrolr : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public AudioSource source;
    public AudioClip incorrect1;
    public int wallNumber = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.loopPointReached += OnVideoFinished;
        
    }

    private void PlayVideo()
    {
        if (videoPlayer != null)
        {
            videoPlayer.gameObject.SetActive(true);
            videoPlayer.Play();
           
        }
    }

    // معالج الانتهاء من الفيديو
    void OnVideoFinished(VideoPlayer vp)
    {
        videoPlayer.gameObject.SetActive(false);
        Destroy(videoPlayer.gameObject);
       

        source.Stop();
        DisplayImage displayImageScript = FindObjectOfType<DisplayImage>();

        if (displayImageScript != null)
        {
            string buttonType = $"GoToWall{wallNumber}";
            displayImageScript.OnButtonClick((DisplayImage.ButtonType)Enum.Parse(typeof(DisplayImage.ButtonType), buttonType));
        }
    }
}
