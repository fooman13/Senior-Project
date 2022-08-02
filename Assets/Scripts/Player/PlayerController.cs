using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float mouseSensitivityX = 250f;
    public float mouseSensitivityY = 250f;
    public float walkSpeed = 4f;
    public float SprintSpeed = 12f;
    private float SprintTimer = 3f;
    private float CoolDown = 6f;
    private bool SprintEnabled = true;
    public float jumpForce = 220f;
    public LayerMask groundedMask;

    public GameObject phud;
    public GameObject dhud;

    Transform cameraT;
    float verticalLookRotation;

    Vector3 moveAmount;
    Vector3 smoothMoveVelocity;

    bool grounded;

    void Start()
    {
        cameraT = Camera.main.transform;

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivityX);
        verticalLookRotation += Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivityY;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -60, 60);
        cameraT.localEulerAngles = Vector3.left * verticalLookRotation;

        Vector3 moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
    
        Vector3 targetMoveAmount = moveDir * walkSpeed;
        moveAmount = Vector3.SmoothDamp(moveAmount, targetMoveAmount, ref smoothMoveVelocity, .15f);

       // if(!SprintEnabled)
       // {
       //     Debug.Log("Sprint is disabled");
       //     CoolDown -= Time.deltaTime;
       //     if(CoolDown<=0)
       //     {
       //         SprintEnabled = true;
       //         SprintTimer = 3f;
       //         CoolDown = 6f;
       //     }
       // }

        if(Input.GetButton("Run"))
        {
            if(SprintEnabled)
            {
                Debug.Log("Sprint is enabled");
                if(grounded)
                {
                    targetMoveAmount = moveDir * SprintSpeed;
                    moveAmount = Vector3.SmoothDamp(moveAmount, targetMoveAmount, ref smoothMoveVelocity, .15f);
                    //SprintTimer -= Time.deltaTime;
                    //if (SprintTimer <= 0)
                    //    SprintEnabled = false;
                }
            }
            
        }

        if(Input.GetButtonDown("Jump"))
        {
            if(grounded)
            GetComponent<Rigidbody>().AddForce(transform.up * jumpForce);
        }
        grounded = false;
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, (1 + 0.1f), groundedMask))
            grounded = true;
    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.TransformDirection(moveAmount) * Time.fixedDeltaTime);
    }
}
