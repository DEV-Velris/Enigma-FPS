using UnityEngine;

public class WeaponIdleState : WeaponBaseState
{
    public override void EnterState(WeaponStateManager weapon)
    {
        Debug.Log("J'entre en mod de tir Idle");
    }

    public override void UpdateState(WeaponStateManager weapon)
    {
        if (weapon.IsReloading())
        {
            weapon.SwitchState(weapon.ReloadState);
        }
    }

    public override void FixedUpdateState(WeaponStateManager weapon)
    {
        if (weapon.IsShooting())
        {
            weapon.SwitchState(weapon.ShootState);
        }

    }

    public override void ExitState(WeaponStateManager weapon)
    {
        
    }
}
