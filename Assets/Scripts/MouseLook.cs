using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public float sensitivity = 5f;
    public float xAxis, yAxis;
    private Quaternion originalRotation;
    //public Rigidbody rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        originalRotation = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Cursor.lockState = CursorLockMode.Locked;
        // mouse controls
        xAxis += Input.GetAxis("Mouse X") * sensitivity;
        yAxis += Input.GetAxis("Mouse Y") * sensitivity;
        yAxis = Mathf.Clamp(yAxis, -60, 60);

        Quaternion xQuaternion = Quaternion.AngleAxis(xAxis, Vector3.up);
        Quaternion yQuaternion = Quaternion.AngleAxis(yAxis, -Vector3.right);

        transform.localRotation = originalRotation * xQuaternion * yQuaternion;
        //rigidBody.transform.localRotation = originalRotation * yQuaternion;
    }
}
