using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingMouse : IRotater
{
    private float topRotateSpeed;
    private Transform playerTop;
    private Camera camera;
    private LayerMask layerMask;
    public RotatingMouse(Transform topOfPlayer, float rotateSpeed, Camera camera, LayerMask layerMask)
    {
        playerTop = topOfPlayer;
        topRotateSpeed = rotateSpeed;
        this.camera = camera;
        this.layerMask = layerMask;
    }
    public void Rotate()
    {

        if (Input.GetMouseButton(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100000, layerMask))
            {
                Quaternion rotation = GetDirection(hit);
                RotateTowardsToAim(rotation);
            }

        }
    }

    private void RotateTowardsToAim(Quaternion rotation)
    {
        playerTop.transform.rotation = Quaternion.RotateTowards(playerTop.transform.rotation, rotation, topRotateSpeed * Time.deltaTime);
    }

    private Quaternion GetDirection(RaycastHit hit)
    {
        var dir = (hit.point - playerTop.transform.forward).normalized;
        dir.y = 0;
        var rotation = Quaternion.LookRotation(dir);
        return rotation;
    }
}
