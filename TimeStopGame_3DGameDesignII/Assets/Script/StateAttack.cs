using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script checks the type of enemy, then call its own attack state
/// </summary>

public class StateAttack : State
{
    public StateAttack(EnemyAgent enemy)
    {
        this.Enemy_Agent = enemy;
    }

    public override void OnEntry()
    {
        //if the target is null or inactive, skip attack and go to "GoBackToSpot" state
        if (Enemy_Agent.target == null || !Enemy_Agent.target.activeSelf)
        {

        }
    }

    public override void OnState()
    {
        Vector3 targetDir = Enemy_Agent.target.transform.position - Enemy_Agent.transform.position;

        //// The step size is equal to speed times frame time.
        float step = 2.0f * GameManager.Instance.ControllableTimeScale * Time.deltaTime;

        //Vector3 newDir = Vector3.RotateTowards(Enemy_Agent.transform.forward, targetDir, step, 0.0f);

        Quaternion rotation = Quaternion.LookRotation(targetDir);

        Enemy_Agent.transform.rotation = Quaternion.Lerp(Enemy_Agent.transform.rotation, rotation, step);
        Enemy_Agent.transform.eulerAngles = new Vector3(0.0f, Enemy_Agent.transform.eulerAngles.y, 0.0f);

        // Move our position a step closer to the target.
        //Enemy_Agent.transform.rotation = Quaternion.LookRotation(newDir);

        Enemy_Agent.Shoot();
    }

    public override void OnExit()
    {

    }
}
