using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapSprites : MonoBehaviour
{
    public List<SpriteRenderer> imageRenderers = new List<SpriteRenderer>();
    private bool isSwapping = false;
    private Transform selectedTransform;
    private Transform secondTransform;
    public float swapDelay = 0.5f; // زمن التأخير بالثواني
    public AudioSource source;
    public AudioClip incorrect1;
    void Start()
    {
        // استبعاد الـ null renderers ونقلهم إلى قائمة جديدة
        imageRenderers.RemoveAll(renderer => renderer == null);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            // التحقق من أن الـ SpriteRenderer ينتمي إلى القائمة المحددة
            if (hit.collider != null && imageRenderers.Contains(hit.collider.GetComponent<SpriteRenderer>()))
            {
                if (!isSwapping)
                {
                    selectedTransform = hit.collider.transform;
                    isSwapping = true;
                }
                else
                {
                    if (selectedTransform != hit.collider.transform)
                    {
                        // حفظ الـ Transform الثاني للتبديل
                        secondTransform = hit.collider.transform;

                        // تأخير تبديل الأطفال
                        StartCoroutine(SwapChildWithDelay(selectedTransform.GetChild(0), secondTransform.GetChild(0), swapDelay));

                        // تبديل الصور بين الـ SpriteRenderers الرئيسية
                        SwapImages(selectedTransform, secondTransform);
                        if (source != null && incorrect1 != null)
                        {
                            source.PlayOneShot(incorrect1);
                        }
                        isSwapping = false;
                    }
                }
            }
        }
    }

    IEnumerator SwapChildWithDelay(Transform firstChild, Transform secondChild, float delay)
    {
        yield return new WaitForSeconds(delay);
       
        // قم بتبديل الـ SpriteRenderer للأطفال
        SwapChildRenderer(firstChild, secondChild);
        if (source != null && incorrect1 != null)
        {
            source.PlayOneShot(incorrect1);
        }
    }

    void SwapImages(Transform firstTransform, Transform secondTransform)
    {
        // حفظ الصور والأطفال الحالية
        SpriteRenderer firstRenderer = firstTransform.GetComponent<SpriteRenderer>();
        SpriteRenderer secondRenderer = secondTransform.GetComponent<SpriteRenderer>();

        Transform firstChild = firstTransform.GetChild(0);
        Transform secondChild = secondTransform.GetChild(0);

        Sprite tempSprite1 = firstRenderer.sprite;
        Sprite tempSprite2 = secondRenderer.sprite;

        // قم بتحديث الصور
        firstRenderer.sprite = tempSprite2;
        secondRenderer.sprite = tempSprite1;
       
    }

    void SwapChildRenderer(Transform firstChild, Transform secondChild)
    {
        // حفظ الـ SpriteRenderer الحالي للأطفال
        SpriteRenderer firstChildRenderer = firstChild.GetComponent<SpriteRenderer>();
        SpriteRenderer secondChildRenderer = secondChild.GetComponent<SpriteRenderer>();

        // قم بتبديل الـ SpriteRenderer للأطفال
        Sprite tempChildSprite = firstChildRenderer.sprite;
        firstChildRenderer.sprite = secondChildRenderer.sprite;
        secondChildRenderer.sprite = tempChildSprite;
      
    }
}
