using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    private static InventoryManager _instance;
    [SerializeField] private List<Item> _items = new List<Item>();

    [SerializeField] private Transform _itemContent;
    [SerializeField] private GameObject _inventoryItem;

    private void Awake()
    {
        _instance = this;
    }
    public static InventoryManager GetInstance()
    {
        return _instance;
    }

    public void AddItem(Item item)
    {
        _items.Add(item);
    }

    public void RemoveItem(Item item)
    {
        _items.Remove(item);
    }

    public void ListItems()
    {
        foreach (Transform item in _itemContent)
        {
            Destroy(item.gameObject);
        }
        
        foreach (var item in _items)
        {
            GameObject obj = Instantiate(_inventoryItem, _itemContent);
            var itemIcon = obj.transform.Find("Icon").GetComponent<Image>();

            itemIcon.sprite = item.itemSprite;
        }
    }
}
