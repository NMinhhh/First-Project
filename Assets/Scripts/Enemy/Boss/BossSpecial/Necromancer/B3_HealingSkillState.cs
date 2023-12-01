using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B3_HealingSkillState : BossHealingState
{
    private NecromancerBoss necromancer;
    public B3_HealingSkillState(Boss boss, BossStateMachine stateMachine, string isBoolName, BossHealingData data, NecromancerBoss necromancer) : base(boss, stateMachine, isBoolName, data)
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
        if (isFinishAnimation)
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
    }
}
