using UnityEngine;

public class WeaponShootState : WeaponBaseState
{
    public override void EnterState(WeaponStateManager weapon)
    {
        Debug.Log("J'entre en mod de tir Shoot");
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
            weapon.Fire();
        }
        else
        {
            weapon.SwitchState(weapon.IdleState);
        }
    }

    public override void ExitState(WeaponStateManager weapon)
    {
    }
}
