using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStateMachine 
{
    public BossState currentState { get; private set; }

    public void Initialize(BossState bossState)
    {
        currentState = bossState;
        currentState.Enter();
    }

    public void ChangeState(BossState bossState)
    {
        currentState.Exit();
        currentState = bossState;
        currentState.Enter();
    }
}
