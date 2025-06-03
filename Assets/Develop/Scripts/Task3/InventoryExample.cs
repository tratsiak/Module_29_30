using UnityEngine;

public class InventoryExample : MonoBehaviour
{
    [SerializeField] private int _maxSize;

    private Item[] _items;

    private Inventory _inventory;

    private void Start()
    {
        _items = new Item[] 
        { 
            new Item(1, 10),
            new Item(2, 15),
            new Item(3, 30),
            new Item(1, 2),
        };

        _inventory = new Inventory(_items, _maxSize);

        _inventory.Add(new Item(1, 10));
        _inventory.Add(new Item(4, 22));

        _inventory.ShowAllItems();

        _inventory.Remove(2, 8);

        _inventory.ShowAllItems();
    }
}
