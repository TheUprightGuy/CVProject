using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float MaxedAngle = 90.0f;
    public float RotSpeed = 200.0f;

    Vector3 cachedStartForward = Vector3.zero;
    Vector3 euler;
    // Start is called before the first frame update
    void Start()
    {
        cachedStartForward = this.transform.forward;
        euler = this.transform.localRotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        CamRotation();
    }

    bool ValidateAngle(Quaternion _rot)
    {
        float checkAngle = debugVal = Vector3.Angle(cachedStartForward, _rot * Vector3.forward); //Check the angle from the original forward to the new
             
        return checkAngle <= (MaxedAngle); //If below the allowed angle;
    }

    public float debugVal = 0.0f;
    void CamRotation()
    {
        Vector3 cacheEuler = euler;
        cacheEuler.x +=  Input.GetAxis("Mouse Y") * RotSpeed * Time.deltaTime;
        cacheEuler.y -= Input.GetAxis("Mouse X") * RotSpeed * Time.deltaTime;

        //ValidateAngle(Quaternion.Euler(euler));

        if (ValidateAngle(Quaternion.Euler(euler))) //Is within the camera rot bounds
        {
            this.transform.localRotation = Quaternion.Euler(cacheEuler);
            euler = cacheEuler;
        }

    }
}
