using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script store the fundamental attribute of enemy and instantiate "State" or its behavior
/// </summary>

public class EnemyAgent : MonoBehaviour
{

    public EnemyShoot Gun;

    [Tooltip("move speed of this enemy when attacking")]
    public float speed = 6;

    [HideInInspector]public GameManager gameManager;
    [HideInInspector]public GameObject target;


    //use to store the current state or behavior of the enemy
    private State _currentState;
    public State currentState
    {
        get { return _currentState; }
        set
        {
            if (_currentState != null)
            {
                _currentState.OnExit();
            }
            _currentState = value;
            _currentState.OnEntry();
        }
    }

    // Set the dafault state to idle
    public virtual void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        target = GameObject.FindGameObjectWithTag("Player");
        currentState = new StateIdle(this);
    }

    //Update the current state of the enemy
    public virtual void Update()
    {
        currentState.OnState();
    }

    public void Shoot()
    {
        if (Gun != null)
        {
            Gun.Shoot();
        }
    }

}
