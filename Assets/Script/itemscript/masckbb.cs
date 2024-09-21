using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class masckbb : MonoBehaviour
{
    public Transform[] specificSlots;
    public GameObject bipr1; // هذا المتغير يظهر في الإنسبكتور
    public GameObject myGameObject1;
    public Vector3 newSize = new Vector3(1f, 1f, 0f);
    private bool itemMoved = false;

    public VideoPlayer videoPlayer;
    public GameObject[] gameObject2;
    public GameObject[] gameObject3;

    public GameObject gameObject1;
   



    void Start()
    {
        videoPlayer.gameObject.SetActive(false);

        videoPlayer.loopPointReached += OnVideoFinished;
        gameObject1.SetActive(false);


    }


    private void OnMouseDown()
    {
        if (!itemMoved)
        {
            MoveToEmptySlot();
        }
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
                    renderer.sortingOrder = 19;
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
                        aliRenderer.sortingOrder = 19;
                    }

                    bipr1.transform.SetParent(slot);
                    bipr1.transform.localPosition = Vector3.zero;
                    bipr1.transform.localScale = newSize;

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
            videoPlayer.gameObject.SetActive(true);
            videoPlayer.Play();

            HideGameObject2();

        }
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        // عند انتهاء الفيديو، قم بإخفاء وحذف GameObject الخاص به
        videoPlayer.gameObject.SetActive(false);
        Destroy(videoPlayer.gameObject);
        gameObject1.SetActive(true);

        HideGameObject3();


    }





    private void HideGameObject2()
    {
        if (gameObject2 != null && gameObject2.Length > 0)
        {
            foreach (GameObject obj in gameObject2)
            {
                obj.SetActive(false);
            }
        }
     // تعديل هذا الرقم حسب احتياجاتك
        

    }
    private void HideGameObject3()
    {
        if (gameObject3 != null && gameObject3.Length > 0)
        {
            foreach (GameObject obj in gameObject3)
            {
                obj.SetActive(true);
            }
        }
        // تعديل هذا الرقم حسب احتياجاتك


    }

}
