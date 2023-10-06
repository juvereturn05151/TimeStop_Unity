using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonCameraController : MonoBehaviour
{
    public float RotationSpeed = 1;
    public Transform Target, Player;
    float mouseX, mouseY;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
        CamControl();
    }

    private void CamControl()
    {
        mouseY = Mathf.Clamp(mouseY, -35, 60);

        transform.LookAt(Target);

        Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        Player.rotation = Quaternion.Euler(0, mouseX, 0);
    }

    public void Rotate(InputAction.CallbackContext context)
    {
        Vector2 newVector = context.ReadValue<Vector2>();

        mouseX += newVector.x * RotationSpeed;
        mouseY -= newVector.y * RotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -35, 60);
    }
}
