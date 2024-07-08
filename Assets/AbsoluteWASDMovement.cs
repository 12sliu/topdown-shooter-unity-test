using System;
using UnityEngine;

public class AbsoluteWASDMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity = new Vector3(0,0,0);
    public float playerAcceleration = 2.0f;
    public float playerMaxVelocity = 1.0f;

    void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
    }

    void Update()
    {
        // MODIFICATION
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        playerVelocity = playerVelocity + new Vector3(
            move.x * Time.deltaTime * playerAcceleration, 
            move.y * Time.deltaTime * playerAcceleration,
            0); 
        
        // caps playerVelocity
        playerVelocity = playerVelocity.normalized * Math.Min(playerVelocity.magnitude, playerMaxVelocity);
        controller.Move(playerVelocity * Time.deltaTime);        
        // controller.Move(new Vector3(1, 0, 1));
    }    
}