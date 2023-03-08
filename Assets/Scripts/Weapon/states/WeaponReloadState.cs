using UnityEngine;

public class WeaponReloadState : WeaponBaseState
{
    public override void EnterState(WeaponStateManager weapon)
    {
        Debug.Log("J'entre en mod de tir Reload");
        weapon.Reload();
        weapon.SwitchState(weapon.IdleState);
    }

    public override void UpdateState(WeaponStateManager weapon)
    {
    }

    public override void FixedUpdateState(WeaponStateManager weapon)
    {
    }

    public override void ExitState(WeaponStateManager weapon)
    {
    }
}
