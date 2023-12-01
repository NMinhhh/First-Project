using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B1_DetectedPlayerState : BossPlayerDetectedState
{
    private BatBoss batBoss;
    public B1_DetectedPlayerState(Boss boss, BossStateMachine stateMachine, string isBoolName, BossPlayerDetectedData data, BatBoss batBoss) : base(boss, stateMachine, isBoolName, data)
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
        if(boss.isSkill && isLongRangePlayerDetected)
        {
            stateMachine.ChangeState(batBoss.BulletRainSkillState);
        }
        else if(isOverDetected && isLongRangePlayerDetected && !isPlayerDetected)
        {
            stateMachine.ChangeState(batBoss.RangeAttackState);
        }else if (!isLongRangePlayerDetected && !isDistance)
        {
            stateMachine.ChangeState(batBoss.MoveState);
        }else if(isOverDetected && isPlayerDetected)
        {
            stateMachine.ChangeState(batBoss.MeleeAttackState);
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
