using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomWheel : MonoBehaviour {

    public float ZoomAmount = 0.0f; //With Positive and negative values
    public float MaxToClamp = 10.0f;
    public float ROTSpeed = 10.0f;
     
     void Update() {
        ZoomAmount += Input.GetAxis("Mouse ScrollWheel");
        ZoomAmount = Mathf.Clamp(ZoomAmount, -MaxToClamp, MaxToClamp);
        float translate = Mathf.Min(Mathf.Abs(Input.GetAxis("Mouse ScrollWheel")), MaxToClamp - Mathf.Abs(ZoomAmount));
        transform.Translate(0, 0, translate * ROTSpeed * Mathf.Sign(Input.GetAxis("Mouse ScrollWheel")));
    }


}
