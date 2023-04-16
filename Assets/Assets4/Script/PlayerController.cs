using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 
public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public float jumpForce;
    public bool IsLockMouse;
    private Animator m_Animator;   
    private Transform cam;
    float turnSmoothVelocity;
    private float horizontal;
    private float vertical;
    private float turnSmoothTime = 0.1f;
    private bool canjump = true;
    private Rigidbody rb;    

    void Start()
    {

        cam = Camera.main.transform;
        rb = GetComponent<Rigidbody>();
        m_Animator = GetComponent<Animator>();

        if (IsLockMouse)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }  
   
    void Update()
    {
       
        Jump();  
    }    
    
    public void Jump()
    { 
        
        if(Input.GetKeyDown(KeyCode.Space) && canjump)
        {
            rb.AddForce(Vector3.up * (jumpForce));
            canjump = false;
        }

        if (rb.velocity.y<=-1)
        {
            rb.AddForce(-Vector3.up);
       }
    } 
     
     

    private void FixedUpdate() 
    { 
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if(rb==null)
            rb = GetComponent<Rigidbody>();
        if(m_Animator==null)
            m_Animator = GetComponent<Animator>();
        Vector3 dir = new Vector3(horizontal, 0f, vertical).normalized;
        if (dir.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f); 
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            rb.velocity = rb.velocity.y * Vector3.up + moveDir * speed ;
        }
        else
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
        }

        if(canjump)
        {
            if (horizontal != 0 || vertical != 0)
            {
                m_Animator.SetBool("Run", true);
            }
            else
            {
                m_Animator.SetBool("Run", false);
            }
        }  
    }
    
    private void LateUpdate() 
    {
        transform.position = rb.transform.position; 
    }

    private void OnCollisionEnter(Collision collision) {
        
        if(collision.gameObject.CompareTag("Ground"))
        {
            m_Animator.SetBool("Jump", false);
            canjump = true;
           
        }
    } 
    
}
