using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] AnimationCurve timeSlowCurve;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Time.timeScale = 0.5f;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            Time.timeScale = 1f;
        }
    }
}
