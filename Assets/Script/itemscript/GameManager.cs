using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject AgeMenu;
    public GameObject mainmenu;
    public GameObject lod;



    void Awake()
    {

        if (!PlayerPrefs.HasKey("FirstTimeRun"))
        {
            Debug.Log("تم تشغيل اللعبة لأول مرة!");
            if (AgeMenu != null)
            {
               


            }
            else
            {
                Debug.LogError("GameObject `AgeMenu` غير معين. يرجى تعيينه في المحرر.");
            }
            PlayerPrefs.SetInt("FirstTimeRun", 1);
          
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("لعبة ليست أول تشغيل!");
            lod.SetActive(true);
           
        }
    }



    // تفعيل هذا الجزء إذا كنت تريد السماح للاعب بالضغط على مفتاح الهروب للخروج
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
    }

    // الوظيفة لإغلاق اللعبة
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }

    public void ResetGame()
    {
        PlayerPrefs.DeleteKey("FirstTimeRun");
        PlayerPrefs.Save();
        Debug.Log("تم إعادة تعيين اللعبة بنجاح!");
    }

}
