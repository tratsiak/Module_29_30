using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;

public class Inventory
{
    public readonly int MaxSize;

    private List<Item> _items = new();

    public Inventory(Item[] items, int maxSize)
    {
        if (maxSize <= 0)
            throw new ArgumentOutOfRangeException(nameof(maxSize), "The value cannot be negative or zero.");

        MaxSize = maxSize;

        foreach (Item item in items)
            Add(item);
    }

    public int CurrentSize => _items.Sum(item => item.Count);

    public void Add(Item item)
    {
        if (CurrentSize + item.Count > MaxSize)
            throw new ArgumentOutOfRangeException(nameof(MaxSize), "The value cannot be greater than the max size.");

        Item existingItem = _items.FirstOrDefault(existing => existing.ID == item.ID);

        if (existingItem != null)
            existingItem.Count += item.Count;
        else
            _items.Add(item);
    }

    public void Remove(int id, int count)
    {
        Item existingItem = _items.FirstOrDefault(existing => existing.ID == id);

        if (existingItem == null)
            throw new NullReferenceException(nameof(existingItem));

        if (existingItem.Count < count)
            throw new ArgumentOutOfRangeException(nameof(count), "The value cannot be greater than the max count.");

        existingItem.Count -= count;

        if (existingItem.Count == 0)
            _items.Remove(existingItem);
    }

    public void ShowAllItems()
    {
        foreach (Item item in _items)
        {
            Debug.Log($"Item ID: {item.ID}, Item count: {item.Count}");
        }
    }
}

public class Item
{
    private int _id;
    private int _count;

    public Item(int id, int count)
    {
        ID = id;
        Count = count;
    }

    public int ID
    {
        get => _id;
        private set
        {
            if (value <= 0)
                throw new System.ArgumentException("ID cannot be negative or zero.");
            _id = value;
        }
    }

    public int Count
    {
        get => _count;
        set
        {
            if (value <= 0)
                throw new System.ArgumentException("Item count cannot be negative or zero.");
            _count = value;
        }
    }
}