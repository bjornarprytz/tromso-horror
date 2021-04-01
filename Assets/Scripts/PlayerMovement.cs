using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float speed = 0.03f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            direction.z += 1f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            direction.x -= 1f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            direction.z -= 1f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            direction.x += 1f;
        }

        transform.position = transform.position + (direction * speed);
    }
}
