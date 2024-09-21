using Unity.VisualScripting;
using UnityEngine;

public class ImageSequence : MonoBehaviour
{
    public Sprite[] sprites; // قم بتعيين السبرايتات هنا في واجهة Unity
    public float changeInterval = 1.0f; // تعيين الوقت بين تغيير الصور
    public GameObject hidn;
    public GameObject hidn1;
    public GameObject hidn2;
    private SpriteRenderer spriteRenderer;
    private int currentSpriteIndex = 0;

    public AudioSource audioSource;
    public AudioClip fadeInSound;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource.PlayOneShot(fadeInSound);
        // إعداد تكرار تنفيذ دالة ChangeSprite بانتظام
        InvokeRepeating("ChangeSprite", 0.0f, changeInterval);
    }

    void ChangeSprite()
    {
        // تغيير السبرايت إلى السبرايت التالي في التسلسل
        spriteRenderer.sprite = sprites[currentSpriteIndex];

        // التحقق من الفهرس
        if (currentSpriteIndex < sprites.Length - 1)
        {
            // إذا لم يكن آخر سبرايت في التسلسل، قم بزيادة الفهرس بشكل عادي
            currentSpriteIndex++;
            
        }
        else
        {
            // إذا كان آخر سبرايت في التسلسل، قم بإعادة تعيين الفهرس إلى الصورة الأولى
            currentSpriteIndex = 5;
            Invoke("StopAudio", 0.5f);

            if (hidn != null)
            {
                hidn.SetActive(true);
                hidn1.SetActive(false);
                hidn2.SetActive(true);

            }
            
        }



    }


    void StopAudio()
    {
        // قم بإيقاف التشغيل لصوت بعد نصف ثانية
        audioSource.Stop();
    }
}
