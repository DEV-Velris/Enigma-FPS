using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("J'entre en IdleState");
    }

    public override void UpdateState(PlayerStateManager player)
    {
        if (player.IsJumping())
        {
            player.SwitchState(player.JumpState);
        }
    }

    public override void FixedUpdateState(PlayerStateManager player)
    {

        if (player.IsFalling())
        {
            player.SwitchState(player.FallState);
        }
        
        if (player.IsWalking())
        {
            player.SwitchState(player.WalkState);
        }

        if (player.IsSneaking())
        {
            player.SwitchState(player.SneakState);
        }

        
        
    }

    public override void OnCollisionEnter(PlayerStateManager player, Collision collision)
    {
        
    }

    public override void ExitState(PlayerStateManager player)
    {
        
    }
}
