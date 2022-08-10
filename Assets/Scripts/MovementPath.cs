using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPath : MonoBehaviour
{
    public enum PathTypes
    {
        Linear,
        loop
    }

    public PathTypes pathType = PathTypes.Linear;
    public int movemenetDirection = 0;
    public int movingTo = 1;
    public Transform[] PathElements;

    private void OnDrawGizmos() {
        if (PathElements == null || PathElements.Length < 2)
            return;

        for (int i = 1; i < PathElements.Length; i++) {
            Gizmos.DrawLine(PathElements[i-1].position, PathElements[i].position);

        }

        if (pathType == PathTypes.loop) {
            Gizmos.DrawLine(PathElements[0].position, PathElements[PathElements.Length - 1].position);
        }
        
    }

    public IEnumerator<Transform> GetNextPathElement() {
        if (PathElements == null || PathElements.Length < 1)
            yield break;

        while (true) {
            yield return PathElements[movingTo];

            if (PathElements.Length == 1)
                continue;

            if (pathType == PathTypes.Linear) {
                if (movingTo <= 0) {
                    movemenetDirection = 1;
                } else if (movingTo >= PathElements.Length - 1) {
                    movemenetDirection = -1;
                }
            }

            movingTo += movemenetDirection;
            
            if (pathType == PathTypes.loop) {
                if (movingTo >= PathElements.Length) {
                    movingTo = 0;
                } else if (movingTo < 0) {
                    movingTo = PathElements.Length - 1;
                }
            }
            
        }
    }

}
