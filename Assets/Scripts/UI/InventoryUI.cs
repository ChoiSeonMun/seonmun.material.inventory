using Gpm.Ui;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private InfiniteScroll _infiniteScroll;

    [Header("장비 슬롯")]
    [SerializeField] private EquippedItemSlot _weaponSlot;
    [SerializeField] private EquippedItemSlot _glovesSlot;
    [SerializeField] private EquippedItemSlot _accessarySlot;
    [SerializeField] private EquippedItemSlot _shieldSlot;
    [SerializeField] private EquippedItemSlot _chestArmorSlot;
    [SerializeField] private EquippedItemSlot _bootsSlot;

    private InventoryService _service;

    private void Awake()
    {
        var testUserData = new List<UserInventoryItem>()
        {
            UserInventoryItem.CreateNew(11001),
            UserInventoryItem.CreateNew(11002),
            UserInventoryItem.CreateNew(21001),
            UserInventoryItem.CreateNew(21002),
            UserInventoryItem.CreateNew(31001),
            UserInventoryItem.CreateNew(31002),
            UserInventoryItem.CreateNew(41001),
            UserInventoryItem.CreateNew(41002),
            UserInventoryItem.CreateNew(51001),
            UserInventoryItem.CreateNew(51002),
            UserInventoryItem.CreateNew(61001),
            UserInventoryItem.CreateNew(61002)
        };

        _service = new InventoryService(
            new TestInventoryItemRepository(testUserData),
            new ItemRepository());

        _service.Equip(testUserData[0].SerialNumber);
        _service.Equip(testUserData[2].SerialNumber);
        _service.Equip(testUserData[1].SerialNumber);
    }

    void Start()
    {
        foreach (var equippedItem in _service.EquippedItems)
        {
            var item = _service.GetItemById(equippedItem.Id);
            EquippedItemSlotData slotData = new EquippedItemSlotData()
            {
                GradeSprite = Resources.Load<Sprite>($"Textures/{item.GradeSpritePath}"),
                ItemIconSprite = Resources.Load<Sprite>($"Textures/{item.IconSpritePath}"),
            };

            switch (item.Type)
            {
                case ItemType.Weapon:
                    _weaponSlot.SetData(slotData);
                    break;
                case ItemType.Gloves:
                    _glovesSlot.SetData(slotData);
                    break;
                case ItemType.Accessory:
                    _accessarySlot.SetData(slotData);
                    break;
                case ItemType.Shield:
                    _shieldSlot.SetData(slotData);
                    break;
                case ItemType.ChestArmor:
                    _chestArmorSlot.SetData(slotData);
                    break;
                case ItemType.Boots:
                    _bootsSlot.SetData(slotData);
                    break;
                default:
                    Debug.LogError($"Unknown item type: {item.Type}");
                    break;
            }
        }

        var orderedUserItems = _service.Items.
               Where(userItem => userItem.IsEquipped == false).
               OrderByDescending(userItem =>
                {
                    var item = _service.GetItemById(userItem.Id);
                    return item.Grade;
                });

        foreach (var userItem in orderedUserItems)
        {
            var item = _service.GetItemById(userItem.Id);

            var gradeSprite = Resources.Load<Sprite>($"Textures/{item.GradeSpritePath}");
            var itemIconSprite = Resources.Load<Sprite>($"Textures/{item.IconSpritePath}");

            if (gradeSprite == null || itemIconSprite == null)
            {
                Debug.LogError($"Failed to load sprite for item: {itemIconSprite}");
                continue;
            }

            var data = new InventorySlotData()
            {
                Grade = gradeSprite,
                ItemIcon = itemIconSprite
            };

            _infiniteScroll.InsertData(data);
        }
    }
}
