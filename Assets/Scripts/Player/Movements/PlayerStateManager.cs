using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStateManager : MonoBehaviour
{
    
    //Component
    public PlayerInput playerInput;
    public Rigidbody rigidBody;
    public Keyboard Keyboard;
    
    //States
    public PlayerIdleState IdleState = new();
    public PlayerWalkState WalkState = new();
    public PlayerSprintState SprintState = new();
    public PlayerJumpState JumpState = new();
    public PlayerSneakState SneakState = new();
    public PlayerSlideState SlideState = new();
    public PlayerFallState FallState = new();
    
    //Values
    private Vector3 movement;

    private PlayerBaseState _currentState;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        rigidBody = GetComponent<Rigidbody>();
        Keyboard = Keyboard.current;
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
        // Debug.Log(IsWalking());
    }

    private void OnCollisionEnter(Collision collision)
    {
        _currentState.OnCollisionEnter(this, collision);
    }

    public void SwitchState(PlayerBaseState state)
    {
        _currentState.ExitState(this);
        _currentState = state;
        state.EnterState(this);
    }

    public IEnumerator DelayedSwitchState(PlayerBaseState state, PlayerStateManager player, float time)
    {
        yield return new WaitForSeconds(time);
        _currentState.ExitState(this);
        _currentState = state;
        state.EnterState(this);
    }

    public bool IsFalling()
    {
        return rigidBody.velocity.y < 0 && !Physics.Raycast(transform.position, Vector3.down, 0.1f);
    }

    public bool IsSneaking()
    {
        return playerInput.actions["Sneak"].IsPressed();
    }

    public bool IsWalking()
    {
        return playerInput.actions["Movements"].IsPressed();
    }

    public bool IsJumping()
    {
        return playerInput.actions["Jump"].WasPressedThisFrame();
    }

    public bool IsSprinting()
    {
        return playerInput.actions["Sprint"].IsPressed();
    }

    public bool IsSliding()
    {
        return playerInput.actions["Slide"].WasPressedThisFrame();
    }

    public void Slide()
    {
        rigidBody.AddForce(Vector3.forward * 2, ForceMode.Impulse);
        StartCoroutine(DelayedSwitchState(IdleState, this, 1.5f));
    }

    public void Walk(Vector2 direction, float speed)
    {
        movement = new Vector3(direction.x, 0, direction.y);
        // rigidBody.AddForce(movement * speed);
        rigidBody.velocity = movement.normalized * speed;
    }
}