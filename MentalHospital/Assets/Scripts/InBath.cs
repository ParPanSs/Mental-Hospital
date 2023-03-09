using System;
using UnityEngine;

public class InBath : MonoBehaviour
{
    public GameObject bath;
    public Transform bathSpawnPoint;
    public Transform characterPoint;
    public Transform roomSpawnPoint;
    public GameObject background;
    private bool _inTrigger;
    private bool _inBath;

    void Update()
    {
        if (_inTrigger && Input.GetKeyDown(KeyCode.E))
        {
            Teleportation();
        }
    }

    void Teleportation()
    {
        if (!_inBath)
        {
            background.GetComponent<BoxCollider2D>().enabled = false;
            bath.SetActive(true);
            characterPoint = bathSpawnPoint;
            _inBath = true;
        }
        else
        {
            background.GetComponent<BoxCollider2D>().enabled = true;
            bath.SetActive(false);
            characterPoint = roomSpawnPoint;
            _inBath = false;
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
