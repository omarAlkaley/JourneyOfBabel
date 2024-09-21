using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class CustomVideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer1; // مشغل الفيديو الأول
    public VideoPlayer videoPlayer2; // مشغل الفيديو الثاني
    public Button buttonToShow; // الزر الذي سيظهر بعد فترة محددة
    public GameObject objectToShow; // الكائن الذي سيظهر بعد انتهاء فترة معينة من الفيديو
    public GameObject objectToShow1; // الكائن الذي سيتم إخفاؤه عند انتهاء الفيديو الثاني
    public GameObject objectToShow2; // الكائن الذي سيظهر عند انتهاء الفيديو الثاني
    public GameObject objectToShow3; // الكائن الذي سيتم إخفاؤه عند انتهاء الفيديو الثاني
    public GameObject objectToShow4;
    public float timeToShowButton = 10f; // الوقت بالثواني لظهور الزر

    private bool buttonShown = false; // حالة تظهر ما إذا كان الزر قد ظهر بالفعل أم لا
    public SaveLoadManager saveLoadManager; // مرجع إلى سكربت حفظ/استرجاع البيانات

    void Start()
    {
        // ربط وظيفة OnVideoEnded1 ليتم استدعاؤها عند انتهاء الفيديو الأول
        videoPlayer1.loopPointReached += OnVideoEnded1;
        // ربط وظيفة OnVideoEnded2 ليتم استدعاؤها عند انتهاء الفيديو الثاني
        videoPlayer2.loopPointReached += OnVideoEnded2;
    }

    void Update()
    {
        // التحقق مما إذا كان الزر قد ظهر بالفعل وإذا كان الوقت المحدد لظهوره قد تحقق في الفيديو الأول
        if (!buttonShown && videoPlayer1.time >= timeToShowButton)
        {
            ShowButton();
        }
    }

    void ShowButton()
    {
        // إظهار الزر والكائن المحدد وتغيير حالة ظهور الزر
        buttonToShow.gameObject.SetActive(true);
        objectToShow.SetActive(true);
        buttonShown = true;
    }

    void OnVideoEnded1(VideoPlayer vp)
    {
        // إخفاء مشغل الفيديو الأول
        videoPlayer1.gameObject.SetActive(false);
        buttonShown = false;
        objectToShow4.SetActive(true);
        // تشغيل الفيديو الثاني
        videoPlayer2.gameObject.SetActive(true);
        videoPlayer2.Play();
    }

    void OnVideoEnded2(VideoPlayer vp)
    {
        // إخفاء مشغل الفيديو الثاني
        videoPlayer2.gameObject.SetActive(false);
        // إدارة ظهور وإخفاء الكائنات الأخرى عند انتهاء الفيديو الثاني
        objectToShow1.SetActive(false);
        objectToShow2.SetActive(true);
        objectToShow3.SetActive(false);

        // استدعاء دالة لتغيير الجدار إلى 42 عند انتهاء الفيديو الثاني
        saveLoadManager.ChangeWall(42);
    }
}
