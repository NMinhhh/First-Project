using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E6_RangeAttackState : EnemyRangeAttackState
{
    private Enemy6 enemy;
    private GameObject Go;
    private ProjectileFollow script;
    public E6_RangeAttackState(EnemyStateMachine stateMachine, Entity entity, string isBoolName, Transform pointAttack, EnemyRangeAttackData data, Enemy6 enemy) : base(stateMachine, entity, isBoolName, pointAttack, data)
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
        if(isFinishAnimation)
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
        Vector2 lookDir = entity.Player.transform.position - attackPoint.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        if (entity.facingDir == 1)
        {
            Go = GameObject.Instantiate(data.fireBall, attackPoint.position, Quaternion.Euler(0, 0, angle));
        }
        else
        {
            float dir = 180 + angle;
            Go = GameObject.Instantiate(data.fireBall, attackPoint.position, Quaternion.Euler(0, 180, -dir));
        }
        script = Go.GetComponent<ProjectileFollow>();
        script.Create(data.speed, data.damage, data.overFlyTime);
    }
}
