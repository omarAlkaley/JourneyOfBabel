using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoadManager : MonoBehaviour
{
    // مرجع إلى سكربت عرض الصورة
    public DisplayImage displayImage;
    // مرجع إلى سكربت ImageSwitcher
    public ImageSwitcher imageSwitcher;

    // مرجع إلى كائن الـ GameObject الذي سيتم تفعيله عند بدء لعبة جديدة
  //  public GameObject lod;

    void Start()
    {
        // التحقق من وجود بيانات محفوظة قبل بدء اللعبة
        int savedWall = PlayerPrefs.GetInt("CurrentWall", -1);
        if (savedWall != -1)
        {
            // إذا كانت هناك بيانات محفوظة، استعادتها
            displayImage.CurrentWall = savedWall;
            Debug.Log("Data loaded successfully!");
        }
        else
        {
            // إذا لم يكن هناك بيانات محفوظة، قم بتعيين الجدار الحالي إلى 22
            displayImage.CurrentWall = 22;
            Debug.Log("No saved data found. Default wall set to 22.");
        }

        // استدعاء دالة LoadData عند بدء التشغيل
        LoadData();
    }

    // دالة لحفظ البيانات
    public void SaveData()
    {
        // استخدام PlayerPrefs لحفظ البيانات
        PlayerPrefs.SetInt("CurrentWall", displayImage.CurrentWall);
        PlayerPrefs.Save();
        Debug.Log("Data saved successfully!");

        // إذا كنت تستخدم بيانات إضافية مثل بيانات العمر، قم بحفظها هنا
        // ageMenu.SavePlayerData();
    }

    // دالة لاسترجاع البيانات
    public void LoadData()
    {
        // استخدام PlayerPrefs لاسترجاع البيانات
        int currentWall = PlayerPrefs.GetInt("CurrentWall", 22);
        // إعادة تعيين الجدار الحالي في سكربت العرض
        displayImage.CurrentWall = currentWall;
        Debug.Log("Data loaded successfully!");

        // استدعاء دالة LoadImageSwitcherData في ImageSwitcher
        if (imageSwitcher != null)
        {
            imageSwitcher.LoadImageSwitcherData();
        }

        // إذا كنت تستخدم بيانات إضافية مثل بيانات العمر، قم باسترجاعها هنا
        // ageMenu.LoadPlayerData();
    }

    // دالة لبدء لعبة جديدة (مسح البيانات)
    public void NewGame()
    {
        // حذف جميع البيانات المحفوظة
        PlayerPrefs.DeleteAll();

        // تعيين الجدار الحالي إلى 22 (أو أي قيمة ابتدائية أخرى)
        displayImage.CurrentWall = 22;

        // تفعيل كائن الـ GameObject إذا كان هناك حاجة لذلك
      //  lod.SetActive(true);

        // إعادة تعيين بيانات العمر إذا كنت تستخدمها
        // ageMenu.ResetPlayerData();

        // تسجيل رسالة للتأكيد
        Debug.Log("Data deleted, starting new game!");

        // إعادة تعيين المتغيرات الأخرى في اللعبة حسب الحاجة
        ResetGameVariables();

        // إعادة تحميل المشهد الحالي لإعادة تعيين الحالة بالكامل
        ReloadCurrentScene();
    }

    // دالة لإعادة تعيين المتغيرات الخاصة باللعبة
    void ResetGameVariables()
    {
        // إعادة تعيين المتغيرات الأخرى هنا
        // مثال:
        // score = 0;
        // lives = 3;
        // أي متغيرات أخرى تحتاج لإعادة التعيين
    }

    // دالة لإعادة تحميل المشهد الحالي
    void ReloadCurrentScene()
    {
        // استخدام UnityEngine.SceneManagement لإعادة تحميل المشهد
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // دالة لتغيير الجدار الحالي وحفظ التغيير
    public void ChangeWall(int newWall)
    {
        displayImage.CurrentWall = newWall;
        PlayerPrefs.SetInt("CurrentWall", newWall);
        PlayerPrefs.Save();
        Debug.Log("Wall changed to " + newWall);
    }

    // دالة لبدء لعبة جديدة دون مسح البيانات (إذا كان هناك حاجة إلى ذلك)
    public void NewGame1()
    {
     //   lod.SetActive(true); // تفعيل كائن الـ GameObject
        Debug.Log("New game started without deleting data.");
    }
}
