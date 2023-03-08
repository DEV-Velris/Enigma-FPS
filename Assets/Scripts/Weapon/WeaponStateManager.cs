using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponStateManager : MonoBehaviour
{
    
    //Component
    public PlayerInput PlayerInput;

    //States
    public WeaponIdleState IdleState = new();
    public WeaponShootState ShootState = new();
    public WeaponReloadState ReloadState = new();

    private WeaponBaseState _currentState;
    
    //Values
    private float fireRate = 10f;
    private float range = 100f;
    private int maxAmmo = 30;
    private int currentAmmo;
    private float projectileSpeed = 10f;
    public Transform firePoint;
    public GameObject projectilePrefab;
    private float nextFireTime;
    public AudioClip shotSound;
    private AudioSource AudioSource;

    private void Awake()
    {
        PlayerInput = GetComponent<PlayerInput>();
        AudioSource = GetComponent<AudioSource>();
        currentAmmo = maxAmmo;
    }

    // Start is called before the first frame update
    void Start()
    {
        _currentState = IdleState;
        _currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        _currentState.UpdateState(this);
    }

    private void FixedUpdate()
    {
        _currentState.FixedUpdateState(this);
    }

    public void SwitchState(WeaponBaseState state)
    {
        _currentState.ExitState(this);
        _currentState = state;
        state.EnterState(this);
    }

    public bool IsShooting()
    {
        return PlayerInput.actions["Shoot"].IsPressed();
    }

    public bool IsReloading()
    {
        return PlayerInput.actions["Reload"].WasPressedThisFrame();
    }

    public void Fire()
    {
        if (Time.time >= nextFireTime && currentAmmo > 0)
        {
            AudioSource.PlayOneShot(shotSound);
            nextFireTime = Time.time + 1f / fireRate;
            currentAmmo--;
            Debug.Log("Munition restante: " + currentAmmo);

            var ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, range))
            {
                Debug.Log(hit.transform.name);
            }

            var projectileObj = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            var projectile = projectileObj.GetComponent<Projectile>();
            if (projectile != null)
            {
                projectile.Initialize(transform.forward, projectileSpeed);
            }
        }
        else
        {
            Debug.Log("Je ne peut pas tiré");
        }
    }

    public void Reload()
    {
        if (currentAmmo < maxAmmo)
        {
            currentAmmo = maxAmmo;
        }
    }
    
}
