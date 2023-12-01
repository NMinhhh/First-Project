using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPlayerDetectedState : BossState
{
    protected BossPlayerDetectedData data;
    protected bool isPlayerDetected;
    protected bool isLongRangePlayerDetected;
    protected bool isOverDetected;
    protected bool isDistance;
    public BossPlayerDetectedState(Boss boss, BossStateMachine stateMachine, string isBoolName, BossPlayerDetectedData data) : base(boss, stateMachine, isBoolName)
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
        isOverDetected = false;
        boss.SetVelocityZero();
        
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
        if(Time.time >= startTime + data.overDetecttedTime)
        {
            isOverDetected = true;
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
