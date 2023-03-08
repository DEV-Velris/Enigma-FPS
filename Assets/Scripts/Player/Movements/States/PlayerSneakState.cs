using UnityEngine;

public class PlayerSneakState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("J'entre en SneakState");
        var transform = player.transform;
        var pos = transform.localPosition;
        var scale = transform.localScale;
        transform.localPosition = new Vector3(pos.x, pos.y - 0.5f, pos.z);
        transform.localScale = new Vector3(scale.x, -0.5f, scale.z);
    }

    public override void UpdateState(PlayerStateManager player)
    {
        
    }

    public override void FixedUpdateState(PlayerStateManager player)
    {
        if (player.IsSneaking())
        {

            if (player.IsFalling())
            {
                player.SwitchState(player.FallState);
            }
            
            if (player.IsWalking())
            {
                //SwitchState to PlayerWalkSneakState
            }
        }
        else
        {
            if (player.IsWalking())
            {
                player.SwitchState(player.WalkState);
            }
            else
            {
                player.SwitchState(player.IdleState);
            }
        }
    }

    public override void OnCollisionEnter(PlayerStateManager player, Collision collision)
    {
        
    }

    public override void ExitState(PlayerStateManager player)
    {
        // player.transform.localScale = new Vector3(1, 1, 1);
        var transform = player.transform;
        var pos = transform.localPosition;
        var scale = transform.localScale;
        transform.localPosition = new Vector3(pos.x, pos.y + 0.5f, pos.z);
        transform.localScale = new Vector3(scale.x, 1f, scale.z);
    }
}
