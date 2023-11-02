using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementKeyboard : IMover
{
    PlayerController playerController;
    private readonly float movementSpeed;
    private readonly float rotateSpeed;
    public MovementKeyboard(PlayerController playerController, float movementSpeed, float rotateSpeed)
    {
        this.playerController = playerController;
        this.movementSpeed = movementSpeed;
        this.rotateSpeed = rotateSpeed;
    }


    public void Movement()
    {
        float rotate = Input.GetAxis("Horizontal");
        float move = Input.GetAxis("Vertical");
        playerController.transform.Translate(Vector3.forward * move * movementSpeed * Time.deltaTime);
        playerController.transform.Rotate(Vector3.up, rotateSpeed * rotate * Time.deltaTime);
    }


}
