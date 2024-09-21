using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

using static Unity.VisualScripting.Member;

public class jarsc : MonoBehaviour
{
    public GameObject gameObject1;
    public GameObject gameObject2;




    public GameObject crf;

    public Transform[] specificSlots;
    public Vector3 newSize = new Vector3(0.736186564f, 0.736186564f, 0f);

    public VideoPlayer videoPlayer;

    public Button button1;
    public Button button2;

    private bool button1Clicked = false;
    private bool button2Clicked = false; // تم إضافة متغير للتحقق من تنفيذ button2
    private bool videoHidden = true;

    private void Start()
    {




        videoPlayer.loopPointReached += OnVideoFinished;





        button1.onClick.AddListener(OnButton1Click);
        button2.onClick.AddListener(OnButton2Click);

    }

    public void OnButton1Click()
    {

        button1Clicked = true;
        Debug.Log("Button 1 Clicked");
    }

    public void OnButton2Click()
    {

        if (button1Clicked)
        {
            Debug.Log("Button 2 Clicked after Button 1");
            PlayVideo();

            StartCoroutine(DelayedMoveItems());


            Destroy(button1.gameObject);
            Destroy(button2.gameObject);

            Debug.Log("hiiiii");









        }
        else
        {
            Debug.Log("Button 2 Clicked without Button 1");
        }
    }


    private void MoveItemsToSpecificSlots(Button button1, Button button2, GameObject objectToMove)
    {
        foreach (Transform slot in specificSlots)
        {
            if (slot.childCount == 0)
            {
                Debug.Log("MoveItemsToSpecificSlots Started");

                // Move the current object to the slot
                objectToMove.transform.SetParent(slot);
                objectToMove.transform.SetAsLastSibling();
                objectToMove.transform.localPosition = Vector3.zero;

                Renderer renderer = objectToMove.GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.sortingOrder = 7;
                }

                objectToMove.transform.localScale = newSize;

                Debug.Log("Button 1 Clicked: " + button1Clicked);
                Debug.Log("Button 2 Clicked: " + button2Clicked);

                if (button2Clicked)
                {
                    // Your logic here using button1 and button2
                    Debug.Log("Button 2 Clicked after Button 1");

                    // Example: Check if button1 is not null before using it
                    if (button1 != null)
                    {
                        Debug.Log("Button 1 Text: " + button1.GetComponentInChildren<Text>().text);
                    }

                    // Continue with the rest of your logic
                }
                else
                {
                    Debug.Log("Button 2 Clicked without Button 1");
                }

               
                Debug.Log("MoveItemsToSpecificSlots Completed");
                return;
            }
        }
    }




    private IEnumerator DelayedMoveItems()
    {
        Debug.Log("DelayedMoveItems Started");
        yield return new WaitForSeconds(0.1f);
        MoveItemsToSpecificSlots(button1, button2, crf);

        Debug.Log("DelayedMoveItems Completed");
    }

    private void PlayVideo()
    {
        if (videoPlayer != null)
        {
            gameObject1.SetActive(false);
          
            videoPlayer.gameObject.SetActive(true);
            videoPlayer.Play();
            videoHidden = false;
        }
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        gameObject1.SetActive(true);
        videoPlayer.gameObject.SetActive(false);
        Destroy(videoPlayer.gameObject);
       
       
    }
}
