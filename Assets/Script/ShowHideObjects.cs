using UnityEngine;
using UnityEngine.UI;

public class ShowHideObjects : MonoBehaviour
{
    public AudioClip incorrect;
    public AudioSource source;
    public GameObject[] objectsToToggle;
    public Sprite spriteVisible;
    public Sprite spriteHidden;
    public GameObject objectWithSpriteRenderer; // الكائن الذي يحتوي على Sprite Renderer
    private SpriteRenderer spriteRenderer; // المكون Sprite Renderer المراد تغييره

    private bool areObjectsVisible = false;

    void Start()
    {
        // التأكد من أن AudioSource موجود
        if (source == null)
        {
            source = GetComponent<AudioSource>();
            if (source == null)
            {
                Debug.LogError("AudioSource component is missing.");
            }
        }

        // التأكد من أن SpriteRenderer موجود
        if (objectWithSpriteRenderer != null)
        {
            spriteRenderer = objectWithSpriteRenderer.GetComponent<SpriteRenderer>();
            if (spriteRenderer == null)
            {
                Debug.LogError("SpriteRenderer component is missing on the specified GameObject.");
            }
        }
        else
        {
            Debug.LogError("No GameObject specified for the SpriteRenderer.");
        }

        // ضبط حالة الرؤية الأولية
        ToggleVisibility(true);
    }

    public void ToggleVisibility()
    {
        ToggleVisibility(!areObjectsVisible);
    }

    private void ToggleVisibility(bool visibility)
    {
        areObjectsVisible = visibility;

        // تشغيل الصوت عند التبديل
        if (source != null && incorrect != null)
        {
            source.clip = incorrect;
            source.Play();
        }

        // تغيير حالة الرؤية للكائنات
        ToggleObjectVisibility(areObjectsVisible);

        // تغيير الصورة
        ChangeSprite();
    }

    void ToggleObjectVisibility(bool visibility)
    {
        foreach (GameObject obj in objectsToToggle)
        {
            if (obj != null)
            {
                obj.SetActive(visibility);
            }
        }
    }

    void ChangeSprite()
    {
        if (spriteRenderer != null)
        {
            Sprite newSprite = areObjectsVisible ? spriteVisible : spriteHidden;
            spriteRenderer.sprite = newSprite;
        }
    }
}
