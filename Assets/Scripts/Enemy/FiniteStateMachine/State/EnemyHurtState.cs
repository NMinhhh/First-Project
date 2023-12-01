using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurtState : EnemyState
{
    protected EnemyHurtData data;
    protected bool isPlayerDetected;
    public EnemyHurtState(EnemyStateMachine stateMachine, Entity entity, string isBoolName, EnemyHurtData data) : base(stateMachine, entity, isBoolName)
    {
        this.data = data;
    }

    public override void DoCheck()
    {
        base.DoCheck();
        isPlayerDetected = entity.CheckPlayerDetected();
    }

    public override void Enter()
    {
        base.Enter();
        entity.SetKnockBack(data.knockBackSpeed);
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
