using UnityEngine;

public class SpriteDisappear : MonoBehaviour
{
    // دالة تُستدعى عندما يلامس أي شيء السبرايت المُرفق بهذا السكريبت
    public void OnCollisionEnter2D(Collision2D collision)
    {
        // يتم فحص إذا كان الشيء الذي يلامس السبرايت لديه مُركب Renderer
        if (collision.collider.TryGetComponent(out Renderer renderer))
        {
            // إذا كان لديه، سيتم جعله غير مرئي
            renderer.enabled = false;
        }
    }
}