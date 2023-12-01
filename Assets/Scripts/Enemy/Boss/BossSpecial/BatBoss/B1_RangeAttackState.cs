using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B1_RangeAttackState : BossRangeAttackState
{
    private BatBoss batBoss;
    private GameObject projectile;
    private FireBall fireBall;
    public B1_RangeAttackState(Boss boss, BossStateMachine stateMachine, string isBoolName, Transform attackPoint, BossRangeAttackData data, BatBoss batBoss) : base(boss, stateMachine, isBoolName, attackPoint, data)
    {
        this.batBoss = batBoss;
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
            stateMachine.ChangeState(batBoss.DetectedPlayerState);
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }

    public override void TriggerAnimation()
    {
        base.TriggerAnimation();
        projectile = GameObject.Instantiate(data.projectile,attackPoint.position,attackPoint.rotation);
        fireBall = projectile.GetComponent<FireBall>();
        fireBall.SetFireBall(data.speed, data.damage, data.overFlyTime);
        SoundFXManager.Instance.CreateAudio(SoundFXManager.Instance.GetAudio(0), boss.transform, 1);
    }
}
