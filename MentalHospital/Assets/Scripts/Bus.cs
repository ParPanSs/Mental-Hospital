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

    [SerializeField] private BoxCollider2D yards;
    public Transform busSpawnPosition;
    public CinemachineVirtualCamera mainCamera;
    public BoxCollider2D wallTrigger;
    public GameObject stationWall;

    private Behaviour _behaviour;

    private void Start()
    {
        _behaviour = FindObjectOfType<Behaviour>();
        _busRb = bus.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (_isInStation)
        {
            character.gameObject.SetActive(false);
            character.animator.SetBool("isWalk", false);
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
            _busRb.AddForce(Vector2.right.normalized * 5f); 
        }
        else
        {
            _busRb.Sleep();
            _busRb.bodyType = RigidbodyType2D.Kinematic;
        }
        
        if(bus.GetComponent<BoxCollider2D>().IsTouching(hospitalPoint.GetComponent<BoxCollider2D>()))
            DialogManager.GetInstance().EnterDialogueMode(bus.GetComponent<DialogTrigger>().inkJSON, hospitalPoint.gameObject);
        
        if ((bus.GetComponent<BoxCollider2D>().IsTouching(hospitalPoint.GetComponent<BoxCollider2D>()) && _behaviour.firstCharacteristic == Behaviour.Characteristics.Extravert)
            || (bus.GetComponent<BoxCollider2D>().IsTouching(yards) && _behaviour.firstCharacteristic == Behaviour.Characteristics.Introvert))
        {
            character.gameObject.SetActive(true);
            mainCamera.Follow = character.gameObject.transform;
            _isDriving = false;
            _inBus = false;
            hospitalPoint.GetComponent<BoxCollider2D>().enabled = false;
            // character.gameObject.SetActive(false);
            // character.gameObject.SetActive(true);
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
