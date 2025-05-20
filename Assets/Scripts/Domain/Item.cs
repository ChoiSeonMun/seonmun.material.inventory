using System.Collections;
using System.Text;
using UnityEngine;

public enum ItemGrade
{
    None,
    Common,
    Uncommon,
    Rare,
    Epic,
    Legendary
}


public enum ItemType
{
    None,
    Weapon,
    Shield,
    ChestArmor,
    Gloves,
    Boots,
    Accessory
}

public class Item
{
    public ItemType Type => _type;
    public ItemGrade Grade => _grade;
    public string IconSpritePath => _iconSpritePath;
    public string GradeSpritePath => _gradeSpritePath;

    private readonly int _id;
    private readonly string _name;
    private readonly int _atk;
    private readonly int _defense;
    private readonly ItemType _type;
    private readonly ItemGrade _grade;
    private readonly string _iconSpritePath;
    private readonly string _gradeSpritePath;

    public Item(int id, string name, int atk, int defense)
    {
        _id = id;
        _name = name;
        _atk = atk;
        _defense = defense;
        _type = GetItemType(id);
        _grade = GetItemGrade(id);
        _iconSpritePath = ParseIconPath(id);
        _gradeSpritePath = $"{_grade}";
    }

    private string ParseIconPath(int id)
    {
        StringBuilder sb = new(id.ToString());
        sb[1] = '1';

        return sb.ToString();
    }

    private ItemType GetItemType(int id)
    {
        // NOTE: 5자리 중 첫 번째 자릿수는 종류를 나타낸다.
        int value = id / 10000;
        switch (value)
        {
            case 1:
                return ItemType.Weapon;
            case 2:
                return ItemType.Shield;
            case 3:
                return ItemType.ChestArmor;
            case 4:
                return ItemType.Gloves;
            case 5:
                return ItemType.Boots;
            case 6:
                return ItemType.Accessory;
            default:
                return ItemType.None;
        }
    }

    private ItemGrade GetItemGrade(int id)
    {
        // NOTE: 5자리 중 두 번째 자릿수는 등급을 나타낸다.
        int value = id / 1000 % 10;
        switch (value)
        {
            case 1:
                return ItemGrade.Common;
            case 2:
                return ItemGrade.Uncommon;
            case 3:
                return ItemGrade.Rare;
            case 4:
                return ItemGrade.Epic;
            case 5:
                return ItemGrade.Legendary;
            default:
                return ItemGrade.None;
        }
    }
}
