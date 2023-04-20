using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _speed = 100f;
    [SerializeField] private Sprite[] headsEmotions;

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
            if (gameObject.name == "SmileBullet(Clone)")
                other.GetComponent<SpriteRenderer>().sprite = headsEmotions[0];
            else
                other.GetComponent<SpriteRenderer>().sprite = headsEmotions[1];
            Destroy(gameObject);
        }
    }
}
