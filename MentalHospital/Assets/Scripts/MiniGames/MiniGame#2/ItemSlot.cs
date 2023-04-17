using UnityEngine;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] private SlotsManager slotsManager;
    void Update()
    {
        if (transform.childCount == 0)
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }

        slotsManager.CheckFull();
    }
    
    
}