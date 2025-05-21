using System.Collections.Generic;
using System.Collections.ObjectModel;

public interface IUserInventoryItemRepository
{
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
}