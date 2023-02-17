using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallJumpState : PlayerAbilityState
{

    private bool isTouchingWall;
    private bool isGrounded;

    public PlayerWallJumpState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
        isTouchingWall = player.CheckIfTouchingWall();
        isGrounded = player.CheckIfGrounded();
    }
    public override void Enter()
    {
        base.Enter();

        player.JumpState.ResetAmountOfJumpsLeft();
        player.SetVelocityY(0f);
        Debug.Log(player.CurrentVelocity);
        player.RB.AddForce(new Vector2(playerData.wallJumpStrength.x * -player.FacingDirection, playerData.wallJumpStrength.y), ForceMode2D.Impulse);
        Debug.Log(player.CurrentVelocity);
        player.JumpState.DecreaseAmountOfJumpsLeft();

    }


    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (Time.time >= startTime + playerData.wallJumpTime)
        {
            isAbilityDone = true;
        }

    }


}
