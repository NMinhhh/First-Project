using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeavyAttackState : PlayerState
{
    private SkillCooldownManager skillCooldownManager;
    private Transform attackPoint;
    private Transform attackEffectPoint;
    private GameObject GO;
    private Bolt script;
    public PlayerHeavyAttackState(Player player, StateMachine stateMachine, PlayerData playerData, string animBoolName, Transform attackPoint, Transform attackEffectPoint, SkillCooldownManager skill1) : base(player, stateMachine, playerData, animBoolName)
    {
        this.attackPoint = attackPoint;
        this.attackEffectPoint = attackEffectPoint;
        skillCooldownManager = skill1;
    }

    public override void DoCheck()
    {
        base.DoCheck();
    }

    public override void Enter()
    {
        base.Enter();
        skillCooldownManager.SkillCooldown(playerData.cooldownHeavyAttack);
        player.SetVelocityZero();
        
    }

    public override void Exit()
    {
        base.Exit();
        InputManager.Instance.UseHeavyAttackInput();
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
        if (isFinishAnimation)
        {
            stateMachine.ChangeState(player.IdleState);
        }
    }

    public override void TriggerAnimation()
    {
        base.TriggerAnimation();
        SoundFXManager.Instance.CreateAudio(playerData.audioClips[3], player.transform, 1);
        GO = GameObject.Instantiate(playerData.goEffect, attackEffectPoint.position, attackEffectPoint.rotation);
        script = GO.GetComponent<Bolt>();
        script.CreateSpells(playerData.heavyAttackDamage + player.WeaponDamage());
    }
}
