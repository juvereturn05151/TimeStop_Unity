using System.Collections;
using JuveProduction.GameSystem;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    private GameObject _timeStopUI;

    private Animator animator;
    private CharacterController characterController;
    private Player player;
    private bool crouch = false;
    private float normalHeight = 2;
    private float normalCenterY = 0;
    private float crouchHeight = 1;
    private float crouchCenterY = -0.5f;
    private IEnumerator coroutine;

    public GameObject HitBox;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        characterController = GetComponent<CharacterController>();
        player = GetComponent<Player>();

        if (GameplayUIManager.HasInstance) 
        {
            _timeStopUI = GameplayUIManager.Instance.TimeStopUI;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_timeStopUI.activeSelf)
        {
            player.DecreaseExcitement(0.1f);
        }

        if (player.Excitement <= 0)
        {
            StopTime(false);
        }

        if (Input.GetButtonDown("TimeStop"))
        {
            player.SetExcitement(1);

            if (!_timeStopUI.activeSelf && player.Excitement >= 1)
            {
                StopTime(true);
            }
        }

        if (Input.GetButtonDown("Crouch"))
        {
            Crouch(crouch = !crouch);
        }

        if (Input.GetButtonDown("Take"))
        {
            coroutine = TakeGun();
            StartCoroutine(coroutine);
        }
    }

    public void StopTime(bool stopTime)
    {
        _timeStopUI.SetActive(stopTime);

        if (stopTime)
        {
            GameManager.Instance.ControllableTimeScale = 0;
        }
        else 
        {
            GameManager.Instance.ControllableTimeScale = 1;
        }
    }

    public void Crouch(bool crouch)
    {
        animator.SetBool("Crouch", crouch);

        if (crouch)
        {
            characterController.height = crouchHeight;
            characterController.center = new Vector3(characterController.center.x, crouchCenterY, characterController.center.z); 
        }
        else
        {
            characterController.height = normalHeight;
            characterController.center = new Vector3(characterController.center.x, normalCenterY, characterController.center.z);
        }
    }

    private IEnumerator TakeGun()
    {
        HitBox.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        HitBox.SetActive(false);
    }
}
