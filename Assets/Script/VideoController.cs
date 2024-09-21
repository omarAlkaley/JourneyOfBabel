using UnityEngine;
using UnityEngine.Video;
using System;
using UnityEngine.UI;

public class VideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject sceneObjects;
    public GameObject bjects1;
    public GameObject bjects2;
    public GameObject bjects3;
    public GameObject bjects4;

    public GameObject Objects;

    public bool showSceneObjects = true;
    public int wallNumber = 17; // قم بتعيين القيمة المطلوبة من الـ Inspector
    public Button myButton;
    private bool hasVideoStarted = false;
    void Start()
    {
        if (videoPlayer == null)
        {
            Debug.LogError("يرجى تعيين مرجع لـ VideoPlayer في المحرر.");
            return;
        }

        // سجل دالة للاستماع إلى انتهاء الفيديو.
        videoPlayer.loopPointReached += OnVideoEnd;
        sceneObjects.SetActive(false);
        bjects1.SetActive(false);

        myButton.gameObject.SetActive(false);
    }

    void OnVideoStart()
    {
        // يتم استدعاء هذه الدالة عند بداية الفيديو.
        // يمكنك إضافة السلوك المطلوب هنا.
        Debug.Log("بدأ الفيديو!");
        Invoke("ShowButton", 4f);
        bjects1.SetActive(true);
        bjects2.SetActive(false);
        

    }

    void OnVideoEnd(VideoPlayer vp)
    {
        // يتم استدعاء هذه الدالة عندما ينتهي الفيديو.
        Debug.LogError("مرحبًا.");
        bjects4.SetActive(false);

        DisplayImage displayImageScript = FindObjectOfType<DisplayImage>();

        // إذا تم العثور على السكربت، قم بتعيين الجدار الحالي إلى الرقم المحدد
        if (displayImageScript != null)
        {
            string buttonType = $"GoToWall{wallNumber}";
            displayImageScript.OnButtonClick((DisplayImage.ButtonType)Enum.Parse(typeof(DisplayImage.ButtonType), buttonType));
        }

        bjects3.SetActive(true);
        
        SetSceneObjectsActive(showSceneObjects);
    }

    void Update()
    {
        // تحقق من مرور ثانية واحدة من بداية تشغيل الفيديو
        if (videoPlayer.isPlaying && videoPlayer.time >= 1f && !hasVideoStarted)
        {
            hasVideoStarted = true;
            OnVideoStart();
        }
    }

    void SetSceneObjectsActive(bool active)
    {
        if (sceneObjects != null)
        {
            sceneObjects.SetActive(active);
        }
    }

    void ShowButton()
    {
        myButton.gameObject.SetActive(true);

    }
}
