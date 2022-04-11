using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperYellow : MonoBehaviour
{

    [SerializeField] float smoothness;
    [SerializeField] GameObject ball;
    //float prevRotation = 0;
    float forceToApply = 0;
    void Start()
    {

    }

    void Update()
    {
        var rotationVector = transform.rotation.eulerAngles;
        if (Input.GetKey("e"))
        {
            //prevRotation = rotationVector.z;
            forceToApply = 1.1f;
            rotationVector.z = Mathf.LerpAngle(rotationVector.z, 30, Time.deltaTime * smoothness);
            //forceToApply = Mathf.Abs(Mathf.Abs(rotationVector.z) - Mathf.Abs(prevRotation));
            transform.eulerAngles = rotationVector;
            if (rotationVector.z < 30)
            {
                rotationVector.z = 30;
                transform.eulerAngles = rotationVector;
            }
        }
        else
        {
            forceToApply = 0.5f;
            rotationVector.z = Mathf.LerpAngle(rotationVector.z, -30, Time.deltaTime * smoothness);
            transform.eulerAngles = rotationVector;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == ball)
        {

            ball.GetComponent<Rigidbody>().AddForce(0, forceToApply * 20, 0, ForceMode.VelocityChange);
        }
    }
}
