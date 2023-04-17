using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _speed = 50f;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rb.AddForce(Vector2.down * _speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }

        if (other.CompareTag("Head"))
        {
            other.GetComponent<SpriteRenderer>().color = gameObject.GetComponent<SpriteRenderer>().color;
            Destroy(gameObject);
        }
    }
}
