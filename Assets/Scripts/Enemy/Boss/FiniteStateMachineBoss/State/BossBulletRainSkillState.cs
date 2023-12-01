using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletRainSkillState : BossState
{
    protected BossBulletRainSkillData data;
    protected bool isFinishSkill;
    protected float currentAmountOfBullet;
    public BossBulletRainSkillState(Boss boss, BossStateMachine stateMachine, string isBoolName, BossBulletRainSkillData data) : base(boss, stateMachine, isBoolName)
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
        isFinishSkill = false;
        currentAmountOfBullet = data.amountOfBullet;
    }

    public override void Exit()
    {
        base.Exit();
        boss.ResetCooldownTimer(Time.time);
        boss.isSkill = false;
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
    }
}
