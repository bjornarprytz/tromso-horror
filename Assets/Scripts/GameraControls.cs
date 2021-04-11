using UnityEngine;

public class GameraControls : MonoBehaviour
{
    [SerializeField]
    CameraActions cameraActions;

    [SerializeField]
    GameObject sceneRail;

    Coroutine moveUp;
    Coroutine moveDown;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (moveUp == null)
            {
                if (moveDown != null)
                {
                    StopCoroutine(moveDown);
                    moveDown = null;
                }


                moveUp = StartCoroutine(cameraActions.TiltUp(sceneRail.transform.position, 60f, 40f));
            }
            else
            {
                StopCoroutine(moveUp);
                moveUp = null;

                moveDown = StartCoroutine(cameraActions.TiltDown(sceneRail.transform.position, 5f, 40f));
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(cameraActions.Shake(0.1f, 0.05f));
        }
    }
}
