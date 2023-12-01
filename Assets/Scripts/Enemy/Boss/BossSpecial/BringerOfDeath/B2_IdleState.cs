using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B2_IdleState : BossIdleState
{
    private BringerOfDeath bringerOfDeath;
    public B2_IdleState(Boss boss, BossStateMachine stateMachine, string isBoolName, BringerOfDeath bringerOfDeath) : base(boss, stateMachine, isBoolName)
    {
        this.bringerOfDeath = bringerOfDeath;
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
        if(boss.player == null)
        {
            return;
        }
        else if (!isDistance)
        {
            stateMachine.ChangeState(bringerOfDeath.MoveState);
        }else if (isDetected && boss.player != null)
        {
            stateMachine.ChangeState(bringerOfDeath.PlayerDetectedState);
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
