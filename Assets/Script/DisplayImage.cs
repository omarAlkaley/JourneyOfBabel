using UnityEngine;
using UnityEngine.UI;

public class DisplayImage : MonoBehaviour, IDataPresistance
{
    public enum State
    {
        normal, zoom, ChangedView, idle
    };
    public GameObject invntory1;
    public GameObject invntory2;
    public GameObject invntory3;
    public GameObject invntory4;
    public GameObject Audio;

    public State CurrentState { get; set; }

    private int currentWall;
    private int previousWall;
    private bool buttonPressed = false;

    public Image imageComponent;
    public Text wallNumberText;

    public enum ButtonType
    {
        Next,
        Previous,
        GoToWall5,
        GoToWall1,
        GoToWall2,
        GoToWall9,
        GoToWall10,
        GoToWall11,
        GoToWall12,
        GoToWall13,
        GoToWall14,
        GoToWall15,
        GoToWall16,
        GoToWall6,
        GoToWall7,
        GoToWall8,
        GoToWall17,
        GoToWall18,
        GoToWall19,
        GoToWall20,
        GoToWall21,
        GoToWall23,
        GoToWall24,
        GoToWall25,
        GoToWall26,
        GoToWall27,
        GoToWall28,
        GoToWall29,
        GoToWall30,
        GoToWall31,
        GoToWall32,
        GoToWall33,
        GoToWall34,
        GoToWall35,
        GoToWall36,
        GoToWall37,
        GoToWall38,
        GoToWall39,
        GoToWall40,
        GoToWall41,
        GoToWall42,
        GoToWall43,
        GoToWall44,
        GoToWall45,
        GoToWall46,
        GoToWall47,
        GoToWall48,
        GoToWall49,
        GoToWall50,
        GoToWall51,
        GoToWall52,
        GoToWall53,
        GoToWall54,
        GoToWall55,
        GoToWall56,
        GoToWall57,
        GoToWall58,
        GoToWall59,
        GoToWall60,
        GoToWall61,
        GoToWall62,
        GoToWall63,
        GoToWall64,
        GoToWall65,
        GoToWall66,
        GoToWall67,
        GoToWall68,
        GoToWall69,
        GoToWall70,
    };

    void Start()
    {
        CurrentState = State.idle;
        previousWall = 0;
       // currentWall = SaveSystem.LoadWallData(); // تحميل الجدار الحالي من الملف

        if (imageComponent == null)
        {
            Debug.LogError("Image component not found on the game object.");
        }

        if (wallNumberText == null)
        {
            Debug.LogError("Text component not found on the game object.");
        }

        UpdateWallNumberText(); // تحديث النص عند البداية
        WallManager.Instance.CurrentWall = currentWall; // تحديث WallManager برقم الجدار الحالي
    }

	public void LoadData( GameData gameData )
	{
        this.currentWall = gameData.currentWall;
        LoadWall();
	}

	public void SaveData( ref GameData gameData )
	{
        if(currentWall != 23) 
        {
            gameData.currentWall = this.currentWall;
		}
	}

	void Update()
    {
        if (buttonPressed)
        {
            currentWall = (currentWall % 8) + 1; // يتغير بين 1 و 8
            Debug.Log("Displaying image " + currentWall);
            LoadAndDisplayImage();
            CheckAndActivateObject();
            CheckAndActivateObject2();
            CheckAndActivateObject3();
            CheckAndActivateObject4();
            CheckAndActivateObjectAudio();
            CheckAndActivateObjectAudio2();
            UpdateWallNumberText(); // تحديث النص عند تغيير الجدار
            WallManager.Instance.CurrentWall = currentWall; // تحديث WallManager برقم الجدار الحالي
        }
        else
        {
            if (currentWall != previousWall)
            {
                Debug.Log("Displaying image " + currentWall);
                LoadAndDisplayImage();
                CheckAndActivateObject();
                CheckAndActivateObject2();
                CheckAndActivateObject3();
                CheckAndActivateObject4();
                CheckAndActivateObjectAudio();
                CheckAndActivateObjectAudio2();
                UpdateWallNumberText(); // تحديث النص عند تغيير الجدار
                WallManager.Instance.CurrentWall = currentWall; // تحديث WallManager برقم الجدار الحالي
            }
        }

        previousWall = currentWall;
        buttonPressed = false;
    }

    void LoadAndDisplayImage()
    {
        if (imageComponent == null)
        {
            Debug.LogError("Image component is null.");
            return;
        }

        string imagePath = "Sprites/wall" + currentWall.ToString();
        Sprite sprite = Resources.Load<Sprite>(imagePath);

        if (sprite != null)
        {
            imageComponent.sprite = sprite;
        }
        else
        {
            Debug.LogError("Unable to load sprite at path: " + imagePath);
        }
    }

    public int CurrentWall
    {
        get { return currentWall; }
        set
        {
            if (value == 5 || value > 200)
                currentWall = 1;
            else if (value == 0)
                currentWall = 4;
            else
                currentWall = value;
        }
    }

    public void OnButtonClick(ButtonType buttonType)
    {
        if (buttonType == ButtonType.Next)
        {
            if (currentWall < 8 && currentWall >= 4)
            {
                currentWall++;
            }
            else
            {
                currentWall = 5;
            }
        }
        else if (buttonType == ButtonType.Previous)
        {
            if (currentWall > 5)
            {
                currentWall--;
            }
            else
            {
                currentWall = 8;
            }
        }
        else if (buttonType == ButtonType.GoToWall5) { currentWall = 5; }
        else if (buttonType == ButtonType.GoToWall1) { currentWall = 1; }
        else if (buttonType == ButtonType.GoToWall2) { currentWall = 2; }
        else if (buttonType == ButtonType.GoToWall9) { currentWall = 9; }
        else if (buttonType == ButtonType.GoToWall10) { currentWall = 10; }
        else if (buttonType == ButtonType.GoToWall6) { currentWall = 6; }
        else if (buttonType == ButtonType.GoToWall11) { currentWall = 11; }
        else if (buttonType == ButtonType.GoToWall12) { currentWall = 12; }
        else if (buttonType == ButtonType.GoToWall13) { currentWall = 13; }
        else if (buttonType == ButtonType.GoToWall14) { currentWall = 14; }
        else if (buttonType == ButtonType.GoToWall15) { currentWall = 15; }
        else if (buttonType == ButtonType.GoToWall16) { currentWall = 16; }
        else if (buttonType == ButtonType.GoToWall17) { currentWall = 17; }
        else if (buttonType == ButtonType.GoToWall18) { currentWall = 18; }
        else if (buttonType == ButtonType.GoToWall19) { currentWall = 19; }
        else if (buttonType == ButtonType.GoToWall20) { currentWall = 20; }
        else if (buttonType == ButtonType.GoToWall21) { currentWall = 21; }
        else if (buttonType == ButtonType.GoToWall23) { currentWall = 23; }
        else if (buttonType == ButtonType.GoToWall7) { currentWall = 7; }
        else if (buttonType == ButtonType.GoToWall8) { currentWall = 8; }
        else if (buttonType == ButtonType.GoToWall24) { currentWall = 24; }
        else if (buttonType == ButtonType.GoToWall25) { currentWall = 25; }
        else if (buttonType == ButtonType.GoToWall26) { currentWall = 26; }
        else if (buttonType == ButtonType.GoToWall27) { currentWall = 27; }
        else if (buttonType == ButtonType.GoToWall28) { currentWall = 28; }
        else if (buttonType == ButtonType.GoToWall29) { currentWall = 29; }
        else if (buttonType == ButtonType.GoToWall30) { currentWall = 30; }
        else if (buttonType == ButtonType.GoToWall31) { currentWall = 31; }
        else if (buttonType == ButtonType.GoToWall32) { currentWall = 32; }
        else if (buttonType == ButtonType.GoToWall33) { currentWall = 33; }
        else if (buttonType == ButtonType.GoToWall34) { currentWall = 34; }
        else if (buttonType == ButtonType.GoToWall35) { currentWall = 35; }
        else if (buttonType == ButtonType.GoToWall36) { currentWall = 36; }
        else if (buttonType == ButtonType.GoToWall37) { currentWall = 37; }
        else if (buttonType == ButtonType.GoToWall38) { currentWall = 38; }
        else if (buttonType == ButtonType.GoToWall39) { currentWall = 39; }
        else if (buttonType == ButtonType.GoToWall40) { currentWall = 40; }
        else if (buttonType == ButtonType.GoToWall41) { currentWall = 41; }
        else if (buttonType == ButtonType.GoToWall42) { currentWall = 42; }
        else if (buttonType == ButtonType.GoToWall43) { currentWall = 43; }
        else if (buttonType == ButtonType.GoToWall44) { currentWall = 44; }
        else if (buttonType == ButtonType.GoToWall45) { currentWall = 45; }
        else if (buttonType == ButtonType.GoToWall46) { currentWall = 46; }
        else if (buttonType == ButtonType.GoToWall47) { currentWall = 47; }
        else if (buttonType == ButtonType.GoToWall48) { currentWall = 48; }
        else if (buttonType == ButtonType.GoToWall49) { currentWall = 49; }
        else if (buttonType == ButtonType.GoToWall50) { currentWall = 50; }
        else if (buttonType == ButtonType.GoToWall51) { currentWall = 51; }
        else if (buttonType == ButtonType.GoToWall52) { currentWall = 52; }
        else if (buttonType == ButtonType.GoToWall53) { currentWall = 53; }
        else if (buttonType == ButtonType.GoToWall54) { currentWall = 54; }
        else if (buttonType == ButtonType.GoToWall55) { currentWall = 55; }

        Debug.Log("Displaying image " + currentWall);
        LoadAndDisplayImage();
        UpdateWallNumberText(); // تحديث النص عند تغيير الجدار
        WallManager.Instance.CurrentWall = currentWall; // تحديث WallManager برقم الجدار الحالي
    }

    void CheckAndActivateObject()
    {
        if (currentWall >= 1 && currentWall <= 16)
        {
            invntory1.SetActive(true);
        }
    }

    void CheckAndActivateObject2()
    {
        if (currentWall >= 24 && currentWall <= 27)
        {
            invntory2.SetActive(true);
        }
    }

    void CheckAndActivateObject3()
    {
        if (currentWall >= 33 && currentWall <= 41)
        {
            invntory3.SetActive(true);
        }
    }

    void CheckAndActivateObject4()
    {
        if ((currentWall >= 42 && currentWall <= 49) || (currentWall >= 52 && currentWall <= 55))
        {
            invntory4.SetActive(true);
        }
    }

    void CheckAndActivateObjectAudio()
    {
        if ((currentWall >= 1 && currentWall <= 21) || (currentWall >= 23 && currentWall <= 55))
        {
            Audio.SetActive(true);
        }
    }

    void CheckAndActivateObjectAudio2()
    {
        if (currentWall == 22)
        {
            Audio.SetActive(false);
        }
    }

    void UpdateWallNumberText()
    {
        if (wallNumberText != null)
        {
            wallNumberText.text = currentWall.ToString();
        }
    }

    public void LoadWall()
    {
        UpdateWallNumberText(); // تحديث النص عند تحميل الجدار
        LoadAndDisplayImage(); // تحميل وعرض الصورة الجديدة
        WallManager.Instance.CurrentWall = currentWall; // تحديث WallManager برقم الجدار الحالي
        Debug.Log("Loaded wall " + currentWall);
    }
}
