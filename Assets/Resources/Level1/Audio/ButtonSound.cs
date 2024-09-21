using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    public Button yourButton; // رابط الزر
    public AudioClip sound; // رابط ملف الصوت
    private AudioSource audioSource;
    private bool hasPlayed = false; // متغير لتتبع ما إذا كان الصوت قد تم تشغيله بالفعل

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = sound;
        yourButton.onClick.AddListener(PlaySound);
        audioSource.loop = false; // تأكد من أن الصوت لن يتم تشغيله بشكل متكرر
    }

    void PlaySound()
    {
        if (!hasPlayed)
        {
            audioSource.Play();
            hasPlayed = true; // تعيين المتغير إلى true بعد تشغيل الصوت
            StartCoroutine(RemoveAudioClipAfterPlaying());
        }
    }

    private IEnumerator RemoveAudioClipAfterPlaying()
    {
        // الانتظار حتى انتهاء تشغيل الصوت
        yield return new WaitForSeconds(audioSource.clip.length);
        audioSource.clip = null; // حذف الصوت بعد انتهاء تشغيله
    }
}
