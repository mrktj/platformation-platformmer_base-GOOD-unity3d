using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float jumpSpeed = 60.0F;
    public float bounceAmount = 10;
    public float gravity = 20.0F;
    public float speed = 6;
    public float walkSpeed = 6;
    public float runSpeed = 14;
    public float acceleration = 30;
    private float currentSpeed;
    private float targetSpeed;
    private float animSpeed = 8;
    private Animator animator;
    private bool inclined = false;
    private bool isBounced = false;
    private bool isJumping = false;
    private int jumpCount;
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    void Start()
    {
        animator = GetComponent<Animator>();
        transform.eulerAngles = Vector3.up * 90;
    }

    void Update()
    {
        controller = GetComponent<CharacterController>();
         
        animSpeed = IncrementTowards(animSpeed, Mathf.Abs(targetSpeed), acceleration);
        animator.SetFloat("speed", animSpeed);

        if (controller.isGrounded)
        {
            jumpCount = 0;
            isJumping = false;

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection *= speed;

            if (inclined == false)
            {
                speed = (Input.GetButton("Run")) ? runSpeed : walkSpeed;
            } 
            else
            {
                speed = 5;
            }

            //Quaternion rotate = Quaternion.Euler(moveDirection);

            if (moveDirection != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(moveDirection);
                float dirH = Input.GetAxisRaw("Horizontal");
                float dirV = Input.GetAxisRaw("Vertical");

                if (dirH != 0)
                {
                    Debug.Log("H");
                    targetSpeed = Input.GetAxisRaw("Horizontal") * speed;
                } 
                else if (dirV != 0)
                {
                    Debug.Log("V");
                    targetSpeed = Input.GetAxisRaw("Vertical") * speed * 2F;
                } 
                else
                    {
                        targetSpeed = 0;
                    }
            }





//
//            if (dirH != 0 && dirV != 0)
//            {
//                Debug.Log("TRAVELING AT AN ANGLE");
//                if (dirV > 0)
//                {
//                    transform.eulerAngles = (dirH > 0) ? Vector3.up * 135 : Vector3.up * 45;
//                }
//                else
//                {
//                    transform.eulerAngles = (dirH > 0) ? Vector3.up * -135 : Vector3.up * -45;
//                }
//
//                targetSpeed = Input.GetAxisRaw("Horizontal") * speed;
//            }
//            else if (dirH != 0)
//            {
//                Debug.Log("H");
//                transform.eulerAngles = (dirH > 0) ? Vector3.up * 180 : Vector3.zero;
//                targetSpeed = Input.GetAxisRaw("Horizontal") * speed;
//            } 
//            else if (dirV != 0)
//            {
//                Debug.Log("V");
//                transform.eulerAngles = (dirV > 0) ? Vector3.up * 90 : Vector3.up * -90;
//                targetSpeed = Input.GetAxisRaw("Vertical") * speed * 1.5F;
//            } 
//            else
//            {
//                targetSpeed = 0;
//            }

        }

        if (Input.GetKeyDown("space"))
        {
            if (controller.isGrounded)
            {
                moveDirection.y = jumpSpeed;
            } 
            else
            {
                if (jumpCount < 1)
                {
                    isJumping = true;
                    moveDirection.y = jumpSpeed * 1.5F;
                    jumpCount++;
                } 
                else
                {
                    return;
                }
            }
        }

        currentSpeed = IncrementTowards(currentSpeed, targetSpeed, acceleration);

        moveDirection.y -= gravity * Time.deltaTime;

        if (isBounced)
        {
            moveDirection.y = jumpSpeed * 3;
            isBounced = false;
        }
       
        controller.Move(moveDirection * Time.deltaTime);
    }

    private float IncrementTowards(float m, float target, float a)
    {
        if (m == target)
        {
            return m;
        } 
        else
        {
            float dir = Mathf.Sign(target - m);
            m += a * Time.deltaTime * dir;
            return (dir == Mathf.Sign(target - m)) ? m : target;
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        inclined = (hit.normal.y < 0.99) ? true : false; 

        GameObject currentObject = hit.gameObject;
        
        if (currentObject.tag == "Springboard")
        {
            isBounced = true;

            Debug.Log(currentObject.transform);

            //currentObject.MoveTo(new Vector3(-1.320549F, -6.143249F, 8.285074F), 0.15F, 0, EaseType.easeOutBack);
        }

        if (hit.gameObject.tag == "Portal")
            Debug.Log("CHECKPOINT #1");
    }
}