using UnityEngine;
using JuveProduction.GameSystem;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    [SerializeField]
    private List<PlayerAction> _playerActions;

    private Animator _animator;

    public Animator Animator => _animator;

    private CharacterController _characterController;

    public CharacterController CharacterController => _characterController;

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
        _animator = GetComponentInChildren<Animator>();
        _characterController = GetComponent<CharacterController>();
        _playerMovement = GetComponent<PlayerMovement>();

        if (GameplayUIManager.HasInstance) 
        {
            _gameplayUIManager = GameplayUIManager.Instance;
        }
         
        Excitement = 0;

        if (_playerActions != null && _playerActions.Count > 0) 
        {
            foreach (PlayerAction _playerAction in _playerActions) 
            {
                _playerAction.InitAction(this);
            }
        }
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
