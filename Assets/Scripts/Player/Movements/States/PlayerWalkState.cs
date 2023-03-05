using UnityEngine;

public class PlayerWalkState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("J'entre en WalkState");
    }

    public override void UpdateState(PlayerStateManager player)
    {
        if (!player.IsWalking()) return;
        if (player.IsJumping())
        {
            player.SwitchState(player.JumpState);
        }
    }

    public override void FixedUpdateState(PlayerStateManager player)
    {
        if (player.IsWalking())
        {
            player.Walk(player.playerInput.actions["Movements"].ReadValue<Vector2>(), 5);

            if (player.IsFalling())
            {
                player.SwitchState(player.FallState);
            } else if (player.IsSneaking())
            {
                //TODO Ajouter Sneaking
                // player.SwitchState(player.SneakState);
            } else if (player.IsSprinting())
            {
                player.SwitchState(player.SprintState);
            }
        }
        else
        {
            player.rigidBody.velocity = new Vector2(0, player.rigidBody.velocity.y);
            player.SwitchState(player.IdleState);
        }
    }

    public override void OnCollisionEnter(PlayerStateManager player, Collision collision)
    {
        
    }

    public override void ExitState(PlayerStateManager player)
    {
        
    }
}
