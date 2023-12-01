using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveState : EnemyState
{
    protected EnemyMoveData data;
    protected bool isWall;
    protected bool isLedge;
    protected bool isPlayerDetected;
    public EnemyMoveState(EnemyStateMachine stateMachine, Entity entity, string isBoolName, EnemyMoveData data) : base(stateMachine, entity, isBoolName)
    {
        this.data = data;
    }

    public override void DoCheck()
    {
        base.DoCheck();
        isWall = entity.CheckWall();
        isLedge = entity.CheckLedge();
        isPlayerDetected = entity.CheckPlayerDetected();
    }

    public override void Enter()
    {
        base.Enter();
        entity.SetVelocityX(data.movementSpeed);
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
        entity.SetVelocityX(data.movementSpeed);
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
