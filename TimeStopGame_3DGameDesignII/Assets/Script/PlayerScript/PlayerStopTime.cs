using UnityEngine.InputSystem;
using JuveProduction.GameSystem;
using UnityEngine;

public class PlayerStopTime : PlayerAction
{
    private GameObject _timeStopUI;
    private GameManager _gameManager;

    private void Start()
    {
        if (GameplayUIManager.HasInstance)
        {
            _timeStopUI = GameplayUIManager.Instance.TimeStopUI;
        }

        if (GameManager.HasInstance) 
        {
            _gameManager = GameManager.Instance;
        }
    }

    private void Update()
    {
        if (_timeStopUI.activeSelf)
        {
            _player.DecreaseExcitement(0.1f);
        }

        if (_player.Excitement <= 0)
        {
            TimeStop(false);
        }
    }

    public void StopTime(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _player.SetExcitement(1);

            if (!_timeStopUI.activeSelf && _player.Excitement >= 1)
            {
                TimeStop(true);
            }
        }
    }

    public void TimeStop(bool stopTime)
    {
        _timeStopUI.SetActive(stopTime);

        if (stopTime)
        {
            _gameManager.SetControllableTimeScale(0);
        }
        else
        {
            _gameManager.SetControllableTimeScale(1);
        }
    }

}
