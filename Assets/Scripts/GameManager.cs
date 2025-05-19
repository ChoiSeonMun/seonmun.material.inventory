using System;
using UnityEngine;

// 데이터테이블과 똑같이 만든다.
[Serializable]
public class ItemModel
{
    public int item_id;
    public string item_name;
    public int attack_power;
    public int defense;
}

// JsonUtility를 사용하기 위한 클래스
[Serializable]
public class ItemModelWrapper
{
    public ItemModel[] data;
}

public class GameManager : MonoBehaviour
{
    void Start()
    {
        var itemJson = Resources.Load<TextAsset>("items");
        var items = JsonUtility.FromJson<ItemModelWrapper>(itemJson.text);

        foreach (var item in items.data)
        {
            Debug.Log($"{item.item_id}, {item.item_name}, {item.attack_power}, {item.defense}");
        }
    }
}
