using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

public interface IUserInventoryItemRepository
{
    UserInventoryItem GetItemBySerialNumber(long serialNumber);
    ReadOnlyCollection<UserInventoryItem> GetAllItems();
}

public class TestInventoryItemRepository : IUserInventoryItemRepository
{
    private List<UserInventoryItem> _data;

    public TestInventoryItemRepository(List<UserInventoryItem> data)
    {
        _data = data;
    }

    public ReadOnlyCollection<UserInventoryItem> GetAllItems()
    {
        return _data.AsReadOnly();
    }

    public UserInventoryItem GetItemBySerialNumber(long serialNumber)
    {
        return _data.Find(item => item.SerialNumber == serialNumber);
    }
}