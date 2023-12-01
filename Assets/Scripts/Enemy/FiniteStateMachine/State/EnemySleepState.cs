using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySleepState : EnemyState
{
    protected bool isPlayerDetected;
    protected bool isLongRangePlayerDetected;
    public EnemySleepState(EnemyStateMachine stateMachine, Entity entity, string isBoolName) : base(stateMachine, entity, isBoolName)
    {
    }

    public override void DoCheck()
    {
        base.DoCheck();
        isPlayerDetected = entity.CheckPlayerDetected();
        isLongRangePlayerDetected = entity.CheckLongRangePlayerDetected();
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
