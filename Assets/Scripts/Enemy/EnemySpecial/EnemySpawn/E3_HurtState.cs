using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E3_HurtState : EnemyHurtState
{
    private Enemy3 enemy;
    public E3_HurtState(EnemyStateMachine stateMachine, Entity entity, string isBoolName, EnemyHurtData data, Enemy3 enemy) : base(stateMachine, entity, isBoolName, data)
    {
        this.enemy = enemy;
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
        if (isFinishAnimation)
        {
            if (!isPlayerDetected)
                entity.Flip();
            stateMachine.ChangeState(enemy.PlayerDetectedState);
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
