using UnityEngine;
using JuveProduction.GameSystem;

public class Player : MonoBehaviour
{
    private float _excitement;

    private PlayerMovement _playerMovement;
    public PlayerMovement PlayerMovement => _playerMovement;

    private GameplayUIManager _gameplayUIManager;

    public float Excitement
    {
        get { return _excitement; }
        private set
        {
            _excitement = Mathf.Clamp01(value);
        }
    }

    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();

        if (GameplayUIManager.HasInstance) 
        {
            _gameplayUIManager = GameplayUIManager.Instance;
        }
         
        Excitement = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            gameObject.SetActive(false);
        }
    }

    public void IncreaseExcitement(float increaseRate)
    {
        Excitement += increaseRate;
        OnExcitementChange();
    }

    public void DecreaseExcitement(float decreaseRate)
    {
        Excitement -= decreaseRate * Time.deltaTime;
        OnExcitementChange();
    }

    public void SetExcitement(float targetExcitement) 
    {
        Excitement = targetExcitement;
        OnExcitementChange();
    }

    private void OnExcitementChange() 
    {
        if (_gameplayUIManager != null)
        {
            _gameplayUIManager.WhenExcitementChanged?.Invoke(Excitement);
        }
    }
}
