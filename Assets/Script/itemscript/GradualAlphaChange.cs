using System.Collections;
using UnityEngine;

public class GradualAlphaChange : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public AudioSource audioSource;
    public AudioClip fadeInSound;
    public GameObject hiddenObject;
    public GameObject hiddenObject1;
    public GameObject objectToHideDuringSound;
    public GameObject[] objectsToFade;

    public float fadeInDuration = 2f;
    public float fadeOutDuration = 2f;
    public float waitBeforeFadeOut = 2.5f;

    private void Start()
    {
        StartCoroutine(FadeInOut());
    }

    private IEnumerator FadeInOut()
    {
        yield return StartCoroutine(FadeIn(fadeInDuration));
        yield return new WaitForSeconds(waitBeforeFadeOut);
        yield return StartCoroutine(FadeOut(fadeOutDuration));
        hiddenObject.SetActive(true);
        Destroy(hiddenObject1);
    }

    private IEnumerator FadeIn(float duration)
    {
        float timeElapsed = 0f;

        // إخفاء الكائن عند تشغيل الصوت
        objectToHideDuringSound.SetActive(false);

        audioSource.PlayOneShot(fadeInSound);

        while (timeElapsed < duration)
        {
            float alphaValue = Mathf.Lerp(0f, 1f, timeElapsed / duration);
            SetAlpha(spriteRenderer, alphaValue);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        SetAlpha(spriteRenderer, 1f);
    }

    private IEnumerator FadeOut(float duration)
    {
        float timeElapsed = 0f;

        while (timeElapsed < duration)
        {
            float alphaValue = Mathf.Lerp(1f, 0f, timeElapsed / duration);
            SetAlpha(spriteRenderer, alphaValue);
            SetAlphaForObjects(alphaValue);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        SetAlpha(spriteRenderer, 0f);
        audioSource.Stop();

        // إظهار الكائن عند توقف الصوت
        objectToHideDuringSound.SetActive(true);
    }

    private void SetAlpha(SpriteRenderer renderer, float alpha)
    {
        Color color = renderer.color;
        color.a = alpha;
        renderer.color = color;
    }

    private void SetAlphaForObjects(float alphaValue)
    {
        foreach (var obj in objectsToFade)
        {
            var renderer = obj.GetComponent<SpriteRenderer>();
            if (renderer != null)
            {
                SetAlpha(renderer, alphaValue);
            }
        }
    }
}
