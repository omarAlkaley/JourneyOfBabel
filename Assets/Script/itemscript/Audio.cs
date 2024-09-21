using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Audio : MonoBehaviour
{
    public AudioSource audioSource;

    public Toggle muteToggle;
    public Slider volumeSlider;

    // يتم استدعاء دالة Start عند تشغيل السكريبت
    void Start()
    {
        // الحصول على مكون الصوت المرفق بالكائن
        audioSource = GetComponent<AudioSource>();

        // تأكيد بقاء الكائن عند تغيير المشهد
        

        // تعيين قيمة الميوت من Toggle
        muteToggle.isOn = audioSource.mute;

        // تعيين قيمة مستوى الصوت من Slider
        volumeSlider.value = audioSource.volume;

        // تعيين استماع لحدث تغيير في Toggle
        muteToggle.onValueChanged.AddListener(OnMuteToggleChanged);

        // تعيين استماع لحدث تغيير في Slider
        volumeSlider.onValueChanged.AddListener(OnVolumeSliderChanged);
    }

    // دالة تستدعى عند تغيير قيمة الميوت في Toggle
    void OnMuteToggleChanged(bool isMuted)
    {
        audioSource.mute = isMuted;
    }

    // دالة تستدعى عند تغيير قيمة مستوى الصوت في Slider
    void OnVolumeSliderChanged(float volume)
    {
        audioSource.volume = volume;
    }
}
