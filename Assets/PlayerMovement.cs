using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private CharacterController _controller;
    public float speed = 12f;
    Vector3 velocity;
    float gravity = -9.81f;
    public  bool _jump;
    float JumpHeight = 2F;

    //GroundCheck
    public LayerMask GroundLayers;
    public  bool Grounded;
    float GroundedRadius = 1f;
    float GroundedOffset = .1f;
    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        GroundedCheck();
        Jump();
        if (Grounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        _controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        _controller.Move(velocity * Time.deltaTime);
    }



    private void GroundedCheck()
    {
        Vector3 spherePosition = new Vector3(transform.position.x, transform.position.y - GroundedOffset, transform.position.z);
        Grounded = Physics.CheckSphere(spherePosition, GroundedRadius, GroundLayers, QueryTriggerInteraction.Ignore);
    }


    public void Jump()
    {
        _jump = Input.GetKey(KeyCode.Space) ? true : false;
        // Jump
        if (_jump && Grounded)
        {
            // the square root of H * -2 * G = how much velocity needed to reach desired height
            velocity.y = Mathf.Sqrt(JumpHeight * -2f * gravity);

        }




    }
}
