using UnityEngine;

public abstract class WeaponBaseState
{
    public abstract void EnterState(WeaponStateManager player);

    public abstract void UpdateState(WeaponStateManager player);

    public abstract void FixedUpdateState(WeaponStateManager player);

    public abstract void ExitState(WeaponStateManager player);
}
