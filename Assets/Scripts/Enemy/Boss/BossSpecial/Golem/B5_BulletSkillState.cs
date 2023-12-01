using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B5_BulletSkillState : BossRangeAttackState
{
    private Golem golem;
    private GameObject Go;
    private FireBall script;
    public B5_BulletSkillState(Boss boss, BossStateMachine stateMachine, string isBoolName, Transform attackPoint, BossRangeAttackData data, Golem golem) : base(boss, stateMachine, isBoolName, attackPoint, data)
    {
        this.golem = golem;
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
        boss.isSkill = false;
        boss.ResetCooldownTimer(Time.time);
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
            stateMachine.ChangeState(golem.PlayerDetectedState);
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }

    public override void TriggerAnimation()
    {
        base.TriggerAnimation();
        Spawn();
        Spawn();
        Spawn();
        Spawn();
        Spawn();

    }

    void Spawn()
    {
        Go = GameObject.Instantiate(data.projectile,attackPoint.position, attackPoint.rotation);
        script = Go.GetComponent<FireBall>();
        script.SetFireBall(Random.Range(data.randomSpeed.x,data.randomSpeed.y), data.damage, data.overFlyTime);
    }
}
