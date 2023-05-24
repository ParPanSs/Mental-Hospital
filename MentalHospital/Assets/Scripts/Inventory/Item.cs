using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Create Item")]
public class Item : ScriptableObject
{
    public string itemName = "";
    public Sprite itemSprite = null;
}
