using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerCrouch : PlayerAction
{
    private const float _normalHeight = 2;
    private const float _normalCenterY = 0;
    private const float _crouchHeight = 1;
    private const float _crouchCenterY = -0.5f;
    private bool _crouch;

    public void Crouch(InputAction.CallbackContext context)
    {
        if (context.performed) 
        {
            _crouch = !_crouch;

            _player.Animator.SetBool("Crouch", _crouch);

            if (_crouch)
            {
                _player.CharacterController.height = _crouchHeight;
                _player.CharacterController.center = new Vector3(_player.CharacterController.center.x, _crouchCenterY, _player.CharacterController.center.z);
            }
            else
            {
                _player.CharacterController.height = _normalHeight;
                _player.CharacterController.center = new Vector3(_player.CharacterController.center.x, _normalCenterY, _player.CharacterController.center.z);
            }
        }
    }
}
