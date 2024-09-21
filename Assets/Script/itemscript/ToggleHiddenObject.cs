using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class ToggleHiddenObjects : MonoBehaviour
{

    private ButtonPair activeButtonPair;
    public ButtonPair[] buttonPairs;
    public VideoPlayer videoPlayer; // ربط VideoPlayer في Inspector
    private GameObject displayImage;
    public float timeToDestroy = 5f;
    public GameObject[] gameObject2;
    public GameObject[] gameObject1;
    public GameObject gameObject3;
    public GameObject gameObject4;
    public GameObject gameObject5;


    private bool videoHidden = true; // حالة الفيديو: مخفي أو ظاهر

    public DisplayImage currentDisplay;
    public float initialCameraSize;
    public Vector3 initialCameraPosition;
    public ZoomInObject[] zoomInObjects;
    public AudioSource source;
    
    public AudioClip incorrect1;
    public int wallNumber = 17;

    void Awake()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();
        initialCameraSize = Camera.main.orthographicSize;
        initialCameraPosition = Camera.main.transform.position;

        zoomInObjects = FindObjectsOfType<ZoomInObject>();
    }

    private void Start()
    {
        displayImage = GameObject.Find("displayImage");
        videoPlayer.loopPointReached += OnVideoFinished;
    }

    // تمثيل تبديل حالة الكائن المخفي عند النقر على الزر الثاني
    public void OnButtonPress(Button button)
    {
        foreach (ButtonPair pair in buttonPairs)
        {
            if (button == pair.firstButton)
            {
                if (activeButtonPair == null)
                {
                    activeButtonPair = pair;
                    break;
                }
                else if (activeButtonPair != pair)
                {
                    // إذا كان الزوج النشط مختلفًا، اعتبر الزر الأول كفعالة
                    activeButtonPair.firstButton.onClick.Invoke();
                    activeButtonPair = pair;
                    break;
                }
            }
            else if (button == pair.secondButton)
            {
                if (activeButtonPair != null && activeButtonPair == pair)
                {
                    source.clip = incorrect1;
                    source.Play();
                    ToggleObjects(activeButtonPair.associatedObject, activeButtonPair.associatedObject2);

                    // إذا تم عرض الكائن، قم بحذف الزرين
                    if (activeButtonPair.associatedObject.activeSelf)
                    {
                        Destroy(activeButtonPair.firstButton.gameObject);
                        Destroy(activeButtonPair.secondButton.gameObject);
                    }

                    // إذا كانت جميع الكائنات مظهرة، وكان الفيديو مخفيًا، قم بتشغيل الفيديو
                    if (AllObjectsShown() && videoHidden)
                    {
                        Invoke("SetActivegameObject", timeToDestroy);
                    }
                }
            }
        }
    }

    // تبديل حالة الكائنات
    private void ToggleObjects(GameObject obj1, GameObject obj2)
    {
        obj1.SetActive(!obj1.activeSelf);
        obj2.SetActive(!obj2.activeSelf);
    }

    // اختبار ما إذا كانت جميع الكائنات مظهرة
    private bool AllObjectsShown()
    {
        foreach (ButtonPair pair in buttonPairs)
        {
            if (!pair.associatedObject.activeSelf)
            {
                return false;
            }
        }
        return true;
    }

    // تشغيل الفيديو
    private void PlayVideo()
    {
        if (videoPlayer != null)
        {
            gameObject4.SetActive(false);

            videoPlayer.gameObject.SetActive(true);
            videoPlayer.Play();
            Destroy(gameObject3.gameObject);
            videoHidden = false;
        }
    }

    // معالج الانتهاء من الفيديو
    void OnVideoFinished(VideoPlayer vp)
    {
        videoPlayer.gameObject.SetActive(false);
        Destroy(videoPlayer.gameObject);

        gameObject5.SetActive(true);

        source.Stop();
        DisplayImage displayImageScript = FindObjectOfType<DisplayImage>();

        if (displayImageScript != null)
        {
            string buttonType = $"GoToWall{wallNumber}";
            displayImageScript.OnButtonClick((DisplayImage.ButtonType)Enum.Parse(typeof(DisplayImage.ButtonType), buttonType));
        }
    }

    // تنفيذ الإجراءات بعد فتح القفل
    void ExecuteAfterUnlockEvent()
    {
        if (currentDisplay.CurrentState == DisplayImage.State.idle) return;

        if (currentDisplay.CurrentState == DisplayImage.State.zoom)
        {
            currentDisplay.CurrentState = DisplayImage.State.normal;

            foreach (var zoomInObject in zoomInObjects)
            {
                zoomInObject.gameObject.layer = 0;
            }

            Camera.main.orthographicSize = initialCameraSize;
            Camera.main.transform.position = initialCameraPosition;
        }
        else
        {
            currentDisplay.CurrentState = DisplayImage.State.normal;

            Camera.main.orthographicSize = initialCameraSize;
            Camera.main.transform.position = initialCameraPosition;

            foreach (var zoomInObject in zoomInObjects)
            {
                zoomInObject.gameObject.layer = 0;
            }
        }
    }

    private void HideGameObject2()
    {
        if (gameObject2 != null && gameObject2.Length > 0)
        {
            foreach (GameObject obj in gameObject2)
            {
                obj.SetActive(false);
            }
        }
    }

    private void HideGameObject1()
    {
        if (gameObject1 != null && gameObject1.Length > 0)
        {
            foreach (GameObject obj in gameObject1)
            {
                obj.SetActive(true);
            }
        }
    }

    void SetActivegameObject()
    {
        PlayVideo();

        source.Play();
        ExecuteAfterUnlockEvent();


        HideGameObject2();
        HideGameObject1();
    }
}
