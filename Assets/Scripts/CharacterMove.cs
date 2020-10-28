//hw: make walls on the level

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script / Character Move")]
public class CharacterMove : MonoBehaviour
{
    public float speed = 5.0f;
    public float gravity = -9.8f;
    private CharacterController _controller; 

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(0, speed, 0);
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed); //limits diagonal movement
        movement.y = gravity;

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);


        _controller.Move(movement);
    }
}
