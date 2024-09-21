using UnityEngine;
using UnityEngine.UI;

public class Hints : MonoBehaviour
{
    public Image wallImageComponent; // مكون الصورة لعرض الجدار
    public Button displayButton; // الزر الذي سيظهر الصورة
    public GameObject targetObjectInWall41; // الكائن في الجدار 41

    void Start()
    {
        // التحقق من تعيين مكون الصورة
        if (wallImageComponent == null)
        {
            Debug.LogError("Wall Image component is not assigned.");
        }

        // التحقق من تعيين الزر وربط الدالة بالنقر على الزر
        if (displayButton != null)
        {
            displayButton.onClick.AddListener(OnDisplayButtonClick);
        }
        else
        {
            Debug.LogError("Display Button is not assigned.");
        }

        UpdateButtonVisibility(); // تحديث حالة الزر عند البداية
    }

    void Update()
    {
        // تحديث حالة الزر في كل إطار (يمكن تحسين هذا لاحقًا إذا كان الأداء مهمًا)
        UpdateButtonVisibility();
    }

    void OnDisplayButtonClick()
    {
        int currentWall = WallManager.Instance.CurrentWall;
        DisplayWallImageByNumber(currentWall);
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
