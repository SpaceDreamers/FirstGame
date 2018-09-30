using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ControllerSprint : AbstractController
{
    private Image sprintImage;

    [SerializeField]
    private Sprite sprintSprite;

    private bool sprintClick;

    private void Start()
    {
        sprintImage = GetComponent<Image>();

        sprintImage.sprite = sprintSprite;

        sprintClick = false;
    }

    public virtual void OnPointerDown(PointerEventData ped)
    {
        sprintClick = true;
    }

    public virtual void OnPointerUp(PointerEventData ped)
    {
        sprintClick = false;
    }

    public bool JumpCharacter()
    {
        return sprintClick ? sprintClick : Input.GetKeyDown(KeyCode.LeftShift);
    }

}
