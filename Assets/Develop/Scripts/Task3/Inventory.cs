using System.Collections.Generic;
using System.Linq;
using System;

public class Inventory
{
    public readonly int MaxSize;

    private List<Cell> _cells = new List<Cell>();

    public Inventory(List<Item> items, int maxSize)
    {
        if (maxSize <= 0)
            throw new ArgumentOutOfRangeException(nameof(maxSize), "The value cannot be negative or zero.");

        MaxSize = maxSize;

        foreach (Item item in items)
            Add(item);
    }

    public IReadOnlyList<IReadOnlyCell> Cells => _cells;

    public int CurrentSize => _cells.Sum(cell => cell.Count);

    public void Add(Item item)
    {
        if (CurrentSize + 1 > MaxSize)
            throw new ArgumentOutOfRangeException(nameof(MaxSize), "The value cannot be greater than the max size.");

        Cell existingCell = _cells.FirstOrDefault(existingCell => existingCell.Items[0].ID == item.ID);

        if (existingCell != null)
            existingCell.Add(item);
        else
            _cells.Add(new Cell(item));
    }

    public void Remove(int id, int count)
    {
        Cell existingCell = _cells.FirstOrDefault(existingCell => existingCell.Items[0].ID == id);

        if (existingCell == null)
            throw new NullReferenceException(nameof(existingCell));

        if (existingCell.Count < count)
            throw new ArgumentOutOfRangeException(nameof(count), "The value cannot be greater than the max count.");

        existingCell.Remove(count);

        if (existingCell.Count == 0)
            _cells.Remove(existingCell);
    }
}

public class Cell : IReadOnlyCell
{
    private List<Item> _items = new List<Item>();

    public Cell(Item item)
    {
        Add(item);
    }

    public IReadOnlyList<Item> Items => _items;

    public int Count => _items.Count;

    public void Add(Item item) => _items.Add(item);

    public void Remove(int count) => _items.RemoveRange(_items.Count - count, count);
}

public class Item
{
    private int _id;

    public Item(int id)
    {
        ID = id;
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
}