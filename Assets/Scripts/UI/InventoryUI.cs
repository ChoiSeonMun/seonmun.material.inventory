using Gpm.Ui;
using System.Linq;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private InfiniteScroll _infiniteScroll;

    private InventoryService _service;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _service = new InventoryService(new ItemRepository());

        var items = _service.Items.OrderByDescending(x => x.Grade);

        foreach (var item in items)
        {
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
