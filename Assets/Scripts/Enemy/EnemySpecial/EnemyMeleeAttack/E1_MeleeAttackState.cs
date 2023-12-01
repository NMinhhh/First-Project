using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_MeleeAttackState : EnemyMeleeAttackState
{
    private Enemy1 enemy;
    public E1_MeleeAttackState(EnemyStateMachine stateMachine, Entity entity, string isBoolName, Transform pointAttack, EnemyMeleeAttackData data, Enemy1 enemy) : base(stateMachine, entity, isBoolName, pointAttack, data)
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
