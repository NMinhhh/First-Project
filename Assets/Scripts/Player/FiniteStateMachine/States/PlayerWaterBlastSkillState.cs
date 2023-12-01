using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWaterBlastSkillState : PlayerState
{
    private SkillCooldownManager skillCooldownManager;
    private Transform attackEffectPoint;
    private GameObject Go;
    private WaterBlast script;
    public PlayerWaterBlastSkillState(Player player, StateMachine stateMachine, PlayerData playerData, string animBoolName, Transform attackEffectPoint, SkillCooldownManager skillCooldownManager) : base(player, stateMachine, playerData, animBoolName)
    {
        this.attackEffectPoint = attackEffectPoint;
        this.skillCooldownManager = skillCooldownManager;
    }

    public override void DoCheck()
    {
        base.DoCheck();
    }

    public override void Enter()
    {
        base.Enter();
        skillCooldownManager.SkillCooldown(playerData.cooldownWaterBlast);
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
            stateMachine.ChangeState(player.IdleState);
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }

    public override void TriggerAnimation()
    {
        base.TriggerAnimation();
        SoundFXManager.Instance.CreateAudio(playerData.audioClips[4], attackEffectPoint, 1);
        CreateWater(0);
        CreateWater(180);
    }

    private void CreateWater(float roY)
    {
        Go = GameObject.Instantiate(playerData.waterGo, attackEffectPoint.position, Quaternion.Euler(0,roY,0));
        script = Go.GetComponent<WaterBlast>();
        script.Create(playerData.waterBlastSpeed, playerData.waterBlastdamage + player.WeaponDamage(), playerData.waterBlastOverTimeLife);

    }
}
