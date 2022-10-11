using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallGuysMove : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpSpeed = 5f;
    Rigidbody rb;
    Animator animator;
    Vector3 direction;
    Vector3 StartPosition;
    bool isGrounded;
    bool slide;
    AudioSource WinAS;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        StartPosition = transform.position;
        WinAS = GetComponent<AudioSource>();

    }
    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        direction = transform.TransformDirection(x, 0, z);
        if (direction.magnitude > 0)
        {
            animator.SetBool("isRun", true);
        }
        else
        {
            animator.SetBool("isRun", false);
        }
        if (isGrounded)

        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                
                rb.AddForce(new Vector3(0, jumpSpeed, 0), ForceMode.Impulse);
                SoundManagerScript.PlaySound("jump");
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            animator.SetTrigger("isDance");
        }
        if (transform.position.y < -10)
        {
            transform.position = StartPosition;
        }
        if (slide)
        {
            rb.AddForce(direction * 0.1f, ForceMode.VelocityChange);
        }
    }
    private void FixedUpdate()
    {

        rb.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision != null)
        {
            isGrounded = true;
            animator.SetBool("Jump", false);
        }
        if (collision.gameObject.CompareTag("slide"))
        {
            //то 
            slide = true;
        }
        else slide = false;
    }
    private void OnCollisionExit(Collision other)
    {
        
        isGrounded = false;
        animator.SetBool("Jump", true);
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("plate"))
        {
            Destroy(other.gameObject);
        }
        if (other.CompareTag("CheckPoint"))
        {
            StartPosition = transform.position;
            Destroy(other.gameObject);
        }
        if (other.tag == "WinTrigger")
        {
            SoundManagerScript.PlaySound("Win");
            Destroy(other.gameObject);
        }
    }
}





