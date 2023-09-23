using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script initialize abstract class for state machine
/// </summary>

public abstract class State
{
    public EnemyAgent Enemy_Agent { get; set; }
    public State() { }
    public State(EnemyAgent enemy)
    {
        Enemy_Agent = enemy;
    }

    public abstract void OnState();
    public abstract void OnEntry();
    public abstract void OnExit();
}
