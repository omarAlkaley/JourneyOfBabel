using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class craft3 : MonoBehaviour
{
    private ButtonPair activeButtonPair2;
    private Button lastPressedButton;
    public ButtonPair[] buttonPairs;

    public GameObject crf;


    public AudioClip incorrect;
    public AudioSource source;
    private GameObject displayImage;
    public DisplayImage currentDisplay;
    public Transform[] specificSlots;
    private Vector3 newSize = new Vector3(0.736186564f, 0.736186564f, 0f);

    private void Start()
    {
        displayImage = GameObject.Find("displayImage");
    }

    public void OnButtonPress(Button button)
    {
        if (activeButtonPair2 == null)
        {
            lastPressedButton = button;
            foreach (ButtonPair pair in buttonPairs)
            {
                if (button == pair.firstButton || button == pair.secondButton)
                {
                    activeButtonPair2 = pair;
                    Debug.Log("Active Button Pair: " + activeButtonPair2);
                    return;
                }
            }
        }
        else
        {
            if ((button == activeButtonPair2.secondButton && lastPressedButton == activeButtonPair2.firstButton) ||
                (button == activeButtonPair2.firstButton && lastPressedButton == activeButtonPair2.secondButton))
            {
                Destroy(activeButtonPair2.firstButton.gameObject);
                Destroy(activeButtonPair2.secondButton.gameObject);

                StartCoroutine(DelayedMoveItems());
            }
            else
            {
                lastPressedButton = button;
            }
        }
    }

    private IEnumerator DelayedMoveItems()
    {
        Debug.Log("DelayedMoveItems Started");
        yield return new WaitForSeconds(0.1f);
        MoveItemsToSpecificSlots();
        source.clip = incorrect;
        source.Play();
        Debug.Log("DelayedMoveItems Completed");
    }

    private void MoveItemsToSpecificSlots()
    {
        foreach (Transform slot in specificSlots)
        {
            if (slot.childCount == 0)
            {
                Debug.Log("MoveItemsToSpecificSlots Started");

                transform.SetParent(slot);
                transform.SetAsLastSibling();
                transform.localPosition = Vector3.zero;

                Renderer renderer = GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.sortingOrder = 19;
                }

                transform.localScale = newSize;

                Debug.Log("Associated Object: " + activeButtonPair2.associatedObject);
                Debug.Log("New Scale: " + activeButtonPair2.newScale);

                if (activeButtonPair2.associatedObject != null)
                {
                    Renderer aliRenderer = activeButtonPair2.associatedObject.GetComponent<Renderer>();
                    if (aliRenderer != null)
                    {
                        aliRenderer.sortingOrder = 19;
                    }

                    activeButtonPair2.associatedObject.transform.SetParent(slot);
                    activeButtonPair2.associatedObject.transform.localPosition = Vector3.zero;
                    activeButtonPair2.associatedObject.transform.localScale = activeButtonPair2.newScale;
                }
                else
                {
                    Debug.LogError("Associated object not found.");
                }


                Destroy(crf.gameObject);

                Debug.Log("MoveItemsToSpecificSlots Completed");
                return;
            }
        }
    }
}
