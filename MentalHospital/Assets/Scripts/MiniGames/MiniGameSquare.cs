using System;
using System.Collections;
using UnityEngine;
using System.Linq;
using TMPro;
using UnityEngine.SceneManagement;

public class MiniGameSquare : MonoBehaviour
{
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
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        for (int i = 0; i < dots.Length; i++)
        {
            var pushedDot = dots.Where(d => d.IsTouching(
                collider: miniGameBorder.GetComponent<PolygonCollider2D>()
            )).ToList();
            pushedDot.ForEach(d => d.GetComponent<CircleCollider2D>().isTrigger = false);
            introversionCounter.text = pushedDot.Count + "/10";
            
            var pulledDot = dots.Where(d => d.IsTouching(
                collider: _rb.transform.GetChild(1).GetComponent<CircleCollider2D>()
            )).ToList();
            //pulledDot.ForEach(d => d.GetComponent<CircleCollider2D>().isTrigger = false);
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
            if (Input.GetMouseButton(0))
            {
                for (int i = 0; i < dots.Length; i++)
                {
                    var touchedDot = dots.Where(d => d.IsTouching(
                        collider: _rb.GetComponentInChildren<CircleCollider2D>()
                    )).ToList();
                    touchedDot.ForEach(d => d.GetComponent<CircleCollider2D>().isTrigger = false);
                    touchedDot.ForEach(d => 
                        d.AddForce((d.position - (Vector2)gameObject.transform.position).normalized * 0.5f));
                }
            }
            else
            {
                for (int i = 0; i < dots.Length; i++)
                {
                    var touchedDot = dots.Where(d => d.IsTouching(
                        collider: _rb.GetComponentInChildren<CircleCollider2D>()
                    )).ToList();
                    touchedDot.ForEach(d =>
                    {
                        var isTrigger = d.IsTouching(miniGameBorder.GetComponent<PolygonCollider2D>());
                        if (isTrigger)
                            d.GetComponent<CircleCollider2D>().isTrigger = false;
                        else
                            d.GetComponent<CircleCollider2D>().isTrigger = true;

                    });
                }
            }

            if (Input.GetMouseButton(1))
            {
                for (int i = 0; i < dots.Length; i++)
                {
                    var touchedDot = dots.Where(d => d.IsTouching(
                        collider: _rb.GetComponentInChildren<CircleCollider2D>()
                    )).ToList();
                    touchedDot.ForEach(d => d.GetComponent<CircleCollider2D>().isTrigger = false);
                    touchedDot.ForEach(d => 
                        d.AddForce(((Vector2)gameObject.transform.position - d.position).normalized * 2f));
                }
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Dot"))
            _isTouchingDot = true;
    }

    IEnumerator CloseMiniGame()
    {
        yield return new WaitForSeconds(1f);
        if (introversionCounter.text == "10/10" || extraversionCounter.text == "10/10")
            SceneManager.LoadScene(2);
        else
            StopCoroutine(CloseMiniGame());

    }
}
