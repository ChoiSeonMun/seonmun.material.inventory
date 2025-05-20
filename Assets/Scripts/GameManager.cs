using System;
using UnityEngine;


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
