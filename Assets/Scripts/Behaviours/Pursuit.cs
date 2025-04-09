using UnityEngine;

[CreateAssetMenu(fileName = "Pursuit", menuName = "Behaviours/Pursuit")]
public class Pursuit : Behaviour {
    public override string behaviourName => "Pursuit";
    public override Vector3 CalculateForce(Agent agent) {
        if (agent.target == null) return Vector3.zero;
        
        Vector3 targetPosition = agent.target.position;
        Vector3 targetVelocity = agent.target.GetComponent<IMoveable>().velocity;

        Vector3 futurePosition = targetPosition + targetVelocity * 1.5f;

        Vector3 direction = (futurePosition - agent.transform.position).normalized * agent.speed;
        return direction - agent.GetVelocity();
    }
}