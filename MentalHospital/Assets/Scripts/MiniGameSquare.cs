using System;
using System.Collections;
using UnityEngine;
using System.Linq;
using TMPro;
using Unity.VisualScripting;

public class MiniGameSquare : MonoBehaviour
{
    private bool _isTouchingDot;

    private bool _isTouchingWall;
    //square moving
    private Rigidbody2D _rb;
    
    private readonly float _speed = 3f;
    
    //dots
    public Rigidbody2D[] dots;
    
    //text
    public TextMeshProUGUI introversion;
    public TextMeshProUGUI extraversion;
    
    //interact
    public GameObject introversionWall;
    public GameObject miniGame;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        for (int i = 0; i < dots.Length; i++)
        {
            var touchedDot = dots.Where(d => d.IsTouching(
                collider: introversionWall.GetComponent<PolygonCollider2D>()
            )).ToList();
            touchedDot.ForEach(d => d.GetComponent<CircleCollider2D>().isTrigger = false);
            introversion.text = touchedDot.Count + "/10";
        }
        for (int i = 0; i < dots.Length; i++)
        {
            var touchedDot = dots.Where(d => d.IsTouching(
                collider: _rb.transform.GetChild(1).GetComponent<CircleCollider2D>()
            )).ToList();
            touchedDot.ForEach(d => d.GetComponent<CircleCollider2D>().isTrigger = false);
            extraversion.text = touchedDot.Count + "/10";
        }

        if (introversion.text == "10/10" || extraversion.text == "10/10")
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
                        d.AddForce((d.position - (Vector2)gameObject.transform.position).normalized * _speed));
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
                        var isTrigger = d.IsTouching(
                            introversionWall.GetComponent<PolygonCollider2D>());
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
                        d.AddForce(((Vector2)gameObject.transform.position - d.position).normalized * _speed));
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
        miniGame.SetActive(false);
    }
}
