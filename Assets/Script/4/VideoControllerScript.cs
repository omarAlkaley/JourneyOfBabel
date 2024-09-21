using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoControllerScript : MonoBehaviour
{
    public VideoPlayer videoPlayer; // مشغل الفيديو
    public VideoClip[] videoClips; // مصفوفة مقاطع الفيديو
    public Button nextButton; // زر التقدم
    public GameObject[] objectsToHide; // الكائنات التي سيتم إخفاؤها
    public GameObject[] objectsToShow; // الكائنات التي سيتم عرضها

    public AudioSource audioSource; // مصدر الصوت الأساسي
    public AudioSource additionalAudioSource; // مصدر الصوت الإضافي
    public AudioClip firstVideoAudio; // صوت الفيديو الأول
    public AudioClip loopedAudio; // صوت التكرار
    public AudioClip loopedAudio1; // صوت التكرار الإضافي
    public AudioClip lastVideoAudio; // صوت الفيديو الأخير

    public int wallNumber = 17; // رقم الجدار
    public GameObject myGameObject1; // الكائن الذي سيتم إخفاؤه في الفيديو الثاني

    private int currentVideoIndex = 0; // مؤشر الفيديو الحالي
    private bool isLoopedAudioPlaying = false; // علم لتتبع تشغيل الصوت المتكرر
    private bool isLoopedAudio1Playing = false; // علم لتتبع تشغيل الصوت المتكرر الإضافي

    void Start()
    {
        // التأكد من تعيين مشغل الفيديو ومقاطع الفيديو
        if (videoPlayer != null && videoClips.Length > 0)
        {
            videoPlayer.clip = videoClips[currentVideoIndex];
            videoPlayer.loopPointReached += OnVideoEnd;
            videoPlayer.isLooping = (currentVideoIndex == 1); // تكرار الفيديو الثاني
            videoPlayer.Play();
            PlayAudioForCurrentVideo();
        }

        // التأكد من تعيين زر التقدم وإضافة المستمع
        if (nextButton != null)
        {
            nextButton.onClick.AddListener(PlayNextVideo);
        }
    }

    void PlayNextVideo()
    {
        currentVideoIndex++;
        if (currentVideoIndex < videoClips.Length)
        {
            videoPlayer.clip = videoClips[currentVideoIndex];
            videoPlayer.isLooping = (currentVideoIndex == 1 || (currentVideoIndex >= 2 && currentVideoIndex <= 5)); // تكرار الفيديوهات 2 إلى 5
            PlayAudioForCurrentVideo();
            videoPlayer.Play();
        }
        else
        {
            EndOfVideos();
        }
    }

    void PlayAudioForCurrentVideo()
    {
        if (audioSource != null)
        {
            switch (currentVideoIndex)
            {
                case 0:
                    if (videoPlayer.isPlaying)
                    {
                        audioSource.clip = firstVideoAudio;
                        audioSource.loop = false;
                        audioSource.Play();
                        isLoopedAudioPlaying = false;
                    }
                    break;
                case 1:
                    myGameObject1.SetActive(false);
                    if (!isLoopedAudioPlaying)
                    {
                        audioSource.clip = loopedAudio;
                        audioSource.loop = true;
                        audioSource.Play();
                        isLoopedAudioPlaying = true;
                    }
                    if (!isLoopedAudio1Playing && additionalAudioSource != null)
                    {
                        additionalAudioSource.clip = loopedAudio1;
                        additionalAudioSource.loop = true;
                        additionalAudioSource.Play();
                        isLoopedAudio1Playing = true;
                    }
                    break;
                case 6:
                    audioSource.clip = lastVideoAudio;
                    audioSource.loop = false;
                    audioSource.Play();
                    if (additionalAudioSource != null)
                    {
                        additionalAudioSource.Stop();
                    }
                    isLoopedAudioPlaying = false;
                    isLoopedAudio1Playing = false;
                    break;
                default:
                    if (!isLoopedAudioPlaying)
                    {
                        audioSource.clip = loopedAudio;
                        audioSource.loop = true;
                        audioSource.Play();
                        isLoopedAudioPlaying = true;
                    }
                    if (!isLoopedAudio1Playing && additionalAudioSource != null)
                    {
                        additionalAudioSource.clip = loopedAudio1;
                        additionalAudioSource.loop = true;
                        additionalAudioSource.Play();
                        isLoopedAudio1Playing = true;
                    }
                    break;
            }
        }
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        // إذا كان الفيديو الحالي هو الفيديو الثاني إلى السادس، جعله يعمل في وضع التكرار
        if (currentVideoIndex == 1 || (currentVideoIndex >= 2 && currentVideoIndex <= 5))
        {
            videoPlayer.isLooping = true;
            videoPlayer.Play(); // تأكد من إعادة تشغيل الفيديو
        }
        else
        {
            PlayNextVideo();
        }
    }

    void EndOfVideos()
    {
        // إخفاء الكائنات المحددة
        foreach (GameObject obj in objectsToHide)
        {
            obj.SetActive(false);
        }

        // عرض الكائنات المحددة
        foreach (GameObject obj in objectsToShow)
        {
            obj.SetActive(true);
        }

        // إيقاف الصوت عند انتهاء جميع مقاطع الفيديو
        if (audioSource != null)
        {
            audioSource.Stop();
        }
        if (additionalAudioSource != null)
        {
            additionalAudioSource.Stop();
        }

        DisplayImage displayImageScript = FindObjectOfType<DisplayImage>();

        // إذا تم العثور على السكربت، قم بتعيين الجدار الحالي إلى الرقم المحدد
        if (displayImageScript != null)
        {
            string buttonType = $"GoToWall{wallNumber}";
            displayImageScript.OnButtonClick((DisplayImage.ButtonType)Enum.Parse(typeof(DisplayImage.ButtonType), buttonType));
        }
    }

    void OnDestroy()
    {
        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached -= OnVideoEnd;
        }

        if (nextButton != null)
        {
            nextButton.onClick.RemoveListener(PlayNextVideo);
        }
    }
}
