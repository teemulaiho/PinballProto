using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperMain : MonoBehaviour
{
    [SerializeField] float smoothness;
    [SerializeField] GameObject ball;
    [SerializeField] bool side;
    float forceToApply = 0;
    int targetRot;
    KeyCode inputKey;
    
    void Start()
    {
        if (side)
        {
            targetRot = -30;
		}
		else
		{
            targetRot = 30;
        }

		if (this.tag == "Blue")
		{
            inputKey = KeyCode.Q;
		}
		else if (this.tag == "Red")
        {
            inputKey = KeyCode.W;
        }
        else if (this.tag == "Yellow")
        {
            inputKey = KeyCode.E;
		}
		else
		{
            inputKey = KeyCode.R;
        }
    }

    void Update()
    {
        var rotationVector = transform.rotation.eulerAngles;
        if (Input.GetKey(inputKey))
		{
            forceToApply = 1.1f;
            rotationVector.z = Mathf.LerpAngle(rotationVector.z, targetRot, Time.deltaTime * smoothness);
            transform.eulerAngles = rotationVector;
        }
		else
		{
           forceToApply = 0.5f;
           rotationVector.z = Mathf.LerpAngle(rotationVector.z, targetRot * -1, Time.deltaTime * smoothness);
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