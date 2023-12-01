using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E4_HurtState : EnemyHurtState
{
    private Enemy4 enemy;
    public E4_HurtState(EnemyStateMachine stateMachine, Entity entity, string isBoolName, EnemyHurtData data, Enemy4 enemy) : base(stateMachine, entity, isBoolName, data)
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
        if (enemy.CheckSkill())
        {
            if (!isPlayerDetected)
                entity.Flip();
            stateMachine.ChangeState(enemy.BlockState);
        }
        if (isFinishAnimation)
        {
            if (!isPlayerDetected)
                enemy.Flip();
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
