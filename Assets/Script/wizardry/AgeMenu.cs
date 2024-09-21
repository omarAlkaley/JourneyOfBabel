using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class AgeMenu : MonoBehaviour
{
    public GameObject inputPanel; // لوحة إدخال البيانات

    public InputField playerNameInputField; // حقل نصي لاسم اللاعب
    public InputField dayInputField; // حقل نصي ليوم الميلاد
    public InputField monthInputField; // حقل نصي لشهر الميلاد
    public InputField yearInputField; // حقل نصي لسنة الميلاد

    // صور التنبيه لكل حقل باستخدام SpriteRenderer
    public SpriteRenderer playerNameWarningSprite;
    public SpriteRenderer dayWarningSprite;
    public SpriteRenderer monthWarningSprite;
    public SpriteRenderer yearWarningSprite;

    public GameObject[] objectsToHide; // الكائنات التي سيتم إخفاؤها
    public GameObject[] objectsToShow; // الكائنات التي سيتم إظهارها
    public Button resetButton; // زر إعادة التعيين

    public GameObject specialObject; // الكائن الخاص الذي ترغب في إخفائه إذا لم تُملأ البيانات بشكل صحيح

    private void Start()
    {
        resetButton.onClick.AddListener(ResetData); // ربط زر إعادة التعيين بالدالة

        if (IsFirstTime() || !IsDataValid())
        {
            ShowInputPanel();
            specialObject.SetActive(false); // إخفاء الكائن الخاص عند بدء اللعبة إذا كانت البيانات غير مكتملة
        }
        else
        {
            HideInputPanel();
            specialObject.SetActive(true); // إظهار الكائن الخاص عند بدء اللعبة إذا كانت البيانات مكتملة
        }
    }

    public void ShowInputPanel()
    {
        inputPanel.SetActive(true);
    }

    public void HideInputPanel()
    {
        inputPanel.SetActive(false);
    }

    public void SaveDataAndExecuteActions()
    {
        int day, month, year;
        bool isPlayerNameValid = !string.IsNullOrEmpty(playerNameInputField.text) && !playerNameInputField.text.Any(char.IsDigit);
        bool isDayValid = int.TryParse(dayInputField.text, out day) && day > 0 && day <= 31;
        bool isMonthValid = int.TryParse(monthInputField.text, out month) && month > 0 && month <= 12;
        bool isYearValid = int.TryParse(yearInputField.text, out year) && IsValidDate(day, month, year);

        if (isPlayerNameValid && isDayValid && isMonthValid && isYearValid)
        {
            // حفظ البيانات
            PlayerPrefs.SetString("PlayerName", playerNameInputField.text);
            PlayerPrefs.SetInt("BirthDay", day);
            PlayerPrefs.SetInt("BirthMonth", month);
            PlayerPrefs.SetInt("BirthYear", year);
            PlayerPrefs.SetInt("DataValid", 1);
            PlayerPrefs.Save();
            Debug.Log("Player data saved successfully!");

            // تنفيذ أوامر إخفاء وإظهار الكائنات
            foreach (GameObject obj in objectsToHide)
            {
                obj.SetActive(false);
            }

            foreach (GameObject obj in objectsToShow)
            {
                obj.SetActive(true);
            }

            specialObject.SetActive(true); // إظهار الكائن الخاص عند إكمال البيانات وحفظها
            HideWarningSprites(); // إخفاء جميع صور التنبيه
            HideInputPanel();
        }
        else
        {
            // عرض صور التنبيه بناءً على الحقول غير الصالحة
            playerNameWarningSprite.gameObject.SetActive(!isPlayerNameValid);
            dayWarningSprite.gameObject.SetActive(!isDayValid);
            monthWarningSprite.gameObject.SetActive(!isMonthValid);
            yearWarningSprite.gameObject.SetActive(!isYearValid);
        }
    }

    public void ResetData()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        Debug.Log("All data reset successfully!");

        // إعادة عرض لوحة الإدخال
        ShowInputPanel();

        // إعادة تعيين الحقول
        playerNameInputField.text = "";
        dayInputField.text = "";
        monthInputField.text = "";
        yearInputField.text = "";

        // إعادة تعيين حالة الكائنات
        foreach (GameObject obj in objectsToHide)
        {
            obj.SetActive(true);
        }

        foreach (GameObject obj in objectsToShow)
        {
            obj.SetActive(false);
        }

        specialObject.SetActive(false); // إخفاء الكائن الخاص عند إعادة تعيين البيانات
        HideWarningSprites(); // إخفاء جميع صور التنبيه
    }

    private bool IsValidDate(int day, int month, int year)
    {
        if (year < 1900 || year > System.DateTime.Now.Year)
            return false;
        if (month < 1 || month > 12)
            return false;
        if (day < 1 || day > System.DateTime.DaysInMonth(year, month))
            return false;
        return true;
    }

    private bool IsFirstTime()
    {
        return !PlayerPrefs.HasKey("PlayerName") || !PlayerPrefs.HasKey("BirthDay") || !PlayerPrefs.HasKey("BirthMonth") || !PlayerPrefs.HasKey("BirthYear") || PlayerPrefs.GetInt("DataValid", 0) == 0;
    }

    private bool IsDataValid()
    {
        return PlayerPrefs.GetInt("DataValid", 0) == 1;
    }

    private void HideWarningSprites()
    {
        playerNameWarningSprite.gameObject.SetActive(false);
        dayWarningSprite.gameObject.SetActive(false);
        monthWarningSprite.gameObject.SetActive(false);
        yearWarningSprite.gameObject.SetActive(false);
    }
}
