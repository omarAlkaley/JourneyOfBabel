using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Craft : MonoBehaviour
{
    private ButtonPair activeButtonPair;
    private Button lastPressedButton;
    public ButtonPair[] buttonPairs;

    public GameObject crf;

    // الأصوات
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

    public void OnMouseDown(Button button)
    {
        if (activeButtonPair == null)
        {
            lastPressedButton = button;
            // تحديد activeButtonPair بناءً على الزر الذي تم النقر عليه
            foreach (ButtonPair pair in buttonPairs)
            {
                if (button == pair.firstButton || button == pair.secondButton)
                {
                    activeButtonPair = pair;
                    Debug.Log("Active Button Pair: " + activeButtonPair);
                    return;
                }
            }
        }
        else
        {
            if ((button == activeButtonPair.secondButton && lastPressedButton == activeButtonPair.firstButton) ||
                (button == activeButtonPair.firstButton && lastPressedButton == activeButtonPair.secondButton))
            {
                // حذف الأزرار
                Destroy(activeButtonPair.firstButton.gameObject);
                Destroy(activeButtonPair.secondButton.gameObject);

                StartCoroutine(DelayedMoveItems());
            }
            else
            {
                // إذا تم النقر على زر آخر بدلاً من الزر الثاني المتوقع، قم بتحديث lastPressedButton
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

                Debug.Log("Associated Object: " + activeButtonPair.associatedObject);
                Debug.Log("New Scale: " + activeButtonPair.newScale);

                if (activeButtonPair.associatedObject != null)
                {
                    Renderer aliRenderer = activeButtonPair.associatedObject.GetComponent<Renderer>();
                    if (aliRenderer != null)
                    {
                        aliRenderer.sortingOrder = 19;
                    }

                    activeButtonPair.associatedObject.transform.SetParent(slot);
                    activeButtonPair.associatedObject.transform.localPosition = Vector3.zero;
                    activeButtonPair.associatedObject.transform.localScale = activeButtonPair.newScale;
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