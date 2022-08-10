using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    public enum MovementType {
        Moving,
        Lerping
    }
    public MovementType movementType = MovementType.Moving;
    public MovementPath myPath;
    public float speed = 1f;
    public float maxDistance = .1f;

    private IEnumerator<Transform> pointInPath;

    // Start is called before the first frame update
    void Start()
    {
        if (myPath == null) {
            Debug.LogError("My path is null");
            return;
        }

        pointInPath = myPath.GetNextPathElement();

        pointInPath.MoveNext();

        if (pointInPath.Current == null) {
            Debug.LogError("Point in path is null");
            return;
        }

        transform.position = pointInPath.Current.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (pointInPath == null || pointInPath.Current == null)
            return;

        if (movementType == MovementType.Moving) {
            transform.position = Vector3.MoveTowards(transform.position, pointInPath.Current.position, Time.deltaTime * speed);
        } else if (movementType == MovementType.Lerping) {
            transform.position = Vector3.Lerp(transform.position, pointInPath.Current.position, Time.deltaTime * speed);
        }

        float distanceSquared = (transform.position - pointInPath.Current.position).sqrMagnitude;
        if (distanceSquared < maxDistance * maxDistance) {
            pointInPath.MoveNext();
            transform.LookAt(pointInPath.Current);
        }
    }
}
