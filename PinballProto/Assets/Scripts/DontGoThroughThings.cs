using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontGoThroughThings : MonoBehaviour
{
    // Careful when setting this to true - it might cause double
    // events to be fired - but it won't pass through the trigger
    public bool sendTriggerMessage = false;

    //public LayerMask layerMask = -1; //make sure we aren't in this layer
    public float skinWidth = 0.1f; //probably doesn't need to be changed

    private float MimumExtent;
    private float partialExtent;
    private float sqrMinimumExtent;
    private Vector3 previousPosition;
    private Rigidbody myRigidbody;
    private Collider myCollider;

    //initialize values
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        myCollider = GetComponent<Collider>();
        previousPosition = myRigidbody.position;
        MimumExtent = Mathf.Min(Mathf.Min(myCollider.bounds.extents.x, myCollider.bounds.extents.y), myCollider.bounds.extents.z);
        partialExtent = MimumExtent * (1.0f - skinWidth);
        sqrMinimumExtent = MimumExtent * MimumExtent;
    }

    void Update()
    {
        //have we moved more than our Mimum extent?
        Vector3 movementThisStep = myRigidbody.position - previousPosition;
        float movementSqrMagnitude = movementThisStep.sqrMagnitude;

        if (movementSqrMagnitude > sqrMinimumExtent)
        {
            float movementMagnitude = Mathf.Sqrt(movementSqrMagnitude);
            RaycastHit hitInfo;

            if (Physics.Raycast(previousPosition, movementThisStep, out hitInfo, movementMagnitude))
            {
                if (!hitInfo.collider.isTrigger)
                    myRigidbody.position = hitInfo.point - (movementThisStep / movementMagnitude) * partialExtent;
            }
        }
        previousPosition = myRigidbody.position;
    }
}
