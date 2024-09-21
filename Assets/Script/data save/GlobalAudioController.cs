using UnityEngine;
using UnityEngine.UI;

public class GlobalAudioController : MonoBehaviour
{
    public Slider volumeSlider1;  // سلايدر للتحكم بالصوت 1
    public Slider volumeSlider2;  // سلايدر للتحكم بالصوت 2
    public Toggle muteToggle1;    // زر للتفعيل/التعطيل 1
    public Toggle muteToggle2;    // زر للتفعيل/التعطيل 2

    private bool isMuted = false;

    void Start()
    {
        // تعيين القيم الافتراضية
        volumeSlider1.value = AudioListener.volume;
        volumeSlider2.value = AudioListener.volume;
        isMuted = AudioListener.volume == 0;
        muteToggle1.isOn = isMuted;
        muteToggle2.isOn = isMuted;

        // ربط الأحداث
        volumeSlider1.onValueChanged.AddListener(SetVolume);
        volumeSlider2.onValueChanged.AddListener(SetVolume);
        muteToggle1.onValueChanged.AddListener(ToggleMute);
        muteToggle2.onValueChanged.AddListener(ToggleMute);
    }

    // تحديث مستوى الصوت بناءً على قيمة السلايدر
    public void SetVolume(float volume)
    {
        if (!isMuted)
        {
            AudioListener.volume = volume;
            volumeSlider1.value = volume;
            volumeSlider2.value = volume;
        }
    }

    // كتم/إلغاء كتم الصوت
    public void ToggleMute(bool isMuted)
    {
        this.isMuted = isMuted;
        AudioListener.volume = isMuted ? 0 : volumeSlider1.value;
        muteToggle1.isOn = isMuted;
        muteToggle2.isOn = isMuted;
    }
}
