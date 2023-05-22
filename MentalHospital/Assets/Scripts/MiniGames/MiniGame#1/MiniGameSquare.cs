using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using UnityEngine.SceneManagement;

public class MiniGameSquare : MonoBehaviour
{
    [SerializeField] private Animator fader;

    [SerializeField] private Animator introversionCharacteristic;
    [SerializeField] private Animator extraversionCharacteristic;
    [SerializeField] private Animator blackBack;
    
    private bool _isTouchingDot;
    private bool _isTouchingWall;
    
    //square moving
    private Rigidbody2D _rb;
    private readonly float _speed = 1f;
    
    //dots
    public Rigidbody2D[] dots;
    
    //text
    public TextMeshProUGUI introversionCounter;
    public TextMeshProUGUI extraversionCounter;
    
    //interact
    public GameObject miniGameBorder;

    private List<Rigidbody2D> pushedDot = new List<Rigidbody2D>();
    private List<Rigidbody2D> pulledDot = new List<Rigidbody2D>();
    

    private void Start()
    {
        PlayerPrefs.SetInt("DayCounter", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.Save();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        for (int i = 0; i < dots.Length; i++)
        {
            pushedDot = dots.Where(d => d.IsTouching(
                collider: miniGameBorder.GetComponentInChildren<PolygonCollider2D>()
            )).ToList();
            pushedDot.ForEach(d =>
            {
                if(d.velocity == new Vector2(0,0))
                    d.GetComponent<CircleCollider2D>().isTrigger = true;
            });
            introversionCounter.text = pushedDot.Count + "/10";
            
            pulledDot = dots.Where(d => d.IsTouching(
                collider: _rb.transform.GetChild(1).GetComponent<CircleCollider2D>()
            )).ToList();
            pulledDot.ForEach(d =>
            {
                if(d.velocity == new Vector2(0,0))
                    d.GetComponent<CircleCollider2D>().isTrigger = true;
            });
            extraversionCounter.text = pulledDot.Count + "/10";
        }
        
        if (introversionCounter.text == "10/10" || extraversionCounter.text == "10/10")
            StartCoroutine(CloseMiniGame());
    }

    private void FixedUpdate()
    {
        var horizontal = Input.GetAxis("Horizontal") * _speed;
        var vertical = Input.GetAxis("Vertical") * _speed;

        _rb.velocity = new Vector2(horizontal, vertical);

        if (_isTouchingDot)
        {
            if (Input.GetMouseButton(1))
            {
                Push();
            }
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
            {
                Pull();
            }
        }
    }

    void Push()
    {
        for (int i = 0; i < dots.Length; i++)
        {
            var pushedDot = dots.Where(d => d.IsTouching(
                collider: _rb.GetComponentInChildren<CircleCollider2D>()
            )).ToList();
            pushedDot.ForEach(d =>
            {
                d.AddForce((d.position - (Vector2)gameObject.transform.position).normalized * 0.5f);
                RaycastHit2D raycastHit2D = Physics2D.Raycast(d.position,
                    d.velocity);
                if (raycastHit2D.collider != null)
                {
                    d.GetComponent<CircleCollider2D>().isTrigger = false;
                }
            });
        }
    }

    void Pull()
    {
        for (int i = 0; i < dots.Length; i++)
        {
            var pulledDot = dots.Where(d => d.IsTouching(
                collider: _rb.GetComponentInChildren<CircleCollider2D>()
            )).ToList();
            pulledDot.ForEach(d =>
            {
                d.AddForce(((Vector2)gameObject.transform.position - d.position).normalized * 2f);
                RaycastHit2D raycastHit2D = Physics2D.Raycast(d.position,
                    d.velocity);
                if (raycastHit2D.collider != null)
                {
                    d.GetComponent<CircleCollider2D>().isTrigger = false;
                }
            });
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Dot"))
            _isTouchingDot = true;
    }

    private IEnumerator CloseMiniGame()
    {
        yield return new WaitForSeconds(1f);
        if (introversionCounter.text == "10/10" || extraversionCounter.text == "10/10")
        {
            _rb.bodyType = RigidbodyType2D.Static;
            blackBack.enabled = true;
            if (extraversionCounter.text == "10/10")
            {
                Behaviour.extravert = true;
                extraversionCharacteristic.enabled = true;
            }
            else
            {
                introversionCharacteristic.enabled = true;
            }
            yield return new WaitForSeconds(2f);
            
            fader.SetBool("fader_in", true);
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene(PlayerPrefs.GetInt("DayCounter") + 1);
        }
        else
            StopCoroutine(CloseMiniGame());
    }
}
