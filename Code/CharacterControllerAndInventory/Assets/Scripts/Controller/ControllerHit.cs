using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ControllerHit : AbstractController
{
    private Image hitImage;

    [SerializeField]
    private Sprite hitSprite;

    private bool hitClick;

    private void Start()
    {
        hitImage = GetComponent<Image>();

        hitImage.sprite = hitSprite;

        hitClick = false;
    }

    public virtual void OnPointerDown(PointerEventData ped)
    {
        hitClick = true;
    }

    public virtual void OnPointerUp(PointerEventData ped)
    {
        hitClick = false;
    }

    public bool JumpCharacter()
    {
        return hitClick;
    }

}
