using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;

public class soljan : MonoBehaviour
{
    public Transform[] specificSlots;
    public GameObject bipr1; // هذا المتغير يظهر في الإنسبكتور
    public GameObject myGameObject1;
    public GameObject myGameObject2;
    public GameObject myGameObject3;
    public GameObject myGameObject4;
    public GameObject myGameObject5;
    public GameObject myGameObject6;




    public Vector3 newSize = new Vector3(1f, 1f, 0f);
    private bool itemMoved = false;
    public VideoPlayer videoPlayer;
    private void OnMouseDown()
    {
        if (!itemMoved)
        {
            MoveToEmptySlot();
        }
    }

    private void Start()
    {



        videoPlayer.loopPointReached += OnVideoFinished;


       

    }

    private void MoveToEmptySlot()
    {
        foreach (Transform slot in specificSlots)
        {
            if (slot.childCount == 0)
            {
                // نقل العنصر إلى الفتحة الفارغة
                transform.SetParent(slot);
                transform.SetAsLastSibling();
                transform.localPosition = Vector3.zero;

                Renderer renderer = GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.sortingOrder = 6;
                }

                transform.localScale = newSize;

                itemMoved = true;
                Destroy(gameObject);
                myGameObject1.SetActive(false);

                bipr1.SetActive(true);
                // نقل "bipr1" إلى نفس المكان
                if (bipr1 != null)
                {
                    Renderer aliRenderer = bipr1.GetComponent<Renderer>();
                    if (aliRenderer != null)
                    {
                        aliRenderer.sortingOrder = 14;
                    }

                    bipr1.transform.SetParent(slot);
                    bipr1.transform.localPosition = Vector3.zero;
                    bipr1.transform.localScale = newSize;
                    myGameObject2.SetActive(false);
                    myGameObject3.SetActive(false);
                    myGameObject4.SetActive(false);

                    PlayVideo();
                }
                else
                {
                    Debug.LogError("GameObject 'bipr1' not assigned in the inspector.");
                }

                // انهاء الحلقة بمجرد نقل العنصر
                break;
            }
        }
    }



    private void PlayVideo()
    {
        if (videoPlayer != null)
        {
            myGameObject2.SetActive(false);
            videoPlayer.gameObject.SetActive(true);
            videoPlayer.Play();



        }
    }






    void OnVideoFinished(VideoPlayer vp)
    {
        // عند انتهاء الفيديو، قم بإخفاء وحذف GameObject الخاص به
        videoPlayer.gameObject.SetActive(false);
        Destroy(videoPlayer.gameObject);
        myGameObject2.SetActive(true);
        myGameObject3.SetActive(true);
        myGameObject5.SetActive(true);
        myGameObject6.SetActive(false);


    }
}
