using UnityEngine;

public class Projectile : MonoBehaviour
{

    private Vector3 _direction;
    private float _speed;

    public void Initialize(Vector3 direction, float speed)
    {
        _direction = direction;
        _speed = speed;
        
        transform.rotation *= Quaternion.Euler(90, 0, 0);
    }

    // Update is called once per frame
   private void Update()
   {
       transform.position += _direction * _speed * Time.deltaTime;
   }

   private void OnCollisionEnter(Collision collision)
   {
       if (collision.gameObject.CompareTag("Ground"))
       {
           Debug.Log("J'ai touché le sol");
       }
       
       Destroy(gameObject);
   }
}
