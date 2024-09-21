
// في MaskLock
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MaskLock : MonoBehaviour
{
    public string Password;
    public GameObject OpenLockerSprite;
    private GameObject displayImage;
    private bool isOpen;
    private bool canChangeNumbers = true;

    public delegate void LockerUnlockedEventHandler();
    public static event LockerUnlockedEventHandler OnLockerUnlocked;

    public AudioSource source;
    public AudioClip incorrect;

    // public VideoPlayer videoPlayer;

    public GameObject gameObject1;


    public GameObject[] gameObject2;


    [HideInInspector]
    public Sprite[] numberSprites1;
    [HideInInspector]
    public Sprite[] numberSprites2;
    [HideInInspector]
    public Sprite[] numberSprites3;
    [HideInInspector]
    public Sprite[] numberSprites4;
    [HideInInspector]
    public Sprite[] numberSprites5;
    [HideInInspector]
    public Sprite[] numberSprites6;

    [HideInInspector]
    public int[] currentIndividualIndex = { 0, 0, 0, 0, 0, 0 };

    public DisplayImage currentDisplay;
    

    void Awake()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();
      

      
    }

    public bool CanChangeNumbers
    {
        get { return canChangeNumbers; }
    }

    public Camera mainCamera;
    public Vector3 targetCameraPosition = new Vector3(0.1f, -0.99f, 3.314137f);

    void Start()
    {
        displayImage = GameObject.Find("displayImage");
        OpenLockerSprite.SetActive(false);
        isOpen = false;
        LoadAllNumberSprites();

        // Set initial sprites for each slot
        transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = numberSprites1[0];
        transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = numberSprites2[0];
        transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = numberSprites3[0];
        transform.GetChild(3).GetComponent<SpriteRenderer>().sprite = numberSprites4[0];
        transform.GetChild(4).GetComponent<SpriteRenderer>().sprite = numberSprites5[0];
        transform.GetChild(5).GetComponent<SpriteRenderer>().sprite = numberSprites6[0];

       // videoPlayer.loopPointReached += OnVideoFinished;
    }

    void Update()
    {
        OpenLocker();
        LayerManager();
    }

    void LoadAllNumberSprites()
    {
        numberSprites1 = Resources.LoadAll<Sprite>("Sprites/numberss1");
        numberSprites2 = Resources.LoadAll<Sprite>("Sprites/numberss2");
        numberSprites3 = Resources.LoadAll<Sprite>("Sprites/numberss3");
        numberSprites4 = Resources.LoadAll<Sprite>("Sprites/numberss4");
        numberSprites5 = Resources.LoadAll<Sprite>("Sprites/numberss5");
        numberSprites6 = Resources.LoadAll<Sprite>("Sprites/numberss6");
    }

    bool VerifyCorrectCode()
    {
        bool correct = true;

        if (!canChangeNumbers)
        {
            return false;
        }

        for (int i = 0; i < 6; i++)
        {
            // التحقق من وجود الأطفال قبل الوصول إليهم
            if (i < transform.childCount)
            {
                Sprite[] currentSprites = GetNumberSpritesForIndex(i);
                if (Password[i] != transform.GetChild(i).GetComponent<SpriteRenderer>().sprite.name.Substring(transform.GetChild(i).GetComponent<SpriteRenderer>().sprite.name.Length - 1)[0])
                {
                    correct = false;
                }
            }
            else
            {
                // يمكنك إضافة رسالة تحذير أو تعديل السلوك بحسب احتياجاتك
                Debug.LogWarning("Child index " + i + " is out of bounds.");
                correct = false;
            }
        }

        if (correct)
        {
            canChangeNumbers = false;
        }

        return correct;
    }


    public Sprite[] GetNumberSpritesForIndex(int index)
    {
        switch (index)
        {
            case 0:
                return numberSprites1;
            case 1:
                return numberSprites2;
            case 2:
                return numberSprites3;
            case 3:
                return numberSprites4;
            case 4:
                return numberSprites5;
            case 5:
                return numberSprites6;
            default:
                return null;
        }
    }

    void OpenLocker()
    {
        if (isOpen) return;

        if (VerifyCorrectCode())
        {
            isOpen = true;
            OpenLockerSprite.SetActive(true);
            canChangeNumbers = false;
            
          //  PlayVideo();
            gameObject1.SetActive(true);

            float delay = 0f; // تعديل هذا الرقم حسب احتياجاتك
            Invoke("HideGameObject2", delay);

            source.clip = incorrect;
            source.Play();


            if (OnLockerUnlocked != null)
            {
                OnLockerUnlocked();
            }
        }
    }

  

 

   

    void LayerManager()
    {
        if (isOpen) return;

        if (displayImage.GetComponent<DisplayImage>().CurrentState == DisplayImage.State.normal)
        {
            foreach (Transform child in transform)
            {
                child.gameObject.layer = 2;
            }
        }
        else
        {
            foreach (Transform child in transform)
            {
                child.gameObject.layer = 0;
            }
        }
    }

   // private void PlayVideo()
   // {
   //     if (videoPlayer != null)
     //   {
     ///       videoPlayer.gameObject.SetActive(true);
     //       videoPlayer.Play();

           
          
       // }
   // }

    // دالة لإخفاء gameObject2
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






   // void OnVideoFinished(VideoPlayer vp)
   // {
        // عند انتهاء الفيديو، قم بإخفاء وحذف GameObject الخاص به
      //  videoPlayer.gameObject.SetActive(false);
      //  Destroy(videoPlayer.gameObject);

      //  gameObject1.SetActive(true);
   // }



}