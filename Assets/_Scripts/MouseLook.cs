using UnityEngine;
using System.Collections;

[AddComponentMenu("Camera/Mouse Look")]
public class MouseLook : MonoBehaviour {

    private enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    [SerializeField]private RotationAxes axes = RotationAxes.MouseXAndY;
    [SerializeField]private float sensitivityX = 15.0f;
    [SerializeField]private float sensitivityY = 15.0f;
    [SerializeField]private float minimumX = -360.0f;
    [SerializeField]private float maximumX = 360.0f;
    [SerializeField]private float minimumY = -60.0f;
    [SerializeField]private float maximumY = 60.0f;
    private float rotationY = 0.0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update ()
    {
        if (axes == RotationAxes.MouseXAndY)
        {
            float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);

            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        }
        else if (axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
        }
        else
        {
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);

            transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
        }
    }
}