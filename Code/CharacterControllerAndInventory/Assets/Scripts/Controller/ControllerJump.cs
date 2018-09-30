using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ControllerJump : AbstractController, IPointerDownHandler, IPointerUpHandler
{
    private Image jumpImage;

    [SerializeField]
    private Sprite jumpSprite;

    private bool jumpClick;

    private void Start()
    {
        jumpImage = GetComponent<Image>();

        jumpImage.sprite = jumpSprite;

        jumpClick = false;
    }

    public virtual void OnPointerDown(PointerEventData ped)
    {
        jumpClick = true;
    }

    public virtual void OnPointerUp(PointerEventData ped)
    {
        jumpClick = false;
    }

    public bool JumpCharacter()
    {
        return jumpClick ? jumpClick : Input.GetKeyDown(KeyCode.Space);
    }

}
