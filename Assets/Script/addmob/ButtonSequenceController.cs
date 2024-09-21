using UnityEngine;
using UnityEngine.UI;

public class ButtonSequenceController : MonoBehaviour
{
    public Button button1; // الزر الأول
    public Button button2; // الزر الثاني
    public GameObject objectToShow;
    public GameObject objectToShow2;
    public GameObject objectToShow3;
    public GameObject objectToShow4;

    private bool isButton1Clicked = false;

    void Start()
    {
        button1.onClick.AddListener(OnButton1Click);
        button2.onClick.AddListener(OnButton2Click);
    }

    void OnButton1Click()
    {
        isButton1Clicked = true;
    }

    void OnButton2Click()
    {
        if (isButton1Clicked)
        {
            objectToShow.SetActive(true);
            objectToShow2.SetActive(false);
            objectToShow3.SetActive(false);
            objectToShow4.SetActive(false);


            Debug.Log("مرحبا");
            isButton1Clicked = false; // إعادة تعيين الحالة بعد الطباعة
        }
    }
}
