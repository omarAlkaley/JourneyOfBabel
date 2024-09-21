using UnityEngine;
using UnityEngine.UI;

public class SetupTextAlignment : MonoBehaviour
{
    public Text messageText;

    void Start()
    {
        // Create a parent GameObject
        GameObject parent = new GameObject("TextParent");
        parent.transform.SetParent(transform);

        // Add Vertical Layout Group
        VerticalLayoutGroup verticalLayout = parent.AddComponent<VerticalLayoutGroup>();
        verticalLayout.childAlignment = TextAnchor.UpperCenter;

        // Add Content Size Fitter
        ContentSizeFitter contentSizeFitter = parent.AddComponent<ContentSizeFitter>();
        contentSizeFitter.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
        contentSizeFitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;

        // Move messageText to be a child of the parent GameObject
        messageText.transform.SetParent(parent.transform);

        // Optionally, reset the position and size of messageText
        RectTransform rectTransform = messageText.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = Vector2.zero;
        rectTransform.sizeDelta = Vector2.zero;
    }
}
