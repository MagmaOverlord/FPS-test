using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    //public float speed = 6.0f; //serializing public variables
    public enum RotationAxes {
        MouseXAndY,
        MouseX,
        MouseY
    } //used to make it easier to understand values, can be instead of using integers to define the type
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityHor = 9.0f;
    public float sensitivityVer = 9.0f;

    public float minimumVert = -90.0f;
    public float maximumVert = 90.0f;

    private float rotationX = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(0, sensitivityHor, 0);
        if (axes == RotationAxes.MouseX) {
            //horizontal rotation
            transform.Rotate(0, Input.GetAxis("Mouse X")*sensitivityHor, 0);
        } else if (axes == RotationAxes.MouseY) {
            //vetical rotation
            rotationX -= Input.GetAxis("Mouse Y")*sensitivityVer;
            rotationX = Mathf.Clamp(rotationX, minimumVert, maximumVert);

            float yaw = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(rotationX, yaw, 0);
        } else {
            //both rotations
            rotationX -= Input.GetAxis("Mouse Y")*sensitivityVer;
            rotationX = Mathf.Clamp(rotationX, minimumVert, maximumVert);

            float delta = Input.GetAxis("Mouse X") * sensitivityHor;
            float rotationY = transform.localEulerAngles.y + delta;

            transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
            
        }
    }
}
