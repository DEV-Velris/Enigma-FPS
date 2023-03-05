using UnityEngine;

public class PlayerFallState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("J'entre en FallState");
    }

    public override void UpdateState(PlayerStateManager player)
    {
        
    }

    public override void FixedUpdateState(PlayerStateManager player)
    {
        
    }

    public override void OnCollisionEnter(PlayerStateManager player, Collision collision)
    {
        if (!collision.gameObject.CompareTag("Ground"))
        {
            return;
        }

        if (player.IsWalking())
        {
            player.SwitchState(player.WalkState);
        }
        else
        {
            player.SwitchState(player.IdleState);
        }
        
    }

    public override void ExitState(PlayerStateManager player)
    {
        
    }
}
