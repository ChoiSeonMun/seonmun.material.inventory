using UnityEngine;
using UnityEngine.UI;

public class EquippedItemSlotData
{
    public Sprite GradeSprite;
    public Sprite ItemIconSprite;
}

public class EquippedItemSlot : MonoBehaviour
{
    [SerializeField] private Image _gradeImage;
    [SerializeField] private Image _itemIconImage;
    [SerializeField] private GameObject _equippedUi;

    private void Awake()
    {
        Reset();
    }

    public void SetData(EquippedItemSlotData data)
    {
        _gradeImage.sprite = data.GradeSprite;
        _itemIconImage.sprite = data.ItemIconSprite;
        _equippedUi.SetActive(true);
    }

    public void Reset()
    {
        _gradeImage.sprite = null;
        _itemIconImage.sprite = null;
        _equippedUi.SetActive(false);
    }
}
