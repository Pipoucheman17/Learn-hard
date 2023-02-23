using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region State Variables
    public PlayerStateMachine StateMachine { get; private set; }

    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }

    public PlayerJumpState JumpState { get; private set; }
    public PlayerDashState DashState { get; private set; }
    public PlayerWallDashState WallDashState { get; private set; }
    public PlayerInAirState InAirState { get; private set; }

    public PlayerLandState LandState { get; private set; }
    public PlayerWallJumpState WallJumpState { get; private set; }
    public PlayerWallSlideState WallSlideState { get; private set; }

    public PlayerWallGrabState WallGrabState { get; private set; }

    public PlayerAttackState PrimaryAttackState { get; private set; }
    public PlayerAttackState SecondaryAttackState { get; private set; }
    [SerializeField]
    private PlayerData playerData;

    #endregion

    #region Components

    public Core Core { get; private set; }
    public Animator Anim { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }
    public Rigidbody2D RB { get; private set; }
    public Vector2 lastAIPos { get; private set; }
    public PlayerInventory Inventory { get; private set; }
    #endregion

    #region Others Variables


    private Vector2 workspace;

    #endregion

    #region Unity Callback Functions
    private void Awake()
    {
        Core = GetComponentInChildren<Core>();
        StateMachine = new PlayerStateMachine();

        IdleState = new PlayerIdleState(this, StateMachine, playerData, "idle");
        MoveState = new PlayerMoveState(this, StateMachine, playerData, "move");
        JumpState = new PlayerJumpState(this, StateMachine, playerData, "jump");
        InAirState = new PlayerInAirState(this, StateMachine, playerData, "inAir");
        LandState = new PlayerLandState(this, StateMachine, playerData, "land");
        WallJumpState = new PlayerWallJumpState(this, StateMachine, playerData, "wallJump");
        WallSlideState = new PlayerWallSlideState(this, StateMachine, playerData, "wallSlide");
        WallGrabState = new PlayerWallGrabState(this, StateMachine, playerData, "wallGrab");
        DashState = new PlayerDashState(this, StateMachine, playerData, "dash");
        WallDashState = new PlayerWallDashState(this, StateMachine, playerData, "wallDash");
        PrimaryAttackState = new PlayerAttackState(this, StateMachine, playerData, "attack");
        SecondaryAttackState = new PlayerAttackState(this, StateMachine, playerData, "attack");
    }

    private void Start()
    {

        Anim = GetComponent<Animator>();
        InputHandler = GetComponent<PlayerInputHandler>();
        RB = GetComponent<Rigidbody2D>();
        Inventory = GetComponent<PlayerInventory>();

        PrimaryAttackState.SetWeapon(Inventory.weapons[(int)CombatInputs.primary]);
        //SecondaryAttackState.SetWeapon(Inventory.weapons[(int)CombatInputs.secondary]);
        StateMachine.Initialize(IdleState);
    }


    private void Update()
    {
        Core.LogicUpdate();
        StateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }
    #endregion

    #region Others Functions

    private void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();

    private void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();

    private void AnimationStartTrigger () => StateMachine.CurrentState.AnimationStartTrigger();

    private void AnimationFrameCounter(int frame) => StateMachine.CurrentState.AnimationFrameCounter(frame);

    private void AnimationFrameSet(float frame) => StateMachine.CurrentState.AnimationFrameSet(frame);



    public void PlaceAfterImage()
    {
        PlayerAfterImagePool.Instance.GetFromPool();
        lastAIPos = this.transform.position;
    }
    public void CheckIfShouldPlaceAfterImage()
    {
        if (Vector2.Distance(transform.position, lastAIPos) > playerData.distBetweenAfterImages)
        {
            PlaceAfterImage();
        }
    }
    #endregion
}
