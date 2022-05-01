using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public bool reset = false;
    float cameraTimer = 0.05f;
    float rechargedTimer = 0.05f;
    public bool flip = false;
    public bool mirror = false;
    public bool remirror = false;
    public float distance = 1f;

    void FixedUpdate()
    {

        distance = Vector3.Distance(transform.position, target.position);

        if (distance > 13)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }

        if (reset == true)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            cameraTimer -= Time.deltaTime;

            if(cameraTimer <= 0)
            {
                reset = false;
                cameraTimer = rechargedTimer;
            }
        }

        if (flip == true)
        {
            transform.Rotate(0, 0 * Time.deltaTime, 180);
            flip = false;
        }

        if (mirror == true)
        {
            transform.Rotate(0, 180, 0);
            Vector3 change = transform.position;
            change.z += 20f;
            transform.position = change;
            mirror = false;
        }

        if (remirror == true)
        {
            transform.Rotate(0, -180, 0);
            Vector3 change = transform.position;
            change.z -= 20f;
            transform.position = change;
            remirror = false;
        }
    }
}
