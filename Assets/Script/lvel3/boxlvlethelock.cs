using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bboxlvlethelock : MonoBehaviour
{
    public string Password;
    public GameObject OpenLockerSprite;
    private GameObject displayImage;
    private bool isOpen;
    private bool canChangeNumbers = true;

    public AudioClip incorrect;
    public AudioSource source;

    public delegate void LockerUnlockedEventHandler();
    public static event LockerUnlockedEventHandler OnLockerUnlocked;





    public GameObject gameObject1;
    public GameObject gameObject2;
    public GameObject gameObject3;





    [HideInInspector]
    public Sprite[] numberSprites1;
    [HideInInspector]
    public Sprite[] numberSprites2;
    [HideInInspector]
    public Sprite[] numberSprites3;
    [HideInInspector]
    public Sprite[] numberSprites4;



    [HideInInspector]
    public int[] currentIndividualIndex = { 0, 0, 0, 0, };

    public DisplayImage currentDisplay;



    void Awake()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();

    }

    public bool CanChangeNumbers
    {
        get { return canChangeNumbers; }
    }




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


    }

    void Update()
    {
        OpenLocker();
        LayerManager();
    }

    void LoadAllNumberSprites()
    {
        numberSprites1 = Resources.LoadAll<Sprite>("Sprites/boxlvlet1");
        numberSprites2 = Resources.LoadAll<Sprite>("Sprites/boxlvlet2");
        numberSprites3 = Resources.LoadAll<Sprite>("Sprites/boxlvlet3");
        numberSprites4 = Resources.LoadAll<Sprite>("Sprites/boxlvlet4");


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
            isOpen = true;
            OpenLockerSprite.SetActive(true);
            gameObject1.SetActive(true);
            gameObject2.SetActive(false);
            gameObject3.SetActive(false);
            canChangeNumbers = false;

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

}
