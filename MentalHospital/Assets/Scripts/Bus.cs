using System.Collections;
using Cinemachine;
using UnityEngine;

public class Bus : MonoBehaviour
{
    public GameObject bus;
    private Rigidbody2D _busRb;
    [SerializeField] private CharacterController character;
    public Transform hospitalPoint;
    private bool _isInStation;
    private bool _isDriving;
    private bool _inBus;
    private bool _canMove = true;
    public Transform busSpawnPosition;
    public CinemachineVirtualCamera mainCamera;
    public BoxCollider2D wallTrigger;
    public GameObject stationWall;

    private void Start()
    {
        _busRb = bus.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (_isInStation && Input.GetKeyDown(KeyCode.E))
        {
            _canMove = !_canMove;
            character.rb.bodyType = RigidbodyType2D.Static;
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
            _busRb.AddForce(Vector2.right.normalized * 0.5f);
        }
        else
        {
            _busRb.Sleep();
            _busRb.bodyType = RigidbodyType2D.Kinematic;
        }
        
        if (bus.GetComponent<BoxCollider2D>().IsTouching(hospitalPoint.GetComponent<BoxCollider2D>()))
        {
            _canMove = !_canMove;
            character.rb.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            character.rb.bodyType = RigidbodyType2D.Dynamic;
            mainCamera.Follow = character.gameObject.transform;
            _isDriving = false;
            _inBus = false;
            hospitalPoint.GetComponent<BoxCollider2D>().enabled = false;
            StartCoroutine(DrivingAway());
        }

        if (bus.GetComponent<BoxCollider2D>().IsTouching(wallTrigger))
        {
            wallTrigger.isTrigger = false;
            stationWall.SetActive(false);
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
        character.rb.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        mainCamera.Follow = bus.transform;
        _isDriving = true;
        _inBus = true;
    }

    IEnumerator DrivingAway()
    {
        yield return new WaitForSeconds(1.5f);
        _isDriving = true;
        yield return new WaitForSeconds(10f);
        bus.SetActive(false);
    }
}
