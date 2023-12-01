using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B4_MoveState : BossMoveState
{
    private Guardian guardian;
    public B4_MoveState(Boss boss, BossStateMachine stateMachine, string isBoolName, BossMoveData data, Guardian guardian) : base(boss, stateMachine, isBoolName, data)
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
        if (isPlayerDetected)
        {
            stateMachine.ChangeState(guardian.PlayerDetectedState);
        }
        else if (isDistance)
        {
            stateMachine.ChangeState(guardian.IdleState);
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
