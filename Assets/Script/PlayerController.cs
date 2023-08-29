using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
	public GameObject cameraRig;

    public Vector3 jump;
    public float jumpForce = 3.0f;
    public float sprintJumpForce = 9.0f;
    float normalSpeed = 5.0f;
    float sprintSpeed = 10.0f;

    KeyCode foward = KeyCode.W;
    KeyCode backward = KeyCode.S;
    KeyCode left = KeyCode.A;
    KeyCode right = KeyCode.D;
    KeyCode jumpKey = KeyCode.Space;
    KeyCode sprint = KeyCode.CapsLock;
    
    // State
    private bool isGrounded;
    private bool isSprinting;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        isSprinting = false;
    }
    void OnCollisionStay()
    {
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (Input.GetKey(foward) && isGrounded)
        {
            MovementForce(Vector3.forward);
        }
        if (Input.GetKey(backward) && isGrounded)
        { 
            MovementForce(Vector3.back);
        }
        if (Input.GetKey(left) && isGrounded) { 
            MovementForce(Vector3.left);
        }
        if (Input.GetKey(right) && isGrounded)
        {
            MovementForce(Vector3.right);
        }

		
		TrackCameraRotation();

        
        if (Input.GetKey(jumpKey) && isGrounded)
        {
            if (isSprinting)
            {
                rb.AddForce(jump * sprintJumpForce, ForceMode.Impulse);
            }
            {   
                rb.AddForce(jump * jumpForce , ForceMode.Impulse);
                isGrounded = false;
            }
        }

        if (Input.GetKey(foward) && Input.GetKey(sprint) && isGrounded)
        {
            LimitSpeed(sprintSpeed);
            isSprinting = true;
            if (Input.GetKey(foward) && Input.GetKey(sprint) && isGrounded && Input.GetKey(jumpKey))
            {
                Debug.Log("Jumping while sprinting");
                rb.AddForce(jump * sprintJumpForce , ForceMode.Impulse);
            }
        }
        else
        {
            LimitSpeed(normalSpeed);
            isSprinting = false;
        }
        
    }

	void LimitSpeed(float maxSpeed)
	{
		Rigidbody rb = GetComponent<Rigidbody>();
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
	}

    void MovementForce(Vector3 vector3)
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(6f * vector3 * Time.deltaTime * normalSpeed, ForceMode.Impulse);
        Debug.Log("Force added to " + vector3 + " direction");
    }	

	void TrackCameraRotation()
    {
        if (cameraRig != null)
        {
            transform.rotation = Quaternion.Euler(0, cameraRig.transform.rotation.eulerAngles.y, 0);
        }
    }

}
