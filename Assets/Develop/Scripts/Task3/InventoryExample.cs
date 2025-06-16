using System.Collections.Generic;
using UnityEngine;

public class InventoryExample : MonoBehaviour
{
    [SerializeField] private int _maxSize;

    private List<Item> _items;

    private Inventory _inventory;

    private void Start()
    {
        _items = new List<Item>();

        for (int i = 1; i <= 5; i++)
        {
            _items.Add(new Item(i));
        }

        _inventory = new Inventory(_items, _maxSize);

        _inventory.Add(new Item(2));
        _inventory.Add(new Item(4));

        foreach (IReadOnlyCell cell in _inventory.Cells)
        {
            Debug.Log($"Count of items with ID:{cell.Items[0].ID} - {cell.Count}");
        }

        _inventory.Remove(2, 2);

        foreach (IReadOnlyCell cell in _inventory.Cells)
        {
            Debug.Log($"Count of items with ID:{cell.Items[0].ID} - {cell.Count}");
        }
    }
}
