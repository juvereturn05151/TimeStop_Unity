using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;
    private Animator animator;

    [SerializeField]
    private float moveSpeed = 100;
    [SerializeField]
    private float turnSpeed = 5f;

    float noise;

    float noiseDivider = 100.0f;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {


        var horizontal = Input.GetAxis("Horizontal") * transform.right;
        var vertical = Input.GetAxis("Vertical") * transform.forward;

        var movement = horizontal + vertical;

        //Debug.Log("NoiseMaking" + ((horizontal.magnitude + vertical.magnitude)/20.0f));

        noise = (horizontal.magnitude + vertical.magnitude) / noiseDivider;

        characterController.SimpleMove(movement * Time.deltaTime * moveSpeed);

        animator.SetFloat("SpeedX", Input.GetAxis("Horizontal"));
        animator.SetFloat("SpeedY", Input.GetAxis("Vertical"));

        //Debug.Log("SpeedX" + animator.GetFloat("SpeedX"));
        //Debug.Log("SpeedY" + animator.GetFloat("SpeedY"));

    }

    public float GetNoise()
    {
        return noise;
    }
}
