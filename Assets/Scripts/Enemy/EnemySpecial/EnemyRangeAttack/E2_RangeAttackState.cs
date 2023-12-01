using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2_RangeAttackState : EnemyRangeAttackState
{
    private Enemy2 enemy;
    private GameObject projectile;
    private FireBall fireBall;
    public E2_RangeAttackState(EnemyStateMachine stateMachine, Entity entity, string isBoolName, Transform pointAttack, EnemyRangeAttackData data, Enemy2 enemy) : base(stateMachine, entity, isBoolName, pointAttack, data)
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
        projectile = GameObject.Instantiate(data.fireBall, attackPoint.position, attackPoint.rotation);
        fireBall = projectile.GetComponent<FireBall>();
        fireBall.SetFireBall(data.speed, data.damage, data.overFlyTime);
    }
}
