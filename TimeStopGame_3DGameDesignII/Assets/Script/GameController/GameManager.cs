using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    public static bool HasInstance => (Instance != null);

    public float ControllableTimeScale { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        ControllableTimeScale = 1.0f;
    }

    public void SetControllableTimeScale(float newDeltaTime) 
    {
        ControllableTimeScale = newDeltaTime;
    }
}
