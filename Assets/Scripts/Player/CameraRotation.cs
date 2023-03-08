using UnityEngine;
using UnityEngine.InputSystem;

public class CameraRotation : MonoBehaviour
{
    public GameObject player;
    public GameObject weapon;
    private Vector2 _mousemovement;
    private float _xRotation, _yRotation;
    private const float MouseSensitivity = 40;

    // Start is called before the first frame update
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    private void Update()
    {
        // var pos = player.transform.position;
        // transform.position = pos;
        
        _mousemovement = Mouse.current.delta.ReadValue();
        
        var rotationSpeed = Time.deltaTime * MouseSensitivity;
        _xRotation -= Mathf.Sign(_mousemovement.y) * rotationSpeed * Mathf.Abs(_mousemovement.y);
        _xRotation = Mathf.Clamp(_xRotation, -90, 90);
        _yRotation += _mousemovement.x * rotationSpeed;
        
        transform.rotation = Quaternion.Euler(_xRotation, _yRotation, 0);
        weapon.transform.rotation = Quaternion.Euler(_xRotation, _yRotation, 0);
        player.transform.rotation = Quaternion.Euler(0, _yRotation, 0);
    }
}
