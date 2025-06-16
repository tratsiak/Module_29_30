using System.Collections.Generic;

public interface IReadOnlyCell
{
    public IReadOnlyList<Item> Items { get; }

    public int Count => Items.Count;
}
