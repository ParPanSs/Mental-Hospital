using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private static CharacterController instance;
    private Rigidbody2D _rb;
    public Rigidbody2D rb => _rb;
    private Animator _animator;

    private bool _isTouchingWall;
    public bool isTouchingWall => _isTouchingWall;

    private readonly float _speed = 4.5f;
    private float _horizontal;
    private float _vertical;

    private bool _isFacingRight;
    
    public bool extraversion;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }
    
    private void Awake()
    {
        instance = this;
    }

    public static CharacterController GetInstance()
    {
        return instance;
    }

    void FixedUpdate()
    {
        if (DialogManager.GetInstance().dialogueIsPlaying || rb.bodyType == RigidbodyType2D.Static)
        {
            _animator.SetBool("isWalk", false);
            _rb.velocity = new Vector2(0, 0);
            return;
        }
        if (rb.bodyType != RigidbodyType2D.Static)
        {
            _horizontal = Input.GetAxis("Horizontal") * _speed;
            _vertical = Input.GetAxis("Vertical") * _speed;

            Flip();
            _rb.velocity = new Vector2(_horizontal, _vertical);
            if (_horizontal != 0 || _vertical != 0)
                _animator.SetBool("isWalk", true);
            else
                _animator.SetBool("isWalk", false);
        }
    }

    private void Flip()
    {
        if (_isFacingRight && _horizontal < 0 || !_isFacingRight && _horizontal > 0)
        {
            Vector3 localScale = transform.localScale;
            _isFacingRight = !_isFacingRight;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.CompareTag("Wall"))
            _isTouchingWall = true;
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.transform.CompareTag("Wall"))
            _isTouchingWall = false;
    }
}
