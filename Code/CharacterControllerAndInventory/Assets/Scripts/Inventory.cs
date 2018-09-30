using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    List<Item> items;
    public GameObject cellContainer;
    private ControllerInventory inventoryController;


    private void Start()
    {

        inventoryController = GameObject.FindGameObjectWithTag("ControllerInventory").GetComponent<ControllerInventory>();
        items = new List<Item>();

        cellContainer.SetActive(false);
        for (int i = 0; i < cellContainer.transform.childCount; i++)
        {
            items.Add(new Item());
        }
    }

    private void Update()
    {
        if (inventoryController.InventoryCharacter())
        {


            cellContainer.SetActive(true);

        }
        else
        {

            cellContainer.SetActive(false);
        }

    }
}
