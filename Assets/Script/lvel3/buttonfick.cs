using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class buttonfick : MonoBehaviour
{
    [SerializeField]
    private Button[] Buttonssoich;
   // public AudioSource source;
   // public AudioClip incorrect;

    private int[] buttonStates;
    private bool videoHidden = true;


    // الكود الذي يحتاج إلى التنفيذ بمجرد تغيير قيمة الزر إلى 1
    public GameObject myGameObject;
    public GameObject myGameObject2;
   // public GameObject myGameObject3;
  //  public GameObject myGameObject4;
   // public VideoPlayer videoPlayer;

    void Start()
    {
        buttonStates = new int[Buttonssoich.Length];
        InitializeButtonStates();
       
    }

    void InitializeButtonStates()
    {
        for (int i = 0; i < Buttonssoich.Length; i++)
        {
            buttonStates[i] = 1;
            int currentIndex = i;
            Buttonssoich[i].onClick.AddListener(() => OnButtonClick(currentIndex));
        }
    }

    public void OnButtonClick(int buttonIndex)
    {
        int previousState = buttonStates[buttonIndex];
        buttonStates[buttonIndex] = (previousState == 1) ? 2 : 1;
       // source.clip = incorrect;
       // source.Play();

        Debug.Log("تم تغيير حالة الزر " + (buttonIndex + 1) + " إلى " + buttonStates[buttonIndex]);

        // إذا تم تغيير القيمة إلى 1 لجميع الأزرار، استدعاء الكود الموجود في RandomObjects script
        if (AreAllButtonsOnes())
        {
            // استدعاء الكود من RandomObjects script
            ExecuteWelcomeCodeFromRandomObjects();





        }
    }

    private void HideAlButtonssoich()
    {
        foreach (Button button in Buttonssoich)
        {
            button.gameObject.SetActive(false);
        }
    }



    // دالة لاستدعاء الكود الموجود في buttonrile script
    private void ExecuteWelcomeCodeFromRandomObjects()
    {
        // التأكد من أن clickedButtons.Count تساوي 4 في buttonrile
        buttonrile randomObjects = FindObjectOfType<buttonrile>();
        if (randomObjects != null && randomObjects.clickedButtons.Count == 5)
        {
            if (myGameObject != null)
            {

            }
            if (myGameObject2 != null)
            {
                myGameObject2.SetActive(true);
              //  PlayVideo();
                HideAlButtonssoich();
            }
           // if (myGameObject3 != null)
          //  {
             //   myGameObject3.SetActive(true);

           // }

            // استدعاء دالة OnEightButtonClicks في NewButtonManager
            OnEightButtonClicks();
        }
        else
        {
            Debug.LogWarning("عدد الأزرار المضغوطة لا يساوي 4 في RandomObjects.");
        }
    }


    public bool AreAllButtonsOnes()
    {
        foreach (int state in buttonStates)
        {
            if (state != 1)
            {
                return false;
            }
        }
        return true;
    }

    public void OnEightButtonClicks()
    {
        foreach (int state in buttonStates)
        {
            if (state != 1)
            {
                Debug.Log("لا يمكن تنفيذ الدالة لأن قيمة واحدة على الأقل من الأزرار تساوي 2.");
                return;
            }
        }
        myGameObject.SetActive(true);
        Debug.Log("مرحبًا! تم النقر على الأزرار الثمانية.");
    }

   


}
