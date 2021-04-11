using System.Collections;
using UnityEngine;


/// <summary>
/// Attach this to the camera guy
/// </summary>
public class CameraActions : MonoBehaviour
{
    [SerializeField]
    Transform cameraTransform;

    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPos = cameraTransform.localPosition;

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            cameraTransform.localPosition = new Vector3(x, y, originalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        cameraTransform.localPosition = originalPos;
    }

    public IEnumerator TiltUp(Vector3 point, float targetDegrees, float speed)
    {
        while (transform.localEulerAngles.x < targetDegrees)
        {
            transform.RotateAround(point, Vector3.right, speed * Time.deltaTime);

            yield return null;
        }

        transform.RotateAround(point, Vector3.right, targetDegrees - transform.localEulerAngles.x);
    }

    public IEnumerator TiltDown(Vector3 point, float targetDegrees, float speed)
    {
        while (transform.localEulerAngles.x > targetDegrees)
        {
            transform.RotateAround(point, Vector3.right, -(speed * Time.deltaTime));

            yield return null;
        }

        transform.RotateAround(point, Vector3.right, targetDegrees - transform.localEulerAngles.x);
    }
}
