using UnityEngine;

public class WallManager : MonoBehaviour
{
    public static WallManager Instance { get; private set; }

    private int currentWall;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public int CurrentWall
    {
        get { return currentWall; }
        set { currentWall = value; }
    }
}
