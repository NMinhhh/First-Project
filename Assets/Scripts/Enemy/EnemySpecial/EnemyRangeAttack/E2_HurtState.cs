using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2_HurtState : EnemyHurtState
{
    private Enemy2 enemy;
    public E2_HurtState(EnemyStateMachine stateMachine, Entity entity, string isBoolName, EnemyHurtData data, Enemy2 enemy) : base(stateMachine, entity, isBoolName, data)
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
            stateMachine.ChangeState(enemy.PlayerDetected);
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
