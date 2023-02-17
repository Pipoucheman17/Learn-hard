using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    protected int xInput;
    private bool DashInput;
    private bool DashInputStop;
    private bool JumpInput;
    private bool isGrounded;
    private bool isDashing;
    public PlayerGroundedState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();

        isGrounded = player.CheckIfGrounded();
    }

    public override void Enter()
    {
        base.Enter();
        player.JumpState.ResetAmountOfJumpsLeft();
    }


    public override void Exit()
    {
        base.Exit();
    }


    public override void LogicUpdate()
    {
        base.LogicUpdate();
        xInput = player.InputHandler.NormInputX;
        JumpInput = player.InputHandler.JumpInput;
        DashInput = player.InputHandler.DashInput;
        Debug.Log(DashInput);
        DashInputStop = player.InputHandler.DashInputStop;
        if (JumpInput && player.JumpState.CanJump())
        {
            player.InputHandler.UseJumpInput();
            stateMachine.ChangeState(player.JumpState);
        }
        else if (DashInput && !DashInputStop)
        {
            Debug.Log("Dash START");
            player.InputHandler.UseDashInput();
            stateMachine.ChangeState(player.DashState);

        }
        else if (!isGrounded)
        {
            player.InAirState.StartCoyoteTime();
            stateMachine.ChangeState(player.InAirState);
        }

    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    private void CheckDashDuration()
    {
        if (isDashing)
        {
            if (DashInputStop)
            {
                isDashing = false;
            }
        }
    }

    public bool SetIsDashing() => isDashing = true;
}
