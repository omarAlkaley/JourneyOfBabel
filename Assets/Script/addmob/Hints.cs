using UnityEngine;
using UnityEngine.UI;

public class Hints : MonoBehaviour
{
    public Image wallImageComponent;
    public Button displayButton;
    public GameObject targetObjectInWall41;
    private AdManager adManager;

    void Start()
    {
        adManager = FindObjectOfType<AdManager>();

        if (wallImageComponent == null)
        {
            Debug.LogError("Wall Image component is not assigned.");
            return;
        }

        if (displayButton != null)
        {
            displayButton.onClick.AddListener(OnDisplayButtonClick);
        }
        else
        {
            Debug.LogError("Display Button is not assigned.");
            return;
        }

        UpdateButtonVisibility();
    }

    void Update()
    {
        UpdateButtonVisibility();
    }

    void OnDisplayButtonClick()
    {
        adManager.ShowInterstitial(() => {
            int currentWall = WallManager.Instance.CurrentWall;
            DisplayWallImageByNumber(currentWall);
        });
    }

    void DisplayWallImageByNumber(int wallNumber)
    {
        if (wallImageComponent == null)
        {
            return;
        }

        string imagePath;

        if (wallNumber == 41 && targetObjectInWall41 != null)
        {
            imagePath = targetObjectInWall41.activeSelf ? "Hints/Hints80" : "Hints/Hints41";
        }
        else
        {
            imagePath = "Hints/Hints" + wallNumber.ToString();
        }

        Sprite sprite = Resources.Load<Sprite>(imagePath);

        if (sprite != null)
        {
            wallImageComponent.sprite = sprite;
        }
        else
        {
            Debug.LogError("Unable to load sprite at path: " + imagePath);
        }
    }

    void UpdateButtonVisibility()
    {
        int currentWall = WallManager.Instance.CurrentWall;
        bool shouldShowButton = ShouldShowButtonForWall(currentWall);
        displayButton.gameObject.SetActive(shouldShowButton);
    }

    bool ShouldShowButtonForWall(int wallNumber)
    {
        int[] wallsToShowButton = { 1, 2, 3, 5, 7, 24, 25, 27, 34, 35, 36, 38, 41 };
        foreach (int wall in wallsToShowButton)
        {
            if (wall == wallNumber)
            {
                return true;
            }
        }
        return false;
    }
}
