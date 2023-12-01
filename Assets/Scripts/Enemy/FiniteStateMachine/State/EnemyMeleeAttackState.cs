using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttackState : EnemyAttackState
{
    protected EnemyMeleeAttackData data;
    public EnemyMeleeAttackState(EnemyStateMachine stateMachine, Entity entity, string isBoolName, Transform pointAttack, EnemyMeleeAttackData data) : base(stateMachine, entity, isBoolName, pointAttack)
    {
        this.data = data;
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
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }

    public override void TriggerAnimation()
    {
        base.TriggerAnimation();
        Collider2D[] hit = Physics2D.OverlapCircleAll(attackPoint.position, data.radiusAttackPoint, data.whatIsPlayer);
        entity.attackDetails.attackDamage = data.damage;
        entity.attackDetails.attackPos = entity.transform;
        foreach (Collider2D col in hit)
        {
            if (col)
            {
                col.transform.SendMessage("Damage", entity.attackDetails);
            }
        }
    }
}
