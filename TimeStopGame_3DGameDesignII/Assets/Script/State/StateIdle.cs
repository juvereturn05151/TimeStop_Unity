using UnityEngine;

/// <summary>
/// Idle state machine that reset the postion and rotation of player to 0
/// </summary>

public class StateIdle : State
{
    public StateIdle(EnemyAgent enemy)
    {
        this.Enemy_Agent = enemy;
    }
    
    public override void OnEntry()
    {
        //Enemy_Agent.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        //Enemy_Agent.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
    }

    public override void OnState()
    {

    }

    public override void OnExit()
    {

    }
}