using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class FPController : MonoBehaviour
{
    // Start is called before the first frame update
    public int wallet;

    [SerializeField] private Transform cameraTarget;
    private Camera mainCamera;
    [SerializeField] private bool invertMouse = false;
    private float verticalRotationLimit;
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private float lookUpConstraint;
    [SerializeField] private float lookDownConstraint;
    [SerializeField] private CharacterController _characterController;
    private Vector3 movement;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private Animator _animator;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        mainCamera= Camera.main;
    }

    // Update is called once per frame
    private void Update()
    {
        Vector2 mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"))*mouseSensitivity;
        float yRotation = transform.rotation.eulerAngles.y + mouseInput.x;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, yRotation, transform.rotation.eulerAngles.z);

        float invert = (!invertMouse) ? -1f : 1f;
        verticalRotationLimit += (mouseInput.y * invert);

        verticalRotationLimit = Mathf.Clamp(verticalRotationLimit, lookDownConstraint, lookUpConstraint);
        cameraTarget.rotation=Quaternion.Euler(verticalRotationLimit,cameraTarget.eulerAngles.y,cameraTarget.eulerAngles.z);

        Vector3 moveForward = transform.forward * Input.GetAxisRaw("Vertical");
        Vector3 moveRight = transform.right * Input.GetAxisRaw("Horizontal");

        
        _characterController.Move(movement * Time.deltaTime);

        float currentSpeed = (Input.GetKey(KeyCode.LeftShift)) ? runSpeed : walkSpeed;
        movement = (moveForward + moveRight).normalized * currentSpeed;
        
        if (movement == Vector3.zero)
        {
            _animator.SetBool("isMoving", false);
        }
        else
        {
            _animator.SetBool("isMoving", true);
            
        }
    }

    void LateUpdate()
    {
        mainCamera.transform.position = cameraTarget.position;
        mainCamera.transform.rotation = cameraTarget.rotation;
    }
}
