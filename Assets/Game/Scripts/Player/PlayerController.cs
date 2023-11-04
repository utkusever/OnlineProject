using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] float rotateSpeed;
    [SerializeField] float topRotateSpeed;
    [SerializeField] Transform top;
    [SerializeField] LayerMask groundLayer;

    private IMover Imover;
    private IRotater IRotater;

    private Camera cameraMain;

    // Start is called before the first frame update
    void Start()
    {
        cameraMain = Camera.main;
        Imover = new MovementKeyboard(this, movementSpeed, rotateSpeed);
        IRotater = new RotatingMouse(top, topRotateSpeed, cameraMain, groundLayer);
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsOwner)
        {
            return;
        }

        Imover.Movement();
        IRotater.Rotate();
    }

    public Ray GetMouseRay()
    {
        return cameraMain.ScreenPointToRay(Input.mousePosition);
    }
}