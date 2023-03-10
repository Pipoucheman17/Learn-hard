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
        isGrounded = core.CollisionSenses.Ground;
        isTouchingWall = core.CollisionSenses.TouchWall;
        DashInputStop = player.InputHandler.DashInputStop;
    }

    public override void Enter()
    {
        base.Enter();
        core.Movement.SetIsDashing(true);
        animeState = 0;

    }


    public override void LogicUpdate()
    {
        base.LogicUpdate();

        xInput = player.InputHandler.NormInputX;
        jumpInput = player.InputHandler.JumpInput;
        core.Movement.CheckIfShouldFlip(xInput);
        core.Movement.SetVelocityX(playerData.dashSpeed * xInput);
        player.Anim.SetFloat("dashState", animeState);
        if (!isExitingState)
        {
            if (DashInputStop)
            {
                core.Movement.SetIsDashing(false);
                isAbilityDone = true;
            }
            else if (jumpInput && player.JumpState.CanJump())
            {
                player.InputHandler.UseJumpInput();
                stateMachine.ChangeState(player.JumpState);
            }
            else if (Time.time >= startTime + playerData.dashTime)
            {
                core.Movement.SetIsDashing(false);
                isAbilityDone = true;
            }
            if (isAnimationFinished)
            {
                animeState = 1;
            }
        }

    }

    public bool CanDash()
    {
        if (isGrounded || isTouchingWall)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

   

}
