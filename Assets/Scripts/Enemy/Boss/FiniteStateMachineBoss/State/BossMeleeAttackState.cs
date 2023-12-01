using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMeleeAttackState : BossState
{
    protected BossMeleeAttackData data;
    protected Transform attackPoint;
    public BossMeleeAttackState(Boss boss, BossStateMachine stateMachine, string isBoolName, Transform attackPoint , BossMeleeAttackData data) : base(boss, stateMachine, isBoolName)
    {
        this.attackPoint = attackPoint;
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
        Collider2D[] hit = Physics2D.OverlapCircleAll(attackPoint.position, data.radius, data.whatIsPlayer);
        boss.attackDetails.attackDamage = data.damage;
        foreach(Collider2D col in hit)
        {
            if (col)
            {
                boss.attackDetails.attackPos = col.transform;
                col.transform.SendMessage("Damage", boss.attackDetails);
            }
        }
    }
}
