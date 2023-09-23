using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    private Animator animator;
    private CharacterController characterController;
    private Player player;

    [SerializeField]
    GameObject TimeStopUI;

    bool crouch = false;

    float normalHeight = 2;
    float normalCenterY = 0;

    float crouchHeight = 1;
    float crouchCenterY = -0.5f;

    private IEnumerator coroutine;

    public GameObject HitBox;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        characterController = GetComponent<CharacterController>();
        player = GetComponent<Player>();

    }

    // Update is called once per frame
    void Update()
    {
        if (TimeStopUI.activeSelf)
        {
            player.decreaseExcitement(0.1f);
        }

        if (player.exciteSlider.value == 0)
        {
            StopTime(false);
        }

        if (Input.GetButtonDown("TimeStop"))
        {
            //Just for 2nd version
            player.exciteSlider.value = 1;

            Debug.Log("BeforeTimeStop");
            Debug.Log("TimeStopUI.activeSelf" + TimeStopUI.activeSelf);
            Debug.Log("player.exciteSlider.value" + player.exciteSlider.value);
            if (!TimeStopUI.activeSelf && player.exciteSlider.value == 1)
            {
                Debug.Log("TimeStop");
                StopTime(true);
            }
        }

        if (Input.GetButtonDown("Crouch"))
        {
            Debug.Log("Crouch" + crouch);
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
        TimeStopUI.SetActive(stopTime);
        
        if(stopTime)
            GameManager.Instance.ControllableTimeScale = 0;
        else
            GameManager.Instance.ControllableTimeScale = 1;
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
