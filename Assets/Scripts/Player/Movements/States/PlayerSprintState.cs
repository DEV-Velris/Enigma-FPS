using UnityEngine;

public class PlayerSprintState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("J'entre en SprintState");
    }

    public override void UpdateState(PlayerStateManager player)
    {
        if (player.IsJumping())
        {
            player.SwitchState(player.JumpState);
        }

        if (player.IsSliding() && !player.Keyboard.sKey.isPressed)
        {
            player.SwitchState(player.SlideState);
        }
    }

    public override void FixedUpdateState(PlayerStateManager player)
    {
        if (player.IsSprinting() && player.IsWalking())
        {
            player.Walk(player.playerInput.actions["Movements"].ReadValue<Vector2>(),
                !player.Keyboard.sKey.isPressed ? 8 : 5);

            if (player.IsFalling())
            {
                player.SwitchState(player.FallState);
            }
        }
        else
        {
            player.SwitchState(player.WalkState);
        }
    }

    public override void OnCollisionEnter(PlayerStateManager player, Collision collision)
    {
        
    }

    public override void ExitState(PlayerStateManager player)
    {
        
    }
}
