using System.Collections.Generic;

public class InventoryService
{
    private ItemRepository _itemRepository;

    public InventoryService(ItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }

    public List<Item> Items => _itemRepository.GetAllItem();
}
