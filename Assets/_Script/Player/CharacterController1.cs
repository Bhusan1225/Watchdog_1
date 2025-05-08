using Controller;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterController1 : MonoBehaviour
{
    
    public enum CharacterType { Player, Dog }
    
    [Header("CharacterType")]
    public CharacterType Character;

    [Header("Movement")]
    [SerializeField] float rotSpeed = 600f;
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundDistance = 0.4f;
    [SerializeField] LayerMask groundMask;

    [Header("Cameras")]
    [SerializeField] CameraController playerCameraController;
    [SerializeField] CameraController dogCameraController;
    Camera dogsCamera;

    [Header("Animators")]
    [SerializeField] Animator playerAnimator;
    [SerializeField] Animator dogAnimator;

    

    public CharacterModel model;
    public CharacterView view;

    private void Start()
    {
        model = new CharacterModel();
        view = new CharacterView(playerAnimator, dogAnimator);
    }

    private void Update()
    {
        handleMovement();
        view.UpdateAnimation(Character, model.MovementAmount);
        
    }

    void handleMovement()
    {
        // Ground Check
        model.IsGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (model.IsGrounded && model.Velocity.y < 0)
            model.Velocity.y = -5f;

        // Input
        model.MoveX = Input.GetAxisRaw("Horizontal");
        model.MoveZ = Input.GetAxisRaw("Vertical");
        model.MovementAmount = Mathf.Clamp01(Mathf.Abs(model.MoveX) + Mathf.Abs(model.MoveZ));
        var movementInput = new Vector3(model.MoveX, 0, model.MoveZ).normalized;

        // Direction
        //model.MovementDirection = model.IsWatchdogActivated ? dogCameraController.flatRoation * movementInput : playerCameraController.flatRoation * movementInput;


        // Direction
        if (!model.IsWatchdogActivated)
        {
            model.MovementDirection = playerCameraController.flatRoation * movementInput;
        }
        else
        {
            model.MovementDirection = dogCameraController.flatRoation * movementInput;
        }

        if (model.MovementAmount > 0)
        {
            transform.position += model.MovementDirection * model.Speed * Time.deltaTime;
            model.RequiredRotation = Quaternion.LookRotation(model.MovementDirection);
        }

        // Rotation
        transform.rotation = Quaternion.RotateTowards(transform.rotation, model.RequiredRotation, rotSpeed * Time.deltaTime);
    }

    void handleInteraction()
    {
        GameService.Instance.interactionService.RayInteractor(dogsCamera);   // press H
        
    }
}
