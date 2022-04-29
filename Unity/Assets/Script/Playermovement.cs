using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;

    [SerializeField] private bool isGrounded;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity;


    private Vector3 moveDirection;
    private Vector3 velocity;
    private Animation anim;
    private Animator animator;


    private CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        // Komponenten zum Lesen
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animation>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        // Entscheiden, ob eine Landung erfolgen soll oder nicht
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);
        
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // w oder s für vorwärts oder rückwärts gerichtet
        float moveZ = Input.GetAxis("Vertical");
        float moveX = Input.GetAxis("Horizontal");
        // Richtung der Bewegung
        moveDirection = new Vector3(moveX, 0, moveZ);
        // Bewegung in Richtung der Kamera
        moveDirection = transform.TransformDirection(moveDirection);

        // Wenn am Boden
        if (isGrounded)
        {
            // Animation einrichten
            if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift) )
            {
                animator.SetBool("Iswalking", true);
                animator.SetBool("Isrunning", false);
                animator.SetBool("Direktrunning", false);

                walk();
            }
            else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
            {
                animator.SetBool("Isrunning", true);
                animator.SetBool("Direktrunning", true);
                
                //animator.SetBool("Iswalking", false);
                run();
            }
            else if (moveDirection == Vector3.zero )
            {
                animator.SetBool("Isrunning", false);
                animator.SetBool("Iswalking", false);
                animator.SetBool("Direktrunning", false);

                Idle();
            }

        }
        

        controller.Move(moveDirection * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void Idle()
    {

    }
    private void walk()
    {
        moveDirection *= walkSpeed;
        
    }
    private void run()
    {
        moveDirection *= runSpeed;
    }
}
