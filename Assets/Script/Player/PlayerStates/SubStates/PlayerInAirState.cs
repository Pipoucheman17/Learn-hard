using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInAirState : PlayerState
{

    private bool isGrounded;
    private bool isTouchingWall;
    private bool isTouchingWallBack;
    private int xInput;
    private bool jumpInput;
    private bool jumpInputStop;
    private bool coyoteTime;
    private bool isJumping;
    public PlayerInAirState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
        isGrounded = core.CollisionSenses.Ground;
        isTouchingWall = core.CollisionSenses.TouchWall;
    }

    public override void Enter()
    {
        base.Enter();

    }


    public override void Exit()
    {
        base.Exit();
    }



    public override void LogicUpdate()
    {
        base.LogicUpdate();

        CheckCoyoteTime();
        xInput = player.InputHandler.NormInputX;
        jumpInput = player.InputHandler.JumpInput;
        jumpInputStop = player.InputHandler.JumpInputStop;
        CheckJumpMultiplier();
        if (player.InputHandler.AttackInputs[(int)CombatInputs.primary])
        {
            stateMachine.ChangeState(player.PrimaryAttackState);
        }
        else if (player.InputHandler.AttackInputs[(int)CombatInputs.secondary])
        {
            stateMachine.ChangeState(player.SecondaryAttackState);
        }
        else if (isGrounded && core.Movement.CurrentVelocity.y < 0.01f)
        {
            stateMachine.ChangeState(player.LandState);
        }
        else if (jumpInput && (isTouchingWall && xInput == core.Movement.FacingDirection))
        {
            stateMachine.ChangeState(player.WallJumpState);
        }
        else if (jumpInput && player.JumpState.CanJump())
        {
            player.InputHandler.UseJumpInput();
            stateMachine.ChangeState(player.JumpState);
        }
        else if (isTouchingWall && xInput == core.Movement.FacingDirection && core.Movement.CurrentVelocity.y <= 0f)
        {
            stateMachine.ChangeState(player.WallGrabState);
        }
        else
        {

            core.Movement.CheckIfShouldFlip(xInput);
            if (core.Movement.isDashing)
            {
                core.Movement.SetVelocityX(playerData.dashSpeed * xInput);
                player.Anim.SetFloat("isDashing", 10f);
            }
            else
            {
                core.Movement.SetVelocityX(playerData.movementVelocity * xInput);
                player.Anim.SetFloat("isDashing", 0f);
            }

            player.Anim.SetFloat("yVelocity", core.Movement.CurrentVelocity.y);
        }
    }

    private void CheckJumpMultiplier()
    {
        if (isJumping)
        {
            if (jumpInputStop)
            {
                core.Movement.SetVelocityY(playerData.jumpVelocity * playerData.variableJumpHeightMultiplier);
                isJumping = false;
            }
            else if (core.Movement.CurrentVelocity.y <= 0f)
            {
                isJumping = false;
            }

        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    private void CheckCoyoteTime()
    {
        if (coyoteTime && Time.time > startTime + playerData.coyoteTime)
        {
            coyoteTime = false;
            player.JumpState.DecreaseAmountOfJumpsLeft();
        }
    }

    public void StartCoyoteTime()
    {
        coyoteTime = true;
        startTime = Time.time;
    }

    public void SetIsJumping() => isJumping = true;
}
