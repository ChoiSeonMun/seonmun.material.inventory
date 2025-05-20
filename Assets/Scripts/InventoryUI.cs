using Gpm.Ui;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public int Count = 10;
    [SerializeField] private InfiniteScroll _infiniteScroll;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < Count; i++)
        {
            _infiniteScroll.InsertData(new InfiniteScrollData());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
