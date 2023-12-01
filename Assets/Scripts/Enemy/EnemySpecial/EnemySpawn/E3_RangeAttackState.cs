using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E3_RangeAttackState : EnemyRangeAttackState
{
    private Enemy3 enemy;
    private GameObject projectile;
    private FireBall fireBall;
    public E3_RangeAttackState(EnemyStateMachine stateMachine, Entity entity, string isBoolName, Transform pointAttack, EnemyRangeAttackData data, Enemy3 enemy) : base(stateMachine, entity, isBoolName, pointAttack, data)
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
        projectile = GameObject.Instantiate(data.fireBall, attackPoint.position, attackPoint.rotation);
        fireBall = projectile.GetComponent<FireBall>();
        fireBall.SetFireBall(data.speed, data.damage, data.overFlyTime);
    }
}
