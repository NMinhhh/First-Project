using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E6_MeleeAttackState : EnemyMeleeAttackState
{
    private Enemy6 enemy;
    public E6_MeleeAttackState(EnemyStateMachine stateMachine, Entity entity, string isBoolName, Transform pointAttack, EnemyMeleeAttackData data, Enemy6 enemy) : base(stateMachine, entity, isBoolName, pointAttack, data)
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
