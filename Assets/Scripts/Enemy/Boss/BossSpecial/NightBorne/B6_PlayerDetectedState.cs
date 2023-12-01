using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B6_PlayerDetectedState : BossPlayerDetectedState
{
    private NightBorne nightBorne;
    public B6_PlayerDetectedState(Boss boss, BossStateMachine stateMachine, string isBoolName, BossPlayerDetectedData data, NightBorne nightBorne) : base(boss, stateMachine, isBoolName, data)
    {
        this.nightBorne = nightBorne;
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
            stateMachine.ChangeState(nightBorne.BoltRainSkillState);
        }
        else if (isOverDetected && isPlayerDetected)
        {
            stateMachine.ChangeState(nightBorne.MeleeAttackState);
        }
        else if (!isPlayerDetected)
        {
            stateMachine.ChangeState(nightBorne.MoveState);
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
