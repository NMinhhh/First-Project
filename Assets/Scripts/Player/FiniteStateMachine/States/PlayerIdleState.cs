using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerState
{
    private float xInput;
    private bool jumpInput;
    private bool isGrounded;
    private bool attackInput;
    private bool dashInput;
    private bool heavyAttackInput;
    private bool waterBlastSkillInput;
    private bool windSkillInput;
    public PlayerIdleState(Player player, StateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoCheck()
    {
        base.DoCheck();
        isGrounded = player.CheckGrounded();
    }

    public override void Enter()
    {
        base.Enter();
        player.SetVelocityZero();
        player.SetAmountOfJump();
        player.SetAmountOfJumpAttack();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        xInput = InputManager.Instance.xInput;
        jumpInput = InputManager.Instance.jumpInput;
        attackInput = InputManager.Instance.attackInput;
        dashInput = InputManager.Instance.dashInput;
        heavyAttackInput = InputManager.Instance.heavyAttackInput;
        waterBlastSkillInput = InputManager.Instance.waterBlastSkillInput;
        windSkillInput = InputManager.Instance.windSkillInput;
        player.CheckIfFlip(xInput);
        if (isGrounded && xInput != 0)
        {
                stateMachine.ChangeState(player.MoveState);
            
        }else if (isGrounded && jumpInput)
        {
            stateMachine.ChangeState(player.JumpState);
        }
        else if (isGrounded && attackInput)
        {
            stateMachine.ChangeState(player.AttackState);
        }
        else if(!isGrounded && player.CurrentVelocity.y < 0.01) 
        { 
            stateMachine.ChangeState(player.InAirState);
        }else if (dashInput)
        {
            stateMachine.ChangeState(player.DashState);
        }else if (heavyAttackInput)
        {
            stateMachine.ChangeState(player.HeavyAttackState);
        }else if (waterBlastSkillInput)
        {
            stateMachine.ChangeState(player.WaterBlastSkillState);
        }else if (windSkillInput)
        {
            stateMachine.ChangeState(player.WindSkillState);
        }
       

    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }

    
}
