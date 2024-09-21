using UnityEngine;

public class NumberLock : MonoBehaviour
{
    public string Password;
    public GameObject OpenLockerSprite;
    private GameObject displayImage;
    private bool isOpen;
    private bool canChangeNumbers = true;

    public delegate void LockerUnlockedEventHandler();
    public static event LockerUnlockedEventHandler OnLockerUnlocked;

    public GameObject Butoon;
    public GameObject[] gameObject2;
    public GameObject[] gameObject1;
  //  public GameObject gameObject3;
  //  public GameObject gameObject4;


    public AudioSource source;
    public AudioClip[] correct;
    public AudioClip incorrect;

    [HideInInspector]
    public Sprite[] numberSprites1;
    [HideInInspector]
    public Sprite[] numberSprites2;
    [HideInInspector]
    public Sprite[] numberSprites3;
    [HideInInspector]
    public Sprite[] numberSprites4;

    [HideInInspector]
    public int[] currentIndividualIndex = { 0, 0, 0, 0 };

    public DisplayImage currentDisplay;
    public float initialCameraSize;
    public Vector3 initialCameraPosition;
    public ZoomInObject[] zoomInObjects;

    void Awake()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();
        initialCameraSize = Camera.main.orthographicSize;
        initialCameraPosition = Camera.main.transform.position;

        zoomInObjects = FindObjectsOfType<ZoomInObject>();
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
        Butoon.SetActive(false);
        isOpen = false;
        LoadAllNumberSprites();

        // Set initial sprites for each slot
        transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = numberSprites1[0];
        transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = numberSprites2[0];
        transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = numberSprites3[0];
        transform.GetChild(3).GetComponent<SpriteRenderer>().sprite = numberSprites4[0];
    }

    void Update()
    {
        OpenLocker();
        LayerManager();
    }

    void LoadAllNumberSprites()
    {
        numberSprites1 = Resources.LoadAll<Sprite>("Sprites/numbers1");
        numberSprites2 = Resources.LoadAll<Sprite>("Sprites/numbers2");
        numberSprites3 = Resources.LoadAll<Sprite>("Sprites/numbers3");
        numberSprites4 = Resources.LoadAll<Sprite>("Sprites/numbers4");
    }

    bool VerifyCorrectCode()
    {
        bool correct = true;

        if (!canChangeNumbers)
        {
            return false;
        }

        for (int i = 0; i < 4; i++)
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
            default:
                return null;
        }
    }

    void OpenLocker()
    {
        if (isOpen) return;

        if (VerifyCorrectCode())
        {
           

            float delay = 1f; // تعديل هذا الرقم حسب احتياجاتك
            Invoke("isOpen2", delay);

        }
    }

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
            currentDisplay.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/wall" + currentDisplay.CurrentWall);
            currentDisplay.CurrentState = DisplayImage.State.normal;

            Camera.main.orthographicSize = initialCameraSize;
            Camera.main.transform.position = initialCameraPosition;

            foreach (var zoomInObject in zoomInObjects)
            {
                zoomInObject.gameObject.layer = 0;
            }
        }
    }

    void MoveCameraToTargetPosition()
    {
        mainCamera.transform.position = targetCameraPosition;
    }

    void ResetCameraPosition()
    {
        // Implement the camera reset logic if needed
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
    private void isOpen2()
    {
        isOpen = true;
        OpenLockerSprite.SetActive(true);
        Butoon.SetActive(true);
        canChangeNumbers = false;
        source.clip = incorrect;
        source.Play();
        float delay = 0f; // تعديل هذا الرقم حسب احتياجاتك
        Invoke("HideGameObject2", delay);
        Invoke("HideGameObject1", delay);

        ExecuteAfterUnlockEvent();
        MoveCameraToTargetPosition();
        Invoke("ResetCameraPosition", 1f);
        // gameObject3.SetActive(false);
       // gameObject4.SetActive(false);

        if (OnLockerUnlocked != null)
        {
            OnLockerUnlocked();
        }

    }


}

