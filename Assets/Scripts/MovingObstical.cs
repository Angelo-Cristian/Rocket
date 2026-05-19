using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstical : MonoBehaviour
{
    Vector3 startingPosition;
    public Vector3 movingPosition;
    float factor; 
    public float period;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(period > Mathf.Epsilon)
        {
            float cycles = Time.time / period;
            const float tau = Mathf.PI * 2;
            float sin = Mathf.Sin(cycles * tau);
            factor = (sin + 1) / 2;

            Vector3 offset = movingPosition * factor;
            transform.position = startingPosition + offset;
        }
        
    }
}
