using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B4_IdleState : BossIdleState
{
    private Guardian guardian;
    public B4_IdleState(Boss boss, BossStateMachine stateMachine, string isBoolName, Guardian guardian) : base(boss, stateMachine, isBoolName)
    {
        this.guardian = guardian;
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
            stateMachine.ChangeState(guardian.MoveState);
        }
        else if (isDetected && boss.player != null)
        {
            stateMachine.ChangeState(guardian.PlayerDetectedState);
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
