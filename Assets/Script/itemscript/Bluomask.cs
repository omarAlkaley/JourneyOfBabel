using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Bluomask : MonoBehaviour
{

    public VideoPlayer videoPlayer;
    public GameObject[] gameObject2;
    public GameObject gameObject1;

    void Start()
    {
        videoPlayer.gameObject.SetActive(false);

        videoPlayer.loopPointReached += OnVideoFinished;
        gameObject1.SetActive(false);


    }
    private void OnMouseDown()
    {

        PlayVideo();



    }


    private void HideGameObject2()
    {
        if (gameObject2 != null && gameObject2.Length > 0)
        {
            foreach (GameObject obj in gameObject2)
            {
                obj.SetActive(false);
            }
        }
    }

    private void PlayVideo()
    {
        if (videoPlayer != null)
        {
            videoPlayer.gameObject.SetActive(true);
            videoPlayer.Play();

            float delay = 1f; // تعديل هذا الرقم حسب احتياجاتك
            Invoke("HideGameObject2", delay);


        }
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        // عند انتهاء الفيديو، قم بإخفاء وحذف GameObject الخاص به
        videoPlayer.gameObject.SetActive(false);
        Destroy(videoPlayer.gameObject);
        gameObject1.SetActive(true);


    }


}
