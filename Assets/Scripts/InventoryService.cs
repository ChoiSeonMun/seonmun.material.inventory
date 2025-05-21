using System.Collections.Generic;
using System.Collections.ObjectModel;

public class InventoryService
{
    private IUserInventoryItemRepository _userInventoryItemRepo;
    private IItemRepository _itemRepo;

    public InventoryService(IUserInventoryItemRepository repo, IItemRepository itemRepo)
    {
        _userInventoryItemRepo = repo;
        _itemRepo = itemRepo;
    }

    public ReadOnlyCollection<UserInventoryItem> Items => _userInventoryItemRepo.GetAllItems();

    public Item GetItemById(int itemId) => _itemRepo.GetItemById(itemId);
}
