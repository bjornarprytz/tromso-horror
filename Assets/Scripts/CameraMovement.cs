using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    bool moveUp = false;

    [SerializeField]
    float rotationSpeed = 40f;

    [SerializeField]
    float topDownDegrees = 70f;
    [SerializeField]
    float lookingInDegrees = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            moveUp = !moveUp;
        }

        if (moveUp)
        {
            transform.RotateAround(Vector3.right, Vector3.right, rotationSpeed * Time.deltaTime);
        }
        else
        {
            transform.RotateAround(Vector3.right, Vector3.right, -rotationSpeed * Time.deltaTime);
        }

        ClampRotation();
    }

    private void ClampRotation()
    {
        if (transform.localEulerAngles.x > topDownDegrees 
        ||  transform.localEulerAngles.x < lookingInDegrees)
        {
            var correction = moveUp
                ? topDownDegrees - transform.localEulerAngles.x 
                : lookingInDegrees - transform.localEulerAngles.x;

            transform.RotateAround(Vector3.right, Vector3.right, correction);
        }
    }
}
