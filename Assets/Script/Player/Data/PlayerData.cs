using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player Data/Base Data")]

public class PlayerData : ScriptableObject
{
    [Header("Move State")]
    public float movementVelocity = 10f;

    [Header("Jump State")]
    public float jumpVelocity = 15f;
    public int amountOfJumps = 1;
    [Header("Wall Jump State")]
    public Vector2 wallJumpStrength = new Vector2(0.05f, 1f);
    public float wallJumpVelocity = 5f;
    public float wallJumpTime = 0.2f;
    public Vector2 wallJumpAngle = new Vector2(0.05f, 1f);

    [Header("Dash State")]
    public float dashTime = 1f;
    public float dashSpeed = 10f;
    public float distBetweenAfterImages = 0.5f;
    public float drag = 10f;

    [Header("In Air State")]
    public float coyoteTime = 0.2f;
    public float variableJumpHeightMultiplier = 0.5f;

    [Header("Wall Slide State")]
    public float wallSlideVelocity = 3f;
    public float wallClimbVelocity = 10f;


}
