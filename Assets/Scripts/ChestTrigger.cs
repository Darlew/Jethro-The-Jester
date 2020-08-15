using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestTrigger : MonoBehaviour
{
    public Animator animator;
    public GameManager gameManager;
    public Notification notification;

    private void OnTriggerEnter2D()
    {
        animator.SetBool("isOpened", true);
        gameManager.getKey();
        notification.updateText("You've found the key!");
    }
}
