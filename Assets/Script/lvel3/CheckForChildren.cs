using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.Video;

public class CheckForChildren : MonoBehaviour
{
    bool conditionMet = false; // متغير للتحقق من تحقق الشرط
    public VideoPlayer videoPlayer;
    public GameObject gameObject1;
    public GameObject gameObject2;
    public GameObject gameObject3;
    public GameObject gameObject4;
    public GameObject gameObject5;
    public GameObject gameObject6;
    public GameObject gameObject7;
    public GameObject gameObject8;





    // تحديث السكربت بشكل دوري


    void Start()
    {
       
        videoPlayer.loopPointReached += OnVideoFinished;
    }
    void Update()
    {
      
        // افحص الأطفال الفرعية فقط إذا لم يتم تحقق الشرط بالفعل
        if (!conditionMet)
        {
            // افحص الأطفال الفرعية
            Transform[] children = GetComponentsInChildren<Transform>();

            bool child1Exists = false;
            bool child2Exists = false;
            bool child3Exists = false;
            bool child4Exists = false; // إضافة شرط جديد

            foreach (Transform child in children)
            {
                if (child.name == "9")
                {
                    child1Exists = true;
                }
                else if (child.name == "11")
                {
                    child2Exists = true;
                }
                else if (child.name == "10")
                {
                    child3Exists = true;
                }
                else if (child.name == "4") // شرط جديد للتحقق من وجود الطفل الفرعي 4
                {
                    child4Exists = true;
                }
            }

            // فحص إذا كانت الأطفال الفرعية موجودة
            if (child1Exists && child2Exists && child3Exists && child4Exists) // إضافة شرط جديد هنا
            {
                Debug.LogError("مرحبااا");
                PlayVideo();
                conditionMet = true; // تحقق الشرط، قم بتعيين المتغير للإيقاف
            }
        }
    }

    private void PlayVideo()
    {
        if (videoPlayer != null)
        {
            gameObject2.SetActive(false);
            gameObject4.SetActive(false);
            gameObject8.SetActive(false);

            Destroy(gameObject5);
            Destroy(gameObject6);
            Destroy(gameObject7);



            videoPlayer.gameObject.SetActive(true);
            videoPlayer.Play();



        }
    }






    void OnVideoFinished(VideoPlayer vp)
    {
        // عند انتهاء الفيديو، قم بإخفاء وحذف GameObject الخاص به
        videoPlayer.gameObject.SetActive(false);
        Destroy(videoPlayer.gameObject);

        Destroy(gameObject1);
        gameObject2.SetActive(true);
        gameObject3.SetActive(true);
        gameObject4.SetActive(true);
        gameObject8.SetActive(true);


    }



}