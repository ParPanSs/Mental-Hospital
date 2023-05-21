using UnityEngine;

public class InBath : MonoBehaviour
{
    [SerializeField] private GameObject bath;
    [SerializeField] private Transform bathSpawnPoint;
    [SerializeField] private Transform characterPoint;
    [SerializeField] private Transform roomSpawnPoint;
    [SerializeField] private GameObject background;
    [SerializeField] private BoxCollider2D flower;
    private bool _inTrigger;
    private bool _inBath;

    private void Update()
    {
        if (_inTrigger && Input.GetKeyDown(KeyCode.E))
        {
            Teleportation();
        }
    }

    private void Teleportation()
    {
        if (!_inBath)
        {
            background.GetComponent<BoxCollider2D>().enabled = false;
            bath.SetActive(true);
            characterPoint = bathSpawnPoint;
            _inBath = true;
            flower.enabled = false;
        }
        else
        {
            background.GetComponent<BoxCollider2D>().enabled = true;
            bath.SetActive(false);
            characterPoint = roomSpawnPoint;
            _inBath = false;
            flower.enabled = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            _inTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            _inTrigger = false;
    }
}
