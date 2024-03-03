using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private float moveSpeed = 7.0f;
    protected bool idling = true, running = false, jumping = false ;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField]private GameObject go;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;



    // Start is called before the first frame update
    void Start()
    {
        Init();

    }

    // Update is called once per frame
    void Update()
    {

        Walking();
        Jumping();

        var input = Input.inputString;

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            if (isGrounded())
            {
                SetAnimation(false, true, false);
            }
            
            if(!(go.transform.position.x<=-9.00001))
            {
                go.transform.Translate(Vector2.right * Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime);
            }
            
          

            /*
            idling = false;
            running = true;
            jumping = false;

            animator.SetBool("Idling", idling);
            animator.SetBool("Running", running);
            animator.SetBool("Jumping", jumping);
            */

            if (input.Equals("d"))
            {
                sprite.flipX = false;
            }
            else if (input.Equals("a"))
            {
                sprite.flipX = true;
            }
        }

        else if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {

            SetAnimation(false, false, true);
            rb.velocity = new Vector2(rb.velocity.x, 7);
            

            /*
            jumping = true;
            idling = false;
            running = false;
            animator.SetBool("Idling", idling);
            animator.SetBool("Jumping", jumping);
            animator.SetBool("Running", running);
            */

        }


        else
        {
            if (isGrounded())
            {
                Debug.Log(isGrounded());
                SetAnimation(true, false, false);

            }
            else
            {
                SetAnimation(false, false, true);
            }
           
            /*

                idling = true;
                running = false;
                jumping = false;
                animator.SetBool("Idling", idling);
                animator.SetBool("Running", running);
                animator.SetBool("Jumping", jumping);
            */



            
        }

   

    }


    public void Init()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        go = GameObject.FindWithTag("Player");
        rb = go.GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        moveSpeed = 7.0f;

    }

    void SetAnimation(bool idling, bool running, bool jumping)
    {
        animator.SetBool("Idling", idling);
        animator.SetBool("Running", running);
        animator.SetBool("Jumping", jumping);
    }

    void Walking()
    {
        if (running)
        {
            go.transform.Translate(Vector2.right * Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime);

            //go.GetComponent<Rigidbody2D>().velocity=new Vector2(go.GetComponent<Rigidbody2D>().velocity.x,2);
        }
    }


    void Jumping()
    {
        if (jumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, 4);
        }

    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

    }

}


