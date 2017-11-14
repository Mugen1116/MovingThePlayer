using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollision : MonoBehaviour {


    public float minDistance = 1.0f;
    public float maxDistance = 4.0f;
    public float smooth = 10.0f;
    Vector3 dollyDir;
    public float distance;

    //Mouse Zoom
    public float ZoomAmount = 2.0f; //With Positive and negative values
    public float MaxToClamp = 10.0f;
    public float ROTSpeed = 10.0f;

	// Use this for initialization
	void Awake () {
        dollyDir = transform.localPosition.normalized;
        distance = transform.localPosition.magnitude;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 desiredCameraPos = transform.parent.TransformPoint(dollyDir * maxDistance);
        RaycastHit hit;

        if (Physics.Linecast( transform.parent.position, desiredCameraPos, out hit ) ){
            distance = Mathf.Clamp( (hit.distance * 0.9f), minDistance, maxDistance);

        }
        else {
            
            distance = maxDistance;
           
            /*
            //Scroll del Mouse
            ZoomAmount += Input.GetAxis("Mouse ScrollWheel");
            ZoomAmount = Mathf.Clamp(ZoomAmount, -MaxToClamp, MaxToClamp);
            float translate = Mathf.Min(Mathf.Abs(Input.GetAxis("Mouse ScrollWheel")), MaxToClamp - Mathf.Abs(ZoomAmount));
            if ( translate != 0.0f ) {
                distance = translate * ROTSpeed * Mathf.Sign(Input.GetAxis("Mouse ScrollWheel"));
            }
                print(translate);
            //transform.Translate(0, 0, translate * ROTSpeed * Mathf.Sign(Input.GetAxis("Mouse ScrollWheel")));

            */
        }

        transform.localPosition = Vector3.Lerp(transform.localPosition, dollyDir * distance, Time.deltaTime * smooth);
	}
}
