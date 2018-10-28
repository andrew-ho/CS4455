using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EricController : MonoBehaviour {

    public float movementSpeed = 10f;
    Vector3 movement;

    Rigidbody rigidbody;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Horizontal");

        MoveCharacter(horizontal, vertical);
    }

    void MoveCharacter(float horizontal,float vertical)
    {
        movement.Set(horizontal, 0, vertical);
        if (horizontal != 0 || vertical != 0)
        {
            rigidbody.MoveRotation(Quaternion.LookRotation(movement));
        }
        movement = movement.normalized * movementSpeed * Time.deltaTime;
        rigidbody.MovePosition(transform.position + movement);
    }
}
