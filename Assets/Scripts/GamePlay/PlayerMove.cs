using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float inputX;
    public float inputZ;
    public Vector3 desiredMoveDirection;
    public bool blockRotationPlayer;
    public float desiredRotationSpeed;
    public Animator anim;
    public float speed;
    public float allowPlayerRotation;
    public Camera cam;
    public Rigidbody rb;
    public bool isGrounded;
    private float verticalVel;
    private Vector3 moveVector;
    Vector3 m_GroundNormal;
    float m_GroundCheckDistance = 0.7f;
    bool m_IsGrounded;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PowerAnim();
        InputMagnitude();
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector3(0, 500,0));
            anim.SetBool("isJump", true);
            anim.applyRootMotion = false;
        }
        CheckGroundStatus();
        if (m_IsGrounded)
        {
            verticalVel = 0;
        }
        else
        {
            verticalVel -= 2;
        }
        if (!isGrounded)
        {
            //rb.AddForce(new Vector3(0, -9.8f, 0));
        }

        moveVector = new Vector3(0, verticalVel, 0);
        //rb.AddForce(desiredMoveDirection * 10);
        
    }

    void PowerAnim() {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            anim.speed = .5f;
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            anim.speed = 1f;
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            anim.speed = 2f;
        }
        else
        {
            anim.speed = 1f;
        }

        if (Input.GetKey(KeyCode.F))
        {
            anim.SetBool("isFreeze", true);
        }
        else
        {
            anim.SetBool("isFreeze", false);
        }

        if (Input.GetMouseButton(0))
        {
            anim.SetBool("isPush", true);
        }
        else
        {
            anim.SetBool("isPush", false);
        }

        if (Input.GetKey(KeyCode.E))
        {
            anim.SetBool("isPull", true);
        }
        else
        {
            anim.SetBool("isPull", false);
        }
    }

    void PlayerMoveAndRotation()
    {
        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");
        var forward = cam.transform.forward;
        var right = cam.transform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        desiredMoveDirection = forward * inputZ + right * inputX;

        if (!blockRotationPlayer)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection), desiredRotationSpeed);
        }


    }

    void InputMagnitude()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        inputZ = Input.GetAxisRaw("Vertical");

        anim.SetFloat("inputZ", inputZ, 0.0f, Time.deltaTime * 2f);
        anim.SetFloat("inputX", inputX, 0.0f, Time.deltaTime * 2f);

        speed = new Vector2(inputX, inputZ).sqrMagnitude;

        if (speed > allowPlayerRotation)
        {
            anim.SetFloat("inputMagnitude", speed, 0.0f, Time.deltaTime);
            PlayerMoveAndRotation();
        }
        else if (speed < allowPlayerRotation || speed == 0)
        {
            anim.SetFloat("inputMagnitude", speed, 0.0f, Time.deltaTime);
        }

    }

    void CheckGroundStatus()
    {
        RaycastHit hitInfo;
#if UNITY_EDITOR
        // helper to visualise the ground check ray in the scene view
        //Debug.DrawLine(transform.position + (Vector3.up * 0.1f), transform.position + (Vector3.up * 0.1f) + (Vector3.down * m_GroundCheckDistance));
#endif
        // 0.1f is a small offset to start the ray from inside the character
        // it is also good to note that the transform position in the sample assets is at the base of the character
        if (Physics.Raycast(transform.position + (Vector3.up * 0.1f), Vector3.down, out hitInfo, m_GroundCheckDistance))
        {
            m_GroundNormal = hitInfo.normal;
            m_IsGrounded = true;
            isGrounded = m_IsGrounded;
            //   m_Animator.applyRootMotion = true;
            anim.applyRootMotion = true;
        }
        else
        {
            m_IsGrounded = false;
            m_GroundNormal = Vector3.up;
            isGrounded = m_IsGrounded;
            anim.SetBool("isJump", false);
            // m_Animator.applyRootMotion = false;
            anim.applyRootMotion = false;
        }
    }
}
