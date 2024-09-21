﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dorlock : MonoBehaviour
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
    public int[] currentIndividualIndex = { 0, 0, 0, 0, 0, 0,};

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
        transform.GetChild(4).GetComponent<SpriteRenderer>().sprite = numberSprites5[0];
        transform.GetChild(5).GetComponent<SpriteRenderer>().sprite = numberSprites6[0];



    }

    void Update()
    {
        OpenLocker();
        LayerManager();
    }

    void LoadAllNumberSprites()
    {
        numberSprites1 = Resources.LoadAll<Sprite>("Sprites/Dorenumbers1");
        numberSprites2 = Resources.LoadAll<Sprite>("Sprites/Dorenumbers2");
        numberSprites3 = Resources.LoadAll<Sprite>("Sprites/Dorenumbers3");
        numberSprites4 = Resources.LoadAll<Sprite>("Sprites/Dorenumbers4");
        numberSprites5 = Resources.LoadAll<Sprite>("Sprites/Dorenumbers5");
        numberSprites6 = Resources.LoadAll<Sprite>("Sprites/Dorenumbers6");


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
            float delay = 0.5f; // تعديل هذا الرقم حسب احتياجاتك
            Invoke("isOpen2", delay);
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


    private void isOpen2()
    {
        isOpen = true;
        OpenLockerSprite.SetActive(true);
        canChangeNumbers = false;

        source.clip = incorrect;
        source.Play();



        if (OnLockerUnlocked != null)
        {
            OnLockerUnlocked();
        }

    }

}
