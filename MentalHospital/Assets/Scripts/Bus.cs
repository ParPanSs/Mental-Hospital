using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Bus : MonoBehaviour
{
    public GameObject bus;
    private float _speedOfBus = 5f;
    public GameObject character;
    public Transform hospitalPoint;
    private bool _isInStation;
    public Transform busSpawnPosition;
    public Transform busStopPosition;
    public CinemachineVirtualCamera mainCamera;
    
    void Update()
    {
        if (_isInStation && Input.GetKeyDown(KeyCode.E))
        {
            var position = busSpawnPosition.position;
            bus.transform.position = new Vector3(position.x, position.y, position.z);
            bus.SetActive(true);
            //if(bus.transform.position != gameObject.transform.position)
            //StartCoroutine(WaitForPlayer());

        }
        if(bus.transform.position.x < busStopPosition.position.x)
            bus.transform.Translate(new Vector3(_speedOfBus * Time.deltaTime, 0, 0));
        else
        {
            bus.transform.Translate(new Vector3(0, 0, 0));
            StartCoroutine(WaitForPlayer());
        }

    }
    /*
    void Minibus()
    {
        while (bus.transform.position != gameObject.transform.position)
        {
            bus.transform.position = new Vector2(bus.transform.position.x + 2, bus.transform.position.y);
        }

    }*/
    
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
        yield return new WaitForSeconds(2f);
        character.GetComponent<SpriteRenderer>().enabled = false;

        //character.GetComponent<Rigidbody2D>().velocity = new Vector2(_speedOfBus * Time.deltaTime, 0);
        mainCamera.Follow = bus.transform;
        bus.transform.Translate(new Vector3(_speedOfBus * Time.deltaTime, 0, 0));
        if (bus.transform.position.x > hospitalPoint.position.x)
        {
            character.transform.position = new Vector2(hospitalPoint.position.x, hospitalPoint.transform.position.y);
            character.GetComponent<SpriteRenderer>().enabled = true;
            mainCamera.Follow = character.transform;
            bus.transform.position = hospitalPoint.position;

        }
    }
}
