using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5f;
    public float gravity = -9.81f;
    public float jumpHeight = 1.5f;

    CharacterController cc;
    Vector3 velocity;

    void Start() { cc = GetComponent<CharacterController>(); }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");  // A/D, 좌우
        float z = Input.GetAxis("Vertical");    // W/S, 전후

        Vector3 move = transform.right * x + transform.forward * z;
        cc.Move(move * speed * Time.deltaTime);

        if (cc.isGrounded && velocity.y < 0) velocity.y = -2f;

        if (Input.GetButtonDown("Jump") && cc.isGrounded)
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        velocity.y += gravity * Time.deltaTime;
        cc.Move(velocity * Time.deltaTime);
    }
}

