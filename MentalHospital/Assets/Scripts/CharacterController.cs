using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour
{
    private static CharacterController instance;
    private Rigidbody2D _rb;
    public Rigidbody2D rb => _rb;
    private Animator _animator;

    public Animator animator => _animator;
    private bool _isTouchingWall;
    public bool isTouchingWall => _isTouchingWall;

    private readonly float _speed = 4.5f;
    private float _horizontal;
    private float _vertical;

    private bool _isFacingRight;
    private bool _isSitting;

    private Vector2 _sitPosition;
    private bool _isListening;
    private bool _isAtWork;

    void Start()
    {
        DialogManager.GetInstance().EnterDialogueMode(gameObject.GetComponent<DialogTrigger>().inkJSON, gameObject);

        PlayerPrefs.SetInt("DayCounter", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.Save();
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

    private void FixedUpdate()
    {
        if (DialogManager.GetInstance().dialogueIsPlaying && !_isListening)
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
            {
                _animator.SetBool("isWalk", true);
                _animator.SetBool("isSitting", false);
            }
            else
                _animator.SetBool("isWalk", false);
        }
    }

    private void Update()
    {
        if (_isSitting && Input.GetKeyDown(KeyCode.E) && !_animator.GetBool("isSitting"))
        {
            _animator.SetBool("isSitting", true);
            _rb.transform.position = _sitPosition;
        }

        if (_isAtWork && DialogManager.GetInstance().dialogueIsPlaying)
        {
            _animator.Play("Character_at_Work");
            _rb.transform.position = _sitPosition;
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
        if (col.transform.GetComponentInChildren<Canvas>() != null)
        {
            col.transform.GetComponentInChildren<Canvas>().enabled = true;
        }
        
        if (col.transform.CompareTag("Wall"))
        {
            _isTouchingWall = true;
        }

        if (col.transform.CompareTag("BorderSwitch"))
        {
            col.transform.GetComponent<BoxCollider2D>().enabled = true;
        }

        if (col.transform.CompareTag("Girl"))
        {
            DialogManager.GetInstance().EnterDialogueMode(col.gameObject.GetComponent<DialogTrigger>().inkJSON, col.gameObject);
        }
        
        if (col.transform.CompareTag("Mom"))
        {
            DialogManager.GetInstance().EnterDialogueMode(col.gameObject.GetComponent<DialogTrigger>().inkJSON, col.gameObject);
        }
        if (col.transform.CompareTag("Colleague"))
        {
            DialogManager.GetInstance().EnterDialogueMode(col.gameObject.GetComponent<DialogTrigger>().inkJSON, col.gameObject);
            _isListening = true;
            
        }

        if (col.CompareTag("Psychoterapeut"))
        {
            DialogManager.GetInstance().EnterDialogueMode(col.gameObject.GetComponent<DialogTrigger>().inkJSON, col.gameObject);
        }
        if (col.CompareTag("Yard"))
        {
            DialogManager.GetInstance().EnterDialogueMode(col.gameObject.GetComponent<DialogTrigger>().inkJSON, col.gameObject);
        }

        if (col.transform.CompareTag("Sit"))
        {
            _isSitting = true;
            _sitPosition = col.transform.GetChild(0).GetComponent<Transform>().position;
        }
        if (col.transform.CompareTag("Work"))
        {
            _isAtWork = true;
            _sitPosition = col.transform.GetChild(0).GetComponent<Transform>().position;
        }

        
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.transform.CompareTag("Colleague"))
        {
            _isListening = false;
        }
        if (col.transform.GetComponentInChildren<Canvas>() != null)
        {
            col.transform.GetComponentInChildren<Canvas>().enabled = false;
        }
        if (col.transform.CompareTag("Wall"))
            _isTouchingWall = false;
        if (col.transform.CompareTag("Sit"))
        {
            _isSitting = false;
        }
    }
}
