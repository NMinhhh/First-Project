using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B6_MoveState : BossMoveState
{
    private NightBorne nightBorne;
    public B6_MoveState(Boss boss, BossStateMachine stateMachine, string isBoolName, BossMoveData data, NightBorne nightBorne) : base(boss, stateMachine, isBoolName, data)
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
        if (isPlayerDetected)
        {
            stateMachine.ChangeState(nightBorne.PlayerDetectedState);
        }
        else if (boss.isSkill && isLongRangePlayerDetected)
        {
            stateMachine.ChangeState(nightBorne.PlayerDetectedState);
        }
        else if (isDistance)
        {
            stateMachine.ChangeState(nightBorne.IdleState);
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
