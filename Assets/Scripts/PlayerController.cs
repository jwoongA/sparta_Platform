using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("움직임")]
    public float moveSpeed;
    public float jumpForce;
    private Vector2 curMovementInput;
    
    private Rigidbody rb;

    [Header("화면 설정")]
    public Transform cameraContainer;
    public float minXLook;
    public float maxXLook;
    private float camCurXRot;
    public float lookSensitivity;
    private Vector2 mouseDelta;
    public bool canLook = true;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void LateUpdate()
    {
        if (canLook)
        {
            CameraLook();
        }
    }
    
    public void OnMove(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
        {
            curMovementInput = context.ReadValue<Vector2>();
        }
        else if(context.phase == InputActionPhase.Canceled)
        {
            curMovementInput = Vector2.zero;
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void Move()
    {
        Vector3 dir = transform.forward * curMovementInput.y + transform.right * curMovementInput.x;
        dir *= moveSpeed;
        dir.y = rb.velocity.y;

        rb.velocity = dir;
    }

    void CameraLook()
    {
        // 위아래 (Pitch) 카메라 회전 - X축
        camCurXRot -= mouseDelta.y * lookSensitivity; // Y값은 위아래니까 y 기준
        camCurXRot = Mathf.Clamp(camCurXRot, minXLook, maxXLook);
        cameraContainer.localEulerAngles = new Vector3(camCurXRot, 0, 0);

        // 좌우 (Yaw) 캐릭터 회전 - Y축
        transform.Rotate(Vector3.up * mouseDelta.x * lookSensitivity);
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>();
    }
}
