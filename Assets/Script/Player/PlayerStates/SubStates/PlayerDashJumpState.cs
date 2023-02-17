using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashJumpState : PlayerJumpState
{
    public PlayerDashJumpState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.SetVelocityX(playerData.dashSpeed * player.FacingDirection);
    }


}
