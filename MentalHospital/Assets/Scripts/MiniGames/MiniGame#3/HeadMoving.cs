using UnityEngine;

public class HeadMoving : MonoBehaviour
{
    [SerializeField] private Transform headSpawnPosition;
    private float _speed = 5f;
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if(_rb.velocity.x > -0.3f)
            _rb.AddForce(Vector2.left * _speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wall"))
        {
            _rb.position = headSpawnPosition.position;
        }
    }
}
