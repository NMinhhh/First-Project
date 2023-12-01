using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B5_PlayerDetectedState : BossPlayerDetectedState
{
    private Golem golem;
    public B5_PlayerDetectedState(Boss boss, BossStateMachine stateMachine, string isBoolName, BossPlayerDetectedData data, Golem golem) : base(boss, stateMachine, isBoolName, data)
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
    }

    public override void FinishAnimation()
    {
        base.FinishAnimation();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(boss.isSkill && isLongRangePlayerDetected)
        {
            stateMachine.ChangeState(golem.BulletSkillState);
        }
        else if (isOverDetected && isPlayerDetected)
        {
            stateMachine.ChangeState(golem.MeleeAttackState);
        }
        else if (!isPlayerDetected)
        {
            stateMachine.ChangeState(golem.MoveState);
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
