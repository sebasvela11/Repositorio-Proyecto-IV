using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelect : MonoBehaviour
{
    public bool enableSelectCharacter;

    public enum Player {NinjaFrog, VirtualGuy, PinkMan, MaskDude }
    public Player playerSelected;

    public Animator animator;
    public SpriteRenderer spriteRenderer;

    public RuntimeAnimatorController[] playerController;
    public Sprite[] playerRenderer;
    void Start()
    {
        if (enableSelectCharacter)
        {
            ChangePlayerInMenu();
        }
        else
        {
            switch (playerSelected)
            {
                case Player.NinjaFrog:
                    spriteRenderer.sprite = playerRenderer[0];
                    animator.runtimeAnimatorController = playerController[0];
                    break;
                case Player.VirtualGuy:
                    spriteRenderer.sprite = playerRenderer[1];
                    animator.runtimeAnimatorController = playerController[1];
                    break;
                case Player.PinkMan:
                    spriteRenderer.sprite = playerRenderer[2];
                    animator.runtimeAnimatorController = playerController[2];
                    break;
                case Player.MaskDude:
                    spriteRenderer.sprite = playerRenderer[3];
                    animator.runtimeAnimatorController = playerController[3];
                    break;
                default:
                    break;
            }
        }
    }

    public void ChangePlayerInMenu()
    {
        switch (PlayerPrefs.GetString("PlayerSelected"))
        {
            case "Frog":
                spriteRenderer.sprite = playerRenderer[0];
                animator.runtimeAnimatorController = playerController[0];
                break;
            case "Virtual":
                spriteRenderer.sprite = playerRenderer[1];
                animator.runtimeAnimatorController = playerController[1];
                break;
            case "Pink":
                spriteRenderer.sprite = playerRenderer[2];
                animator.runtimeAnimatorController = playerController[2];
                break;
            case "Mask":
                spriteRenderer.sprite = playerRenderer[3];
                animator.runtimeAnimatorController = playerController[3];
                break;
            default:
                spriteRenderer.sprite = playerRenderer[0];
                animator.runtimeAnimatorController = playerController[0];
                break;
        }
    }
}
