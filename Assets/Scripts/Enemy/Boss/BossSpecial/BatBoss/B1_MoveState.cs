using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B1_MoveState : BossMoveState
{
    private BatBoss batBoss;
    public B1_MoveState(Boss boss, BossStateMachine stateMachine, string isBoolName, BossMoveData data, BatBoss batBoss) : base(boss, stateMachine, isBoolName, data)
    {
        this.batBoss = batBoss;
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
        if (isLongRangePlayerDetected)
        {
            stateMachine.ChangeState(batBoss.DetectedPlayerState);
        }else if (isDistance)
        {
            stateMachine.ChangeState(batBoss.IdleState);
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
