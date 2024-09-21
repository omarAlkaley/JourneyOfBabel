using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoController343 : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    public GameObject[] objectsToHide;
    public GameObject[] objectsToShow;

    public GameObject[] objectsToHide1;
    public GameObject[] objectsToShow2;

    // متغير لضبط الوقت من الـ Inspector
    public float delayTime = 5.0f;

    // مرجع إلى سكربت SaveLoadManager
    public SaveLoadManager saveLoadManager;

    // خيار لتفعيل استدعاء NewGame
    public bool callNewGameOnVideoEnd = false;

    void Start()
    {
        videoPlayer.loopPointReached += OnVideoEnd;
        videoPlayer.started += OnVideoStart;
    }

    void OnVideoStart(VideoPlayer vp)
    {
        SetObjectsActive2(false);
        StartCoroutine(ShowObjectsAfterDelay());
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        SetObjectsActive1(true);
        SetObjectsActive(false);

        // استدعاء NewGame إذا كان الخيار مفعلاً
        if (callNewGameOnVideoEnd && saveLoadManager != null)
        {
            saveLoadManager.NewGame();
        }
    }

    void SetObjectsActive(bool isActive)
    {
        foreach (GameObject obj in objectsToHide)
        {
            obj.SetActive(isActive);
        }
    }

    void SetObjectsActive1(bool isActive)
    {
        foreach (GameObject obj in objectsToShow)
        {
            obj.SetActive(isActive);
        }
    }

    void SetObjectsActive2(bool isActive)
    {
        foreach (GameObject obj in objectsToHide1)
        {
            obj.SetActive(isActive);
        }
    }

    // كورووتين لتفعيل objectsToShow2 بعد التأخير المحدد
    IEnumerator ShowObjectsAfterDelay()
    {
        yield return new WaitForSeconds(delayTime);
        foreach (GameObject obj in objectsToShow2)
        {
            obj.SetActive(true);
        }
    }
}
