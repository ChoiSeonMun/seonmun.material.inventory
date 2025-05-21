using Gpm.Ui;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private InfiniteScroll _infiniteScroll;

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
    }

    void Start()
    {
        var userItems = _service.Items.OrderBy(userItem =>
        {
            var item = _service.GetItemById(userItem.Id);
            return item.Grade;
        });

        foreach (var userItem in userItems)
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
