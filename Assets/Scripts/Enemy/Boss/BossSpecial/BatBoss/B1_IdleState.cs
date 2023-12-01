using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B1_IdleState : BossIdleState
{
    private BatBoss batBoss;
    public B1_IdleState(Boss boss, BossStateMachine stateMachine, string isBoolName, BatBoss batBoss) : base(boss, stateMachine, isBoolName)
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
        boss.CheckIfFlip();
        if (isDetected)
        {
            stateMachine.ChangeState(batBoss.DetectedPlayerState);
        }else if (!isDistance && boss.player != null)
        {
            stateMachine.ChangeState(batBoss.MoveState);
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
