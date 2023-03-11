using System.Collections;
using Cinemachine;
using UnityEngine;

public class Bus : MonoBehaviour
{
    public GameObject bus;
    private Rigidbody2D _busRb;
    public GameObject character;
    public Transform hospitalPoint;
    private bool _isInStation;
    private bool _isDriving;
    private bool _inBus;
    public Transform busSpawnPosition;
    public CinemachineVirtualCamera mainCamera;
    public BoxCollider2D wallTrigger;


    private void Start()
    {
        _busRb = bus.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (_isInStation && Input.GetKeyDown(KeyCode.E))
        {
            character.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            var position = busSpawnPosition.position;
            bus.transform.position = new Vector3(position.x, position.y, position.z);
            _isDriving = true;
            hospitalPoint.GetComponent<BoxCollider2D>().enabled = true;
            if (!bus.activeInHierarchy)
                bus.SetActive(true);
        }

        if (_isDriving)
        {
            _busRb.bodyType = RigidbodyType2D.Dynamic;
            _busRb.AddForce(Vector2.right, ForceMode2D.Force);
        }
        else
        {
            _busRb.Sleep();
            _busRb.bodyType = RigidbodyType2D.Kinematic;
        }
        
        if (bus.GetComponent<BoxCollider2D>().IsTouching(hospitalPoint.GetComponent<BoxCollider2D>()))
        {
            character.GetComponent<SpriteRenderer>().enabled = true;
            character.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            mainCamera.Follow = character.transform;
            _isDriving = false;
            _inBus = false;
            hospitalPoint.GetComponent<BoxCollider2D>().enabled = false;
            StartCoroutine(DrivingAway());
        }

        if (bus.GetComponent<BoxCollider2D>().IsTouching(wallTrigger))
        {
            wallTrigger.isTrigger = false;
        }

        if (_inBus)
            character.transform.position = bus.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bus"))
        {
            _isDriving = false;
            StartCoroutine(WaitForPlayer());
        }
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
            _isInStation = true;
        
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
            _isInStation = false;
    }

    IEnumerator WaitForPlayer()
    {
        yield return new WaitForSeconds(1.5f);
        character.GetComponent<SpriteRenderer>().enabled = false;
        mainCamera.Follow = bus.transform;
        _isDriving = true;
        _inBus = true;
    }

    IEnumerator DrivingAway()
    {
        yield return new WaitForSeconds(1.5f);
        _isDriving = true;
        yield return new WaitForSeconds(5f);
        bus.SetActive(false);
    }
}
