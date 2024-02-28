using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    // Basic movement variables
    public float runSpeed = 40f;
    public Animator animator;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    // Health variables
    public GameObject Blood;
    private int healthPoints = 3;
    private bool isAlive = true;
    private bool waitTime = false;
    public Text Lives;


    // Dashing variables
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 100f;
    private float dashingTime = 0.2f;
    private float dashingcooldown = 2f;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private TrailRenderer tr;

    // HEARTS 
    public GameObject Heart2;
    public GameObject Heart3;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("speed", Mathf.Abs(horizontalMove));

        if (isDashing)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }

        DestroyObjectWithTag();
        Lives.text = "Health: " + healthPoints.ToString() + "/3";

    }

    void FixedUpdate()
    {   // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
        crouch = false;
    }

    private void DestroyObjectWithTag()
    {
        GameObject targetObject1 = GameObject.FindWithTag("Health1");
        GameObject targetObject2 = GameObject.FindWithTag("Health2");
        GameObject targetObject3 = GameObject.FindWithTag("Health3");

        if (healthPoints == 2)
        {
            if (targetObject1 != null)
                targetObject1.SetActive(false);
        }
        else if (healthPoints == 1)
        {
            if (targetObject2 != null)
                targetObject2.SetActive(false);
        }
        else if (healthPoints == 0)
        {
            if (targetObject3 != null)
                targetObject3.SetActive(false);
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * -dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingcooldown);
        canDash = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemies") && healthPoints > 0 && !waitTime)
        {
            healthPoints -= 1;
            Debug.Log("Current Health: " + healthPoints);
            waitTime = true;
            StartCoroutine(WaitForThreeSeconds());
        }
        else if (healthPoints <= 0)
        {
            isAlive = false;
            Debug.Log(isAlive);

            // Get a reference to the GameManager
            GameManager gameManager = FindAnyObjectByType<GameManager>();

            // Restart game after delay.
            gameManager.GameOver();

            // Particles for death
            Instantiate(Blood, transform.position, Quaternion.identity);

            // Destroy the player.
            Destroy(gameObject);
        }

        if (collision.CompareTag("Potion") && healthPoints < 3)
        {
            healthPoints++;
            Destroy(collision.gameObject);

            if (healthPoints == 3)
            {
                Heart3.SetActive(true);
            }
            else if (healthPoints == 2)
            {
                Heart2.SetActive(true);
            }
        }
        else
        {
            Debug.Log("Health is full");
        }
    }

    private IEnumerator WaitForThreeSeconds()
    {
        // Wait for three seconds
        yield return new WaitForSeconds(0.5f);

        // Set waitTime back to false
        waitTime = false;
    }
}
