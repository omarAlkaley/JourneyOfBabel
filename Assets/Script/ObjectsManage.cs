using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectsManage : MonoBehaviour
{
    private DisplayImage currentDisplay;
    private string savedSpriteNameKey = "SavedSpriteName";

    public GameObject[] ObjectsToMange;
    public GameObject[] UIRenderObjects;

    void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();
        LoadSavedSprite();
        RenderUI();
    }

    void Update()
    {
        ManageObjects();
    }

    void ManageObjects()
    {
        for (int i = 0; i < ObjectsToMange.Length; i++)
        {
            string currentSpriteName = currentDisplay.imageComponent.sprite.name;
            if (ObjectsToMange[i].name == currentSpriteName)
            {
                ObjectsToMange[i].SetActive(true);
            }
            else
            {
                ObjectsToMange[i].SetActive(false);
            }
        }
    }

    void RenderUI()
    {
        for (int i = 0; i < UIRenderObjects.Length; i++)
        {
            UIRenderObjects[i].SetActive(false);
        }
    }

    void SaveSpriteName(string spriteName)
    {
        PlayerPrefs.SetString(savedSpriteNameKey, spriteName);
        PlayerPrefs.Save();
    }

    void LoadSavedSprite()
    {
        if (PlayerPrefs.HasKey(savedSpriteNameKey))
        {
            string savedSpriteName = PlayerPrefs.GetString(savedSpriteNameKey);
            currentDisplay.imageComponent.sprite = Resources.Load<Sprite>(savedSpriteName);
        }
    }

    public void SaveCurrentSprite()
    {
        string currentSpriteName = currentDisplay.imageComponent.sprite.name;
        SaveSpriteName(currentSpriteName);
    }
}
