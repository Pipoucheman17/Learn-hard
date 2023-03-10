using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch_Bot_PlayerDetectedState : PlayerDetectedState
{
    private Punch_Bot punchBot;
    public Punch_Bot_PlayerDetectedState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_PlayerDetectedState stateData, Punch_Bot punchBot) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.punchBot = punchBot;
    }

    public override void DoChecks()
    {
        base.DoChecks();
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
        if (!core.CollisionSenses.TargetInMaxAgroRange)
        {
            stateMachine.ChangeState(punchBot.moveState);
        }
    }
}
