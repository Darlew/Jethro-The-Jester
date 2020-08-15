using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;
    public int health;
    public Notification notification;
    public GameManager gameManager;
    public Rigidbody2D rb;
    public Text healthText;

    private void Start()
    {
        healthText.text = health.ToString();
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
        if(health <= 0)
        {
            Destroy(gameObject);
            notification.updateText("You have died!");
            gameManager.EndGame();
        }
        if(rb.position.y <= -11)
        {
            gameManager.EndGame();
        }
    }

    public void takeDamage(int damage)
    {
        health = health - damage;
        healthText.text = health.ToString();
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
