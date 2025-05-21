using System;
using UnityEditor;

public class UserInventoryItem
{
    public int Id => _itemId;
    public long SerialNumber => _serialNumber;
    public bool IsEquipped { get; private set; }

    private static readonly Random random = new Random();
    private readonly long _serialNumber;
    private readonly int _itemId;

    public static UserInventoryItem CreateNew(int itemId)
    {
        long serialNumber = long.Parse(DateTime.Now.ToString("yyyyMMdd") + random.Next(10000).ToString("D4"));

        return new UserInventoryItem(serialNumber, itemId);
    }

    private UserInventoryItem(long serialNumber, int itemId)
    {
        _serialNumber = serialNumber;
        _itemId = itemId;
        IsEquipped = false;
    }

    public void Equip()
    {
        if (IsEquipped)
        {
            throw new Exception($"Item {Id} is already equipped.");
        }

        IsEquipped = true;
    }

    public void Unequip()
    {
        if (IsEquipped == false)
        {
            throw new Exception($"Item {Id} is not equipped.");
        }

        IsEquipped = false;
    }
}