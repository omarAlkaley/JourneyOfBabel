using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSequenceController303 : MonoBehaviour
{
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;

    public GameObject[] objectsToShow1;
    public GameObject[] objectsToHide1;

    public GameObject[] objectsToShow2;
    public GameObject[] objectsToHide2;
    public GameObject[] objectsToDelete2;

    private bool firstSequenceActive = false;
    private bool secondSequenceActive = false;

    void Start()
    {
        button1.onClick.AddListener(OnButton1Click);
        button2.onClick.AddListener(OnButton2Click);
        button3.onClick.AddListener(OnButton3Click);
        button4.onClick.AddListener(OnButton4Click);
    }

    void OnButton1Click()
    {
        firstSequenceActive = true;
    }

    void OnButton2Click()
    {
        if (firstSequenceActive)
        {
            ShowObjects(objectsToShow1);
            HideObjects(objectsToHide1);
            firstSequenceActive = false;
        }
    }

    void OnButton3Click()
    {
        secondSequenceActive = true;
    }

    void OnButton4Click()
    {
        if (secondSequenceActive)
        {
            ShowObjects(objectsToShow2);
            HideObjects(objectsToHide2);
            DeleteObjects(objectsToDelete2);
            secondSequenceActive = false;
        }
    }

    void ShowObjects(GameObject[] objects)
    {
        foreach (GameObject obj in objects)
        {
            obj.SetActive(true);
        }
    }

    void HideObjects(GameObject[] objects)
    {
        foreach (GameObject obj in objects)
        {
            obj.SetActive(false);
        }
    }

    void DeleteObjects(GameObject[] objects)
    {
        foreach (GameObject obj in objects)
        {
            Destroy(obj);
        }
    }
}
