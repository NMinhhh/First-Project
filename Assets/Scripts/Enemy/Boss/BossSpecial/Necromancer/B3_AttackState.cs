using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B3_AttackState : BossRangeAttackState
{
    private NecromancerBoss necromancer;
    private GameObject projectile;
    private ProjectileFollow script;
    public B3_AttackState(Boss boss, BossStateMachine stateMachine, string isBoolName, Transform attackPoint, BossRangeAttackData data, NecromancerBoss necromancer) : base(boss, stateMachine, isBoolName, attackPoint, data)
    {
        this.necromancer = necromancer;
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
            stateMachine.ChangeState(necromancer.PlayerDetectedState);
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }

    public override void TriggerAnimation()
    {
        base.TriggerAnimation();
        Vector2 lockDir = boss.player.transform.position - boss.transform.position;
        float angle = Mathf.Atan2(lockDir.y, lockDir.x) * Mathf.Rad2Deg;
        SoundFXManager.Instance.CreateAudio(SoundFXManager.Instance.GetAudio(3), boss.transform, 1);
        if(boss.facingDir == 1)
        {
            projectile = GameObject.Instantiate(data.projectile, attackPoint.position, Quaternion.Euler(0, 0, angle));
        }
        else
        {
            float dir = 180 + angle;
            projectile = GameObject.Instantiate(data.projectile, attackPoint.position, Quaternion.Euler(0, 180, -dir));
        }
        script = projectile.GetComponent<ProjectileFollow>();
        script.Create(data.speed, data.damage, data.overFlyTime);

    }

}
