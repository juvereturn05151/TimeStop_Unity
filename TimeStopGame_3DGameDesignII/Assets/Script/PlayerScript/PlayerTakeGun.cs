using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine;

public class PlayerTakeGun : PlayerAction
{
    [SerializeField]
    private GameObject _hitBox;

    private const float _hitboxDelayDisappearTime = 2.0f;

    public void TakeGun(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            StartCoroutine(TakeGun());
        }
    }

    private IEnumerator TakeGun()
    {
        _hitBox.SetActive(true);
        yield return new WaitForSeconds(_hitboxDelayDisappearTime);
        _hitBox.SetActive(false);
    }
}
