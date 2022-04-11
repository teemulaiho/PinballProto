using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBall : MonoBehaviour
{
    [SerializeField] GameObject ball;
    [SerializeField] float smoothness;
    Vector3 currentpos;

    void Start()
    {
        
    }

    void Update()
    {
        currentpos = transform.position;
        currentpos.x = Mathf.Lerp(currentpos.x, ball.transform.position.x/3, Time.deltaTime * smoothness);
        currentpos.y = Mathf.Lerp(currentpos.y, ball.transform.position.y, Time.deltaTime * smoothness);
        transform.position = currentpos;

		if (ball.transform.position.y < -17)
		{
            ball.transform.position = new Vector3(7f, 0f, 0f);
            ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
