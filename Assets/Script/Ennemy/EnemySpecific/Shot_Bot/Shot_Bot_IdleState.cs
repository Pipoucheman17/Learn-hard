using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot_Bot_IdleState : IdleState
{
    private Shot_Bot shotBot;
    public Shot_Bot_IdleState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_IdleState stateData, Shot_Bot shotBot) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.shotBot = shotBot;
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
        if (core.CollisionSenses.TargetInMinAgroRange)
        {
            stateMachine.ChangeState(shotBot.playerDetectedState);
        }
        else if (isIdleTimeOver)
        {
            stateMachine.ChangeState(shotBot.moveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
