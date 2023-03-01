using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStateManager : MonoBehaviour
{
    
    //Component
    public PlayerInput playerInput;
    public CharacterController characterController;
    
    //States
    public PlayerIdleState IdleState = new();
    public PlayerWalkState WalkState = new();
    public PlayerSprintState SprintState = new();
    public PlayerJumpState JumpState = new();
    public PlayerSneakState SneakState = new();
    public PlayerSlideState SlideState = new();

    private PlayerBaseState _currentState;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        characterController = GetComponent<CharacterController>();
    }


    private void Start()
    {
        _currentState = IdleState;
        _currentState.EnterState(this);
    }

    private void Update()
    {
        _currentState.UpdateState(this);
    }

    private void FixedUpdate()
    {
        _currentState.FixedUpdateState(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        _currentState.OnCollisionEnter(this, collision);
    }

    public void SwitchState(PlayerBaseState state)
    {
        _currentState = state;
        state.EnterState(this);
    }
}