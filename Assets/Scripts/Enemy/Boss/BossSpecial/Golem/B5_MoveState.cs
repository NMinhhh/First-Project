using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B5_MoveState : BossMoveState
{
    private Golem golem;
    public B5_MoveState(Boss boss, BossStateMachine stateMachine, string isBoolName, BossMoveData data, Golem golem) : base(boss, stateMachine, isBoolName, data)
    {
        this.golem = golem;
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
            stateMachine.ChangeState(golem.PlayerDetectedState);
        }else if(boss.isSkill && isLongRangePlayerDetected)
        {
            stateMachine.ChangeState(golem.PlayerDetectedState);
        }
        else if (isDistance)
        {
            stateMachine.ChangeState(golem.IdleState);
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
