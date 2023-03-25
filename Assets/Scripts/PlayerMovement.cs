using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public GameObject my_camera;

    private float yaw, pitch;
    public float sensitivity;

    public float walk_speed;
    public float sprint_speed;
    
    public float time_since_ran;

    public bool is_sprinting;
    public bool able_to_sprint;

    public KeyCode key_sprint;

    private Rigidbody rb;

    public bool should_be_in_control;

    float speed;

    public bool false_standin;
	
	public float recovery_time;
	public bool is_recovering;

    public float time_active;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {   
        if (!should_be_in_control)
        {
            time_active = 0f;
        }
        if (should_be_in_control)
        {

            // Debug.Log("Stamina: " + Mind.stamina + " MaxStamina: " + Mind.max_stamina);

            time_active += Time.deltaTime;

            //Camera Control
            if (false_standin)
            {
                Cursor.lockState = CursorLockMode.Confined;
            } else
            {
                Cursor.lockState = CursorLockMode.Locked;
                pitch -= Input.GetAxisRaw("Mouse Y") * sensitivity;
                pitch = Mathf.Clamp(pitch, -90, 90);
                yaw += Input.GetAxisRaw("Mouse X") * sensitivity;
                my_camera.transform.localRotation = Quaternion.Euler(pitch, yaw, 0);  
            }

            if (Input.GetKeyDown(key_sprint) && !is_sprinting && able_to_sprint && !is_recovering)
            {
                is_sprinting = true;
                if (is_recovering)
                {
                    is_sprinting = false;
                }
            }
            if (Input.GetKeyUp(key_sprint) && is_sprinting)
            {
                is_sprinting = false;
            }

            if (is_sprinting)
            {

                time_active = 5f;

                speed = sprint_speed;

                if (Input.GetAxisRaw("Vertical") != 0f || Input.GetAxisRaw("Vertical") != 0f)
                {
                    Mind.stamina -= Time.deltaTime * 1f;
                    time_since_ran = 0f;
                }
				
				if (is_recovering)
				{
					is_sprinting = false;
				}

            } else
            {
                speed = walk_speed;
            }
			
			if (Mind.stamina <= 0f)
			{
				is_recovering = true;
			}
			
			if (Mind.stamina >= Mind.max_stamina)
			{
				is_recovering = false;
			}

            time_since_ran += Time.deltaTime;
			
			if (time_since_ran > recovery_time && Mind.stamina < Mind.max_stamina)
			{
				Mind.stamina += Time.deltaTime * 4f;
			}      

        }
    }

    private void FixedUpdate()
    {
        if (should_be_in_control)
        {
            //Movement
            if (false_standin)
            {
                // nothing happens
            } else
            {
                Vector2 axis = new Vector2(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal")) * speed;
                Vector3 forward = new Vector3(-my_camera.transform.right.z, 0, my_camera.transform.right.x);
                Vector3 wishDirection = (forward * axis.x + my_camera.transform.right * axis.y + Vector3.up * rb.velocity.y);
                rb.velocity = wishDirection;
            }
        }
    }
}
