using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoControllerScript2s : MonoBehaviour
{
    public VideoPlayer videoPlayer; // مشغل الفيديو
    public VideoClip[] videoClips; // مصفوفة مقاطع الفيديو
    public Button nextButton; // زر التقدم
    public GameObject[] objectsToHide; // الكائنات التي سيتم إخفاؤها
    public GameObject[] objectsToShow; // الكائنات التي سيتم عرضها
    public GameObject specialObject; // الكائن الذي سيتم عرضه بعد وقت قصير من تشغيل الفيديو الأخير
    public Button button1; // الزر الأول
    public Button button2; // الزر الثاني
    public VideoClip additionalVideoClip; // الفيديو الجديد الذي سيتم عرضه بعد الضغط على الزرين
    public VideoClip fallbackVideoClip; // الفيديو الذي سيتم عرضه إذا انتهى الفيديو الأخير دون الضغط على الزرين
    public AudioClip fallbackAudioClip; // الصوت الذي سيتم تشغيله مع فيديو fallbackVideoClip

    public AudioSource mainAudioSource; // مصدر الصوت الرئيسي
    public AudioSource loopedAudioSource; // مصدر الصوت المتكرر
    public AudioSource fallbackAudioSource; // مصدر الصوت الجديد

    public AudioClip firstVideoAudio; // صوت الفيديو الأول
    public AudioClip loopedAudio; // صوت التكرار

    public int wallNumber = 17; // رقم الجدار الافتراضي
    public int additionalWallNumber = 18; // رقم الجدار للفيديو الإضافي
    public int fallbackWallNumber = 19; // رقم الجدار للفيديو البديل
    public float timeToShowSpecialObject = 1f; // الوقت بعد بدء تشغيل الفيديو الأخير لعرض الكائن الخاص

    private int currentVideoIndex = 0; // مؤشر الفيديو الحالي
    private bool isSpecialObjectShown = false; // للتحقق من ما إذا تم عرض الكائن الخاص
    private bool isButton1Pressed = false; // للتحقق من الضغط على الزر الأول
    private bool isButton2Pressed = false; // للتحقق من الضغط على الزر الثاني

    void Start()
    {
        if (videoPlayer != null && videoClips.Length > 0)
        {
            videoPlayer.clip = videoClips[currentVideoIndex];
            videoPlayer.loopPointReached += OnVideoEnd;
            videoPlayer.isLooping = false;
            videoPlayer.Play();
            PlayAudioForCurrentVideo();
        }

        if (nextButton != null)
        {
            nextButton.onClick.AddListener(PlayNextVideo);
        }

        if (button1 != null)
        {
            button1.onClick.AddListener(OnButton1Pressed);
        }

        if (button2 != null)
        {
            button2.onClick.AddListener(OnButton2Pressed);
        }
    }

    void Update()
    {
        // لا حاجة لاستخدام هذه الدالة هنا بعد التعديل
    }

    void PlayNextVideo()
    {
        currentVideoIndex++;
        isSpecialObjectShown = false; // إعادة تعيين العلم عند تغيير الفيديو

        if (currentVideoIndex < videoClips.Length)
        {
            videoPlayer.clip = videoClips[currentVideoIndex];
            videoPlayer.isLooping = (currentVideoIndex >= 1 && currentVideoIndex <= 10);
            videoPlayer.Play();
            PlayAudioForCurrentVideo();

            // إخفاء زر التقدم إذا كان الفيديو الحالي هو الأخير
            if (currentVideoIndex == videoClips.Length - 1)
            {
                nextButton.gameObject.SetActive(false);
                // عرض الكائن الخاص بعد تأخير بسيط
                Invoke("ShowSpecialObject", timeToShowSpecialObject);
            }
        }
        else
        {
            EndOfVideos(wallNumber);
        }
    }

    void PlayAudioForCurrentVideo()
    {
        if (mainAudioSource == null || loopedAudioSource == null) return;

        if (currentVideoIndex == 0)
        {
            mainAudioSource.clip = firstVideoAudio;
            mainAudioSource.loop = false;
            mainAudioSource.Play();
            loopedAudioSource.Stop();
        }
        else if (currentVideoIndex >= 1 && currentVideoIndex <= 11)
        {
            if (!loopedAudioSource.isPlaying)
            {
                loopedAudioSource.clip = loopedAudio;
                loopedAudioSource.loop = true;
                loopedAudioSource.Play();
            }
            mainAudioSource.Stop();
        }
        else
        {
            mainAudioSource.Stop();
            loopedAudioSource.Stop();
        }
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        if (currentVideoIndex >= 1 && currentVideoIndex <= 10)
        {
            videoPlayer.Play();
        }
        else if (currentVideoIndex == videoClips.Length - 1)
        {
            // إذا انتهى الفيديو الأخير ولم يتم الضغط على الزرين، عرض الفيديو الجديد
            if (!isButton1Pressed && !isButton2Pressed && fallbackVideoClip != null)
            {
                PlayFallbackVideo();
            }
        }
        else
        {
            PlayNextVideo();
        }
    }

    void PlayFallbackVideo()
    {
        videoPlayer.clip = fallbackVideoClip;
        videoPlayer.isLooping = false;
        videoPlayer.Play();

        // إخفاء الكائن الخاص والأزرار
        specialObject.SetActive(false);
        button1.gameObject.SetActive(false);
        button2.gameObject.SetActive(false);

        // إيقاف الصوت المتكرر
        loopedAudioSource.Stop();

        // تشغيل الصوت الجديد
        if (fallbackAudioSource != null && fallbackAudioClip != null)
        {
            fallbackAudioSource.clip = fallbackAudioClip;
            fallbackAudioSource.Play();
        }

        // إعداد حدث انتهاء الفيديو للانتقال إلى الجدار المحدد
        videoPlayer.loopPointReached += (VideoPlayer vp) => EndOfVideos(fallbackWallNumber);
    }

    void EndOfVideos(int targetWallNumber)
    {
        SetActiveState(objectsToHide, false);
        SetActiveState(objectsToShow, true);

        mainAudioSource?.Stop();
        loopedAudioSource?.Stop();
        fallbackAudioSource?.Stop();

        DisplayImage displayImageScript = FindObjectOfType<DisplayImage>();

        if (displayImageScript != null)
        {
            string buttonType = $"GoToWall{targetWallNumber}";
            displayImageScript.OnButtonClick((DisplayImage.ButtonType)Enum.Parse(typeof(DisplayImage.ButtonType), buttonType));
        }
    }

    void SetActiveState(GameObject[] objects, bool state)
    {
        foreach (GameObject obj in objects)
        {
            obj.SetActive(state);
        }
    }

    void ShowSpecialObject()
    {
        specialObject.SetActive(true);
        isSpecialObjectShown = true;
    }

    void OnButton1Pressed()
    {
        isButton1Pressed = true;
    }

    void OnButton2Pressed()
    {
        isButton2Pressed = true;
        if (isButton1Pressed && additionalVideoClip != null)
        {
            videoPlayer.clip = additionalVideoClip;
            videoPlayer.isLooping = false;
            videoPlayer.Play();

            // إخفاء الكائن الخاص والأزرار
            specialObject.SetActive(false);
            button1.gameObject.SetActive(false);
            button2.gameObject.SetActive(false);

            // إيقاف الصوت المتكرر
            loopedAudioSource.Stop();

            // إعداد حدث انتهاء الفيديو للانتقال إلى الجدار المحدد
            videoPlayer.loopPointReached += (VideoPlayer vp) => EndOfVideos(additionalWallNumber);
        }
    }


}
