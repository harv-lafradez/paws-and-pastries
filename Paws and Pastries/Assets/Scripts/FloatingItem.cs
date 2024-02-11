using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingItem : MonoBehaviour
{
    public float floatSpeed = 1f;
    public float floatHeight = 0.5f;

    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float newY = startPos.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
