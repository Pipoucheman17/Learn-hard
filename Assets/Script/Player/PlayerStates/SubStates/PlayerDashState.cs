using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerAbilityState
{

    public PlayerDashState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {

    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        player.SetVelocityX(playerData.dashSpeed * player.FacingDirection);
        if(Time.time >= startTime + playerData.dashTime)
        {
            isAbilityDone = true;
        }
        
    }


}
