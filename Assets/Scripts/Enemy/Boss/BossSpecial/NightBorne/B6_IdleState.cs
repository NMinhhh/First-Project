using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B6_IdleState : BossIdleState
{
    private NightBorne nightBorne;
    public B6_IdleState(Boss boss, BossStateMachine stateMachine, string isBoolName, NightBorne nightBorne) : base(boss, stateMachine, isBoolName)
    {
        this.nightBorne = nightBorne;
    }
    public override void DoCheck()
    {
        base.DoCheck();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FinishAnimation()
    {
        base.FinishAnimation();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (boss.player == null)
        {
            return;
        }
        else if (!isDistance)
        {
            stateMachine.ChangeState(nightBorne.MoveState);
        }
        else if (isDetected && boss.player != null)
        {
            stateMachine.ChangeState(nightBorne.PlayerDetectedState);
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }

    public override void TriggerAnimation()
    {
        base.TriggerAnimation();
    }
}
