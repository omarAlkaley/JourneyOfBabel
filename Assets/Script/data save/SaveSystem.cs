using UnityEngine;

public static class SaveSystem
{
    private const string CurrentWallKey = "CurrentWall";
    private const string HasReachedWall1Key = "HasReachedWall1";

    public static void SaveWallData(int currentWall)
    {
        PlayerPrefs.SetInt(CurrentWallKey, currentWall);

        // إذا كان الجدار الحالي هو 1، نقوم بحفظ هذه الحالة
        if (currentWall == 1)
        {
            PlayerPrefs.SetInt(HasReachedWall1Key, 1); // حفظ 1 يعني أن الجدار 1 تم الوصول إليه
        }

        PlayerPrefs.Save();
    }

    public static int LoadWallData()
    {
        return PlayerPrefs.GetInt(CurrentWallKey, 1); // القيمة الافتراضية هي 1
    }

    public static bool HasReachedWall1()
    {
        return PlayerPrefs.GetInt(HasReachedWall1Key, 0) == 1; // إذا كانت القيمة 1، فهذا يعني أن الجدار 1 تم الوصول إليه
    }
}
