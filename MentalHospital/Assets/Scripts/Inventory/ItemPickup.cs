using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;

    public void PickUp()
    {
        InventoryManager.GetInstance().AddItem(item);
        Destroy(gameObject);
    }
}
