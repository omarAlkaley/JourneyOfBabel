using UnityEngine;

public class SocialMediaButtons : MonoBehaviour
{
    // أضف روابط وسائل التواصل الاجتماعي أو الروابط الأخرى هنا
    private string instagramURL = "https://www.instagram.com/homed.ai?igshid=MTJiYjlrazFsMDNjMA==";
    private string tiktokURL = "https://www.tiktok.com/@savor9?_t=8nh4UZxYSKA&_r=1";
    private string youtubeURL = "https://www.youtube.com/channel/YourChannel"; // قم بتعديل الرابط بما يتناسب مع حسابك
    private string facebookURL = "https://www.facebook.com/profile.php?id=61561809332250";
    private string customURL = "http://1cc2cc.com"; // رابط مخصص

    public void OpenInstagram()
    {
        Application.OpenURL(instagramURL);
    }

    public void OpenTikTok()
    {
        Application.OpenURL(tiktokURL);
    }

    public void OpenYouTube()
    {
        Application.OpenURL(youtubeURL);
    }

    public void OpenFacebook()
    {
        Application.OpenURL(facebookURL);
    }

    public void OpenCustomURL()
    {
        Application.OpenURL(customURL);
    }
}
