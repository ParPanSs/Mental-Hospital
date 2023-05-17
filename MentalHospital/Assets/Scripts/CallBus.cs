using UnityEngine;

public class CallBus : MonoBehaviour
{
    [SerializeField] private GameObject _bus;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(_bus, gameObject.transform.position, Quaternion.identity);
        }
    }
}
