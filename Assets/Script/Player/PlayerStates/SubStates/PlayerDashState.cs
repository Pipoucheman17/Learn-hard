using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerAbilityState
{
    private int animeState;
    private bool isGrounded;
    private bool isTouchingWall;
    private bool isDashing;
    private bool DashInputStop;
    private int xInput;
    private bool jumpInput;
    public PlayerDashState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {

    }

    public override void DoChecks()
    {
        base.DoChecks();
        isGrounded = player.CheckIfGrounded();
        isTouchingWall = player.CheckIfTouchingWall();
        DashInputStop = player.InputHandler.DashInputStop;
    }

    public override void Enter()
    {
        base.Enter();
        animeState = 0;

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        xInput = player.InputHandler.NormInputX;
        jumpInput = player.InputHandler.JumpInput;
        player.CheckIfShouldFlip(xInput);
        player.SetVelocityX(playerData.dashSpeed * player.FacingDirection);
        player.Anim.SetFloat("dashState", animeState);
        if (DashInputStop)
        {
            isAbilityDone = true;
        }
        else if (jumpInput && player.DashJumpState.CanJump())
        {
            player.InputHandler.UseJumpInput();
            stateMachine.ChangeState(player.DashJumpState);
        }
        else if (Time.time >= startTime + playerData.dashTime)
        {
            isAbilityDone = true;
        }
        if (isAnimationFinished)
        {
            animeState = 1;
        }

    }

    public bool CanDash()
    {
        if (isGrounded || isTouchingWall)
        {
            Debug.Log("Check");
            return true;
        }
        else
        {
            return false;
        }
    }


}
