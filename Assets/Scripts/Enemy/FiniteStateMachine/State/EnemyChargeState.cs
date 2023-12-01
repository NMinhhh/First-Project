using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChargeState : EnemyState
{
    protected EnemyChargeData data;
    protected bool isPlayerDetected;
    protected bool isWall;
    protected bool isLedge;
    protected bool isCloseRangPlayer;
    protected bool isLongRangPlayer;
    public EnemyChargeState(EnemyStateMachine stateMachine, Entity entity, string isBoolName, EnemyChargeData data) : base(stateMachine, entity, isBoolName)
    {
        this.data = data;
    }

    public override void DoCheck()
    {
        base.DoCheck();
        isPlayerDetected = entity.CheckPlayerDetected();
        isLedge = entity.CheckLedge();
        isWall = entity.CheckWall();
        isCloseRangPlayer = entity.CheckChoseRangePlayerDetected();
        isLongRangPlayer = entity.CheckLongRangePlayerDetected();
    }

    public override void Enter()
    {
        base.Enter();
        entity.SetVelocityX(data.chargeSpeed);
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
        entity.SetVelocityX(data.chargeSpeed);

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
