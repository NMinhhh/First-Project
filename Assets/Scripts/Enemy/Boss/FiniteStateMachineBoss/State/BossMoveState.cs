using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMoveState : BossState
{
    protected BossMoveData data;
    protected bool isPlayerDetected;
    protected bool isLongRangePlayerDetected;
    protected bool isDistance;
    public BossMoveState(Boss boss, BossStateMachine stateMachine, string isBoolName, BossMoveData data) : base(boss, stateMachine, isBoolName)
    {
        this.data = data;
    }

    public override void DoCheck()
    {
        base.DoCheck();
        isPlayerDetected = boss.CheckPlayerDetected();
        isLongRangePlayerDetected = boss.CheckLongRangePlayer();
        isDistance = boss.CheckDistance();
    }

    public override void Enter()
    {
        base.Enter();
        boss.SetVelocityX(data.speed);
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
        boss.SetVelocityX(data.speed);
        boss.CheckIfFlip();
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
