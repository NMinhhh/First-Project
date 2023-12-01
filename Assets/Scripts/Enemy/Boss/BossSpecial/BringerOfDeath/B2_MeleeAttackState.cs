using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B2_MeleeAttackState : BossMeleeAttackState
{
    private BringerOfDeath bringerOfDeath;
    public B2_MeleeAttackState(Boss boss, BossStateMachine stateMachine, string isBoolName, Transform attackPoint, BossMeleeAttackData data, BringerOfDeath bringerOfDeath) : base(boss, stateMachine, isBoolName, attackPoint, data)
    {
        this.bringerOfDeath = bringerOfDeath;
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
            stateMachine.ChangeState(bringerOfDeath.PlayerDetectedState);
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }

    public override void TriggerAnimation()
    {
        base.TriggerAnimation();
        SoundFXManager.Instance.CreateAudio(SoundFXManager.Instance.GetAudio(2), boss.transform, 1);

    }
}
