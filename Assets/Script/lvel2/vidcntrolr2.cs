using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class vidcntrolr2 : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public AudioSource source;
    public AudioClip incorrect1;
    public int wallNumber = 0;
    public GameObject gameObject;
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
        gameObject.SetActive(true);

        source.Stop();
        DisplayImage displayImageScript = FindObjectOfType<DisplayImage>();

        if (displayImageScript != null)
        {
            string buttonType = $"GoToWall{wallNumber}";
            displayImageScript.OnButtonClick((DisplayImage.ButtonType)Enum.Parse(typeof(DisplayImage.ButtonType), buttonType));
        }
    }
}
