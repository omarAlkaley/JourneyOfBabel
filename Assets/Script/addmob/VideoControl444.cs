using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoControl444 : MonoBehaviour
{
    public VideoPlayer videoPlayer; // مرجع لفيديو بلاير
    public GameObject objectToShow; // الكائنات التي سيتم إظهارها
    public GameObject objectToShow2;
  //  public GameObject objectToShow3; // سيتم إظهار هذا الكائن عند بدء تشغيل الفيديو
    public GameObject objectToHide; // الكائنات التي سيتم إخفاؤها
  //  public GameObject objectToHide2;

    void Start()
    {
        if (videoPlayer == null)
        {
            videoPlayer = GetComponent<VideoPlayer>();
        }

        // إظهار objectToShow3 عند بدء تشغيل الفيديو
       

        // إضافة حدث للتشغيل عند انتهاء الفيديو
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        // إخفاء الكائنات
        if (objectToHide != null)
        {
            objectToHide.SetActive(false);
        }

       

        // إظهار الكائنات
        if (objectToShow != null)
        {
            objectToShow.SetActive(true);
        }

        if (objectToShow2 != null)
        {
            objectToShow2.SetActive(true);
        }
    }
}
