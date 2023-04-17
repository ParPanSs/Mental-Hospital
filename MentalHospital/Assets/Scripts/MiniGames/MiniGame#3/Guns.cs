using System;
using UnityEngine;

public class Guns : MonoBehaviour
{
    [SerializeField] private GameObject smileBullet;
    [SerializeField] private GameObject sadBullet;

    [SerializeField] private Transform sadGun;
    [SerializeField] private Transform smileGun;
    
    [SerializeField] private Transform sadGunPosition;
    [SerializeField] private Transform smileGunPosition;

    private Vector3 _previousSadPosition;
    private Vector3 _previousSmilePosition;

    private void Start()
    {
        _previousSadPosition = sadGunPosition.position;
        _previousSmilePosition = smileGunPosition.position;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(smileBullet, smileGun.GetComponentInChildren<Transform>().position, Quaternion.identity);
            Instantiate(sadBullet, sadGun.GetComponentInChildren<Transform>().position, Quaternion.identity);
        }

        if (Input.GetMouseButtonDown(1))
        {
            ChangePositions();
        }
    }
    
    private void ChangePositions()
    {
        _previousSadPosition = sadGun.position;
        _previousSmilePosition = smileGun.position;
        
        sadGun.position = _previousSmilePosition;
        smileGun.position = _previousSadPosition;
    }
}
