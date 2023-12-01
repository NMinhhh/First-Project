using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerState
{
    private SkillCooldownManager skillCooldownManager;
    private bool isGround;
    public PlayerDashState(Player player, StateMachine stateMachine, PlayerData playerData, string animBoolName,SkillCooldownManager skillCooldownManager) : base(player, stateMachine, playerData, animBoolName)
    {
        this.skillCooldownManager = skillCooldownManager;
    }

    public override void DoCheck()
    {
        base.DoCheck();
        isGround = player.CheckGrounded();
    }

    public override void Enter()
    {
        base.Enter();
        player.SetGravityScale(0);
        player.IsDashing();
        skillCooldownManager.SkillCooldown(playerData.cooldownDash);
        player.Dash(playerData.dashTime,playerData.dashSpeed);
        SoundFXManager.Instance.CreateAudio(playerData.audioClips[6], player.transform, 1);
    }

    public override void Exit()
    {
        base.Exit();
        InputManager.Instance.UseDashInput();
        player.SetGravityScale(player.currentGravity);
    }

    public override void FinishAnimation()
    {
        base.FinishAnimation();
        player.Anim.SetBool("endDash", false);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(!player.isDashing && !isFinishAnimation)
        {
            player.SetVelocityZero();
            player.Anim.SetBool("endDash", true);
        }else if (isFinishAnimation)
        {
            if (isGround)
            {
                stateMachine.ChangeState(player.IdleState);
            }
            else
            {
                stateMachine.ChangeState(player.InAirState);
            }
            
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
