using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PathFollowing", menuName = "Behaviours/Path Following")]
public class PathFollowing : Behaviour {
    public override string behaviourName => "Path Following";
    public List<Vector3> pathPoints;
    public float waypointRadius = 0.5f;
    private int currentIndex = 0;

    private void OnLoad() {
        currentIndex = 0;
    }
    
    public override Vector3 CalculateForce(Agent agent) {
        if (pathPoints.Count == 0) return Vector3.zero;

        if (currentIndex > pathPoints.Count - 1) currentIndex = 0;
        
        Vector3 currentPoint = pathPoints[currentIndex];
        
        Vector3 direction = currentPoint - agent.transform.position;
        float distance = direction.magnitude;

        if (distance <= waypointRadius) {
            currentIndex++;
        }

        return direction - agent.GetVelocity();
    }
}