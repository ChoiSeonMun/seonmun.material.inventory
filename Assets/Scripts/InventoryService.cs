using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

public class InventoryService
{
    private UserInventoryItem[] _equippedItems = new UserInventoryItem[7];
    private IUserInventoryItemRepository _userInventoryItemRepo;
    private IItemRepository _itemRepo;

    public InventoryService(IUserInventoryItemRepository repo, IItemRepository itemRepo)
    {
        _userInventoryItemRepo = repo;
        _itemRepo = itemRepo;
    }

    public ReadOnlyCollection<UserInventoryItem> Items => _userInventoryItemRepo.GetAllItems();

    public ReadOnlyCollection<UserInventoryItem> EquippedItems
        => new ReadOnlyCollection<UserInventoryItem>(_equippedItems.Where(x => x != null).ToList());

    public Item GetItemById(int itemId) => _itemRepo.GetItemById(itemId);

    public void Equip(long serialNumber)
    {
        var userItem = _userInventoryItemRepo.GetItemBySerialNumber(serialNumber);
        var item = _itemRepo.GetItemById(userItem.Id);
        if (_equippedItems[(int)item.Type] != null)
        {
            _equippedItems[(int)item.Type].Unequip();
            _equippedItems[(int)item.Type] = null;
        }

        _equippedItems[(int)item.Type] = userItem;
        userItem.Equip();
    }

    public void Unequip(long serialNumber)
    {
        var userItem = _userInventoryItemRepo.GetItemBySerialNumber(serialNumber);
        var item = _itemRepo.GetItemById(userItem.Id);
        _equippedItems[(int)item.Type] = null;
        userItem.Unequip();
    }

}
