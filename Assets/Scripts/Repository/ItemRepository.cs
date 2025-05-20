using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem.Utilities;

// DAO; Data Access Object
// 영속성 데이터에 접근하기 위한 객체
[Serializable]
class ItemModel
{
    public int item_id;
    public string item_name;
    public int attack_power;
    public int defense;
}

// JsonUtility를 사용하기 위한 클래스
[Serializable]
class ItemModelWrapper
{
    public ItemModel[] data;
}

public class ItemRepository
{
    private Dictionary<int, ItemModel> _itemTable = new();

    public ItemRepository()
    {
        LoadItemsFromJson();
    }

    public Item GetItemById(int id)
    {
        if (false == _itemTable.TryGetValue(id, out var model))
        {
            throw new KeyNotFoundException($"Item {id} not found.");
        }
           
        return new Item(model.item_id, model.item_name, model.attack_power, model.defense);
    }


    public List<Item> GetAllItem()
    {
        var list = new List<Item>();
        foreach (var model in _itemTable.Values)
        {
            list.Add(new Item(model.item_id, model.item_name, model.attack_power, model.defense));
        }

        return list;
    }

    private void LoadItemsFromJson()
    {
        var json = Resources.Load<TextAsset>("items");
        var items = JsonUtility.FromJson<ItemModelWrapper>(json.text);

        foreach(ItemModel item in items.data)
        {
            _itemTable.Add(item.item_id, item);
        }
    }
}
