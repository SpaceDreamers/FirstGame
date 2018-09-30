using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ControllerInventory : AbstractController, IPointerDownHandler
{
    private Image inventoryImage;

    [SerializeField]
    private Sprite inventorySprite;

    [SerializeField]
    private Color color1;
    [SerializeField]
    private Color color2;

    private bool inventoryClick;

    private void Start()
    {
        inventoryImage = GetComponent<Image>();

        inventoryImage.sprite = inventorySprite;

        inventoryClick = false;
    }

    private void Update()
    {
        if (inventoryClick)
        {
            inventoryImage.color = color2;
        }
        else
        {
            inventoryImage.color = color1;
        }
    }
    public virtual void OnPointerDown(PointerEventData ped)
    {
        inventoryClick = inventoryClick ? false : true;
    }

    public bool InventoryCharacter()
    {
        return inventoryClick;
    }
}
