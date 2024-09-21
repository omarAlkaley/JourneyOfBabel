using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class ArabicInputFieldFixer : MonoBehaviour
{
    public InputField inputField; // إضافة حقل TMP_InputField

    private string fixedText;
    private bool ShowTashkeel = true;
    private bool UseHinduNumbers = true;

    private string OldText; // For Refresh on TextChange
    private int OldFontSize; // For Refresh on Font Size Change
    private RectTransform rectTransform;  // For Refresh on resize
    private Vector2 OldDeltaSize; // For Refresh on resize
    private bool OldEnabled = false; // For Refresh on enabled change // when text ui is not active then arabic text will not trigger when the control gets active
    private List<RectTransform> OldRectTransformParents = new List<RectTransform>(); // For Refresh on parent resizing
    private Vector2 OldScreenRect = new Vector2(Screen.width, Screen.height); // For Refresh on screen resizing

    bool isInitilized;

    void Awake()
    {
        GetRectTransformParents(OldRectTransformParents);
        isInitilized = false;
        rectTransform = GetComponent<RectTransform>();
        inputField.onValueChanged.AddListener(OnInputFieldValueChanged);
        isInitilized = true;
    }

    private void GetRectTransformParents(List<RectTransform> rectTransforms)
    {
        rectTransforms.Clear();
        for (Transform parent = transform.parent; parent != null; parent = parent.parent)
        {
            GameObject goP = parent.gameObject;
            RectTransform rect = goP.GetComponent<RectTransform>();
            if (rect) rectTransforms.Add(rect);
        }
    }

    private bool CheckRectTransformParentsIfChanged()
    {
        bool hasChanged = false;
        for (int i = 0; i < OldRectTransformParents.Count; i++)
        {
            hasChanged |= OldRectTransformParents[i].hasChanged;
            OldRectTransformParents[i].hasChanged = false;
        }
        return hasChanged;
    }

    void Update()
    {
        if (!isInitilized)
            return;

        // if No Need to Refresh
        if (OldText == fixedText &&
            OldFontSize == inputField.textComponent.fontSize &&
            OldDeltaSize == rectTransform.sizeDelta &&
            OldEnabled == inputField.enabled &&
            (OldScreenRect.x == Screen.width && OldScreenRect.y == Screen.height &&
            !CheckRectTransformParentsIfChanged()))
            return;

        FixTextForUI();
        OldText = fixedText;
        OldFontSize = (int)inputField.textComponent.fontSize;
        OldDeltaSize = rectTransform.sizeDelta;
        OldEnabled = inputField.enabled;
        OldScreenRect.x = Screen.width;
        OldScreenRect.y = Screen.height;
    }

    void OnInputFieldValueChanged(string text)
    {
        fixedText = text;
        FixTextForUI();
    }

    public void FixTextForUI()
    {
        if (!string.IsNullOrEmpty(fixedText))
        {
            string rtlText = ArabicSupport.Fix(fixedText, ShowTashkeel, UseHinduNumbers);
            rtlText = rtlText.Replace("\r", ""); // the Arabic fixer Return \r\n for every \n .. need to be removed

            string finalText = "";
            string[] rtlParagraph = rtlText.Split('\n');

            inputField.text = "";
            for (int lineIndex = 0; lineIndex < rtlParagraph.Length; lineIndex++)
            {
                string[] words = rtlParagraph[lineIndex].Split(' ');
                System.Array.Reverse(words);
                inputField.text = string.Join(" ", words);
                Canvas.ForceUpdateCanvases();
                for (int i = 0; i < inputField.textComponent.cachedTextGenerator.lines.Count; i++)
                {
                    int startIndex = inputField.textComponent.cachedTextGenerator.lines[i].startCharIdx;
                    int endIndex = (i == inputField.textComponent.cachedTextGenerator.lines.Count - 1) ? inputField.text.Length
                        : inputField.textComponent.cachedTextGenerator.lines[i + 1].startCharIdx;
                    int length = endIndex - startIndex;
                    string[] lineWords = inputField.text.Substring(startIndex, length).Split(' ');
                    System.Array.Reverse(lineWords);
                    finalText = finalText + string.Join(" ", lineWords).Trim() + "\n";
                }
            }
            inputField.text = finalText.TrimEnd('\n');
        }
    }
}
