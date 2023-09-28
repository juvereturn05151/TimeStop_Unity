using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    public static bool HasInstance => (Instance != null);

    public float ControllableTimeScale = 1.0f;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }
}
