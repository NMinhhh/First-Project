using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B3_PlayerDetectedState : BossPlayerDetectedState
{
    private NecromancerBoss necromancer;
    public B3_PlayerDetectedState(Boss boss, BossStateMachine stateMachine, string isBoolName, BossPlayerDetectedData data, NecromancerBoss necromancer) : base(boss, stateMachine, isBoolName, data)
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
        if (boss.isSkill)
        {
            stateMachine.ChangeState(necromancer.SkillSpawnState);
        }
        else if(isOverDetected && isPlayerDetected)
        {
            stateMachine.ChangeState(necromancer.AttackState);
        }
        else if (!isPlayerDetected)
        {
            stateMachine.ChangeState(necromancer.MoveState);
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
