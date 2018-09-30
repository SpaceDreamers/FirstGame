using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ControllerPut : AbstractController
{
    private Image putImage;

    [SerializeField]
    private Sprite putSprite;

    private bool putClick;

    private void Start()
    {
        putImage = GetComponent<Image>();

        putImage.sprite = putSprite;

        putClick = false;
    }

    public virtual void OnPointerDown(PointerEventData ped)
    {
        putClick = true;
    }

    public virtual void OnPointerUp(PointerEventData ped)
    {
        putClick = false;
    }

    public bool JumpCharacter()
    {
        return putClick;
    }

}
