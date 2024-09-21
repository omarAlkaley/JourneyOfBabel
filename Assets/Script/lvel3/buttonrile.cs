using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class buttonrile : MonoBehaviour
{
    [System.Serializable]
    public class ButtonPair
    {
        public Button[] Buttons;
        public GameObject Object;
        public Image Image;
    }

   // public AudioSource source;
   // public AudioClip incorrect;

   // public VideoPlayer videoPlayer;
    public ButtonPair[] buttonPairs;
   // public bool videoHidden = true;
    public List<ButtonPair> allButtonPairs = new List<ButtonPair>();
    public List<Button> clickedButtons = new List<Button>();
    public ButtonPair visibleButtonPair;
    public bool welcomePrinted = false;

    public GameObject myGameObject;
    public GameObject myGameObject2;
   // public GameObject myGameObject3;
    public GameObject myGameObject4;



    void Start()
    {
        // إضافة الأنساق المختلفة للقائمة
        allButtonPairs.AddRange(buttonPairs);

        // اختيار ButtonPair عشوائي
        visibleButtonPair = allButtonPairs[Random.Range(0, allButtonPairs.Count)];

        // تعيين الدوال المستمعة للأزرار
        foreach (ButtonPair pair in allButtonPairs)
        {
            foreach (Button button in pair.Buttons)
            {
                button.onClick.AddListener(() => ButtonClickHandler(pair, button));
            }

            // جعل الأزرار والكائنات غير المرئية في البداية
            if (pair != visibleButtonPair)
            {
                HideButtonPair(pair);
            }
        }



        // استدعاء دالة التحقق من NewButtonManager كل ثانية
        StartCoroutine(CheckButtonManagerRepeatedly());
    }

    void ButtonClickHandler(ButtonPair clickedPair, Button clickedButton)
    {
        // التأكد من عدم تكرار الأزرار المضغوطة
        if (!clickedButtons.Contains(clickedButton))
        {
            clickedButtons.Add(clickedButton);
        }
       // source.clip = incorrect;
       // source.Play();
        // التحقق من النقر على جميع الأزرار
        if (clickedButtons.Count == allButtonPairs.Sum(pair => pair.Buttons.Length) && !welcomePrinted)
        {
            // التحقق من قيمة الأزرار في buttonfick
            buttonfick newButtonManager = FindObjectOfType<buttonfick>();
            if (newButtonManager != null && newButtonManager.AreAllButtonsOnes())
            {
                Debug.Log("مرحبًا!");
                welcomePrinted = true; // تم طباعة الترحيب

                if (myGameObject != null)
                {

                  //  PlayVideo();
              //      incorrect = null;
                }
               if (myGameObject2 != null)
                {
                   myGameObject2.SetActive(true);
                  //  PlayVideo();
                //    incorrect = null;
                }
             //   if (myGameObject3 != null)
             //   {
              //      myGameObject3.SetActive(true);
                //    incorrect = null;

              //  }

                // استدعاء دالة OnEightButtonClicks في NewButtonManager
                newButtonManager.OnEightButtonClicks();

                // لا تظهر الأزرار والصور بعد طباعة الترحيب
                clickedButtons.Clear();
                HideAllButtonPairs();
               myGameObject4.SetActive(false);
            }
            else
            {
                Debug.Log("لا يمكن تنفيذ الدالة لأن قيمة واحدة على الأقل من الأزرار تساوي 2.");
            }
        }


    }


    IEnumerator CheckButtonManagerRepeatedly()
    {
        while (true)
        {
            // انتظار حتى يتم النقر على الأزرار الأربعة
            yield return new WaitUntil(() => clickedButtons.Count == 5);

            // انتظار لمدة ثانية بعد النقر على الأزرار الأربعة
            yield return new WaitForSeconds(1.0f);

            // التحقق من قيمة الأزرار في NewButtonManager
            buttonfick newButtonManager = FindObjectOfType<buttonfick>();
            if (newButtonManager != null && newButtonManager.AreAllButtonsOnes())
            {
                Debug.Log("مرحبًا!");
                welcomePrinted = true; // تم طباعة الترحيب

                if (myGameObject != null)
                {

                 //   PlayVideo();
                }

                // استدعاء دالة OnEightButtonClicks في NewButtonManager
                newButtonManager.OnEightButtonClicks();

                // لا تظهر الأزرار والصور بعد طباعة الترحيب
                clickedButtons.Clear();
                myGameObject4.SetActive(false);

            }
            else
            {
                Debug.Log("لا يمكن تنفيذ الدالة لأن قيمة واحدة على الأقل من الأزرار تساوي 2.");
            }
        }


    }

    void HideAllButtonPairs()
    {
        foreach (ButtonPair pair in allButtonPairs)
        {
            HideButtonPair(pair);
        }
    }

    void ShowButtonPair(ButtonPair pair)
    {
        pair.Object.SetActive(true);
        pair.Image.gameObject.SetActive(true);
        foreach (Button button in pair.Buttons)
        {
            button.gameObject.SetActive(true);
        }
    }

    void HideButtonPair(ButtonPair pair)
    {
        // التحقق من أن pair.Object ليس null قبل استخدامه
        if (pair.Object != null)
        {
            pair.Object.SetActive(false);
        }

        // التحقق من أن pair.Image ليس null قبل استخدامه
        if (pair.Image != null)
        {
            pair.Image.gameObject.SetActive(false);
        }

        foreach (Button button in pair.Buttons)
        {
            // التحقق من أن button.gameObject ليس null قبل استخدامه
            if (button != null && button.gameObject != null)
            {
                button.gameObject.SetActive(false);
            }
        }
    }


   
}

