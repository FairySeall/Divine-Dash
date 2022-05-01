using UnityEngine;
using System.Collections;

public class CameraTargetFollowPlayer : MonoBehaviour
{

    public float targetDistance = 0.5F;
    public float smoothTime = 10;
    public Transform target;
    public Vector3 offset;

    private float distance = 1F;

    Transform temptarget = null;

    void LateUpdate()
    {

        transform.LookAt(target);

        distance = Vector3.Distance(transform.position, target.position);


        // reset if its too far away
        if (distance > 7)
        {
            transform.position = target.position - transform.forward;
        }
        else
        {

            if (distance > targetDistance)
            {

                transform.position = Vector3.Slerp(transform.position, new Vector3(
                    target.position.x - (transform.forward.x * targetDistance),
                    target.position.y,
                    target.position.z - (transform.forward.z * targetDistance)
                    ),
                    Time.deltaTime * smoothTime
                );

            }
            else
            {
                // if distance isnt big enough to move the target we still need to adjust the y height every frame
                transform.position = new Vector3(transform.position.x, target.position.y, transform.position.z);

            }

        }


    }


}