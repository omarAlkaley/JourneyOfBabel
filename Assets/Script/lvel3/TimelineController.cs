using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using static Unity.VisualScripting.Member;

public class TimelineController : MonoBehaviour
{
    public PlayableDirector playableDirector;
    public GameObject[] hiddenObject;
    public GameObject[] showObject;
    public float timeToDestroy = 5f;
    void Start()
    {
        if (playableDirector == null)
        {
            Debug.LogError("يرجى تعيين مرشح Playable Director.");
        }
    }

    void Update()
    {
        if (playableDirector != null)
        {
            // تحقق مما إذا كانت التايم لاين قد انتهت
            if (playableDirector.state != PlayState.Playing)
            {
                // انتهى التايم لاين، قم بتنفيذ الإجراء المطلوب هنا
                Debug.LogError("مرحبا");
                Invoke("SetActivegameObject", timeToDestroy);
            }
        }
    }
    private void hiddenObjectt()
    {
        if (hiddenObject != null && hiddenObject.Length > 0)
        {
            foreach (GameObject obj in hiddenObject)
            {
                obj.SetActive(false);
            }
        }
    }

    private void showObjectt()
    {
        if (showObject != null && showObject.Length > 0)
        {
            foreach (GameObject obj in showObject)
            {
                obj.SetActive(true);
            }
        }
    }
    void SetActivegameObject()
    {
        hiddenObjectt();
        showObjectt();
    }
}
