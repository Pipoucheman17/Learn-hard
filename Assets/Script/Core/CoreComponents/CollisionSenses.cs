using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSenses : CoreComponent
{

    #region Check Transforms

    public Transform GroundCheck { get => groundCheck; private set => groundCheck = value; }
    public Transform WallCheck { get => wallCheck; private set => wallCheck = value; }
    public Transform LedgeCheck { get => ledgeCheck; private set => ledgeCheck = value; }
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private Transform ledgeCheck;
    [SerializeField] private Transform targetCheck;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private float wallCheckDistance;
    [SerializeField] private float ledgeCheckDistance;
    [SerializeField] private float minAgroRange;
    [SerializeField] private float maxAgroRange;
    [SerializeField] private LayerMask whatIsTarget;
    [SerializeField] private LayerMask whatIsGround;

    #endregion



    #region Check Functions

    public bool Ground
    {
        get => Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    public bool TouchWall
    {
        get => Physics2D.Raycast(wallCheck.position, Vector2.right * core.Movement.FacingDirection, wallCheckDistance, whatIsGround);
    }

    public bool Ledge
    {
        get => Physics2D.Raycast(ledgeCheck.position, Vector2.down, ledgeCheckDistance, whatIsGround);
    }

    public bool TargetInMinAgroRange
    {
        get => Physics2D.Raycast(targetCheck.position, Vector2.right * core.Movement.FacingDirection, minAgroRange, whatIsTarget);
    }

    public bool TargetInMaxAgroRange
    {
        get => Physics2D.Raycast(targetCheck.position, Vector2.right * core.Movement.FacingDirection, maxAgroRange, whatIsTarget);
    }

    public virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(ledgeCheck.position, ledgeCheck.position + (Vector3)(Vector2.down * ledgeCheckDistance));
        Gizmos.DrawLine(targetCheck.position, targetCheck.position + (Vector3)(Vector2.right * minAgroRange));
        Gizmos.DrawLine(targetCheck.position, targetCheck.position + (Vector3)(Vector2.right * maxAgroRange));
    }
    #endregion
}
