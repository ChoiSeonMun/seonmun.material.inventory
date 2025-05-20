using Gpm.Ui;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotData : InfiniteScrollData
{
    public Sprite Grade;
    public Sprite ItemIcon;
}

public class InventorySlot : InfiniteScrollItem
{
    [SerializeField] private Image _gradeBackground;
    [SerializeField] private Image _itemIcon;

    private InventorySlotData _data;

    public override void UpdateData(InfiniteScrollData scrollData)
    {
        base.UpdateData(scrollData);

        _data = scrollData as InventorySlotData;

        _gradeBackground.sprite = _data.Grade;
        _itemIcon.sprite = _data.ItemIcon;
    }
}
