using System;
using UnityEditor;

public class UserInventoryItem
{
    public int Id => _itemId;

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
    }
}