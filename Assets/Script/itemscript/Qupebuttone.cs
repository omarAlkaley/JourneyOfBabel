using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

using UnityEngine;
using Unity.VisualScripting.Antlr3.Runtime;

public class Qupebuttone : MonoBehaviour
{
    


    public AudioClip incorrect;
    public AudioSource source;
  
    public GameObject hiddenObject;
    public GameObject hiddenObject1;


    public GameObject hiddenObject2;
    private SpriteRenderer[] spriteRenderers; // تم إضافة مصفوفة من مكونات SpriteRenderer







    public Button button1;
    public Button button2;
   
    private bool button1Clicked = false;
    private bool button2Clicked = false; // تم إضافة متغير للتحقق من تنفيذ button2
   

    private void Start()
    {
        hiddenObject.SetActive(false);
        hiddenObject1.SetActive(false);


        spriteRenderers = hiddenObject2.GetComponentsInChildren<SpriteRenderer>();
        SetSpriteRenderersAlpha(0f); // تعيين الشفافية إلى 0 عند البداية





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
            hiddenObject.SetActive(true);
            hiddenObject1.SetActive(true);

            source.clip = incorrect;
            source.Play();

            StartCoroutine(FadeInHiddenObject2());

            Destroy(button1.gameObject);
            Destroy(button2.gameObject);

            Debug.Log("hiiiii");








            
        }
        else
        {
            Debug.Log("Button 2 Clicked without Button 1");
        }
    }

    private IEnumerator FadeInHiddenObject2()
    {
        float duration = 2.0f; // مدة التحول

        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / duration);

            SetSpriteRenderersAlpha(alpha);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        SetSpriteRenderersAlpha(1f); // ضمان أن القيمة تكون 1 في نهاية التحول
    }

    private void SetSpriteRenderersAlpha(float alpha)
    {
        foreach (var spriteRenderer in spriteRenderers)
        {
            Color color = spriteRenderer.color;
            color.a = alpha;
            spriteRenderer.color = color;
        }
    }


}

