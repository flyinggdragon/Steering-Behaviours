using UnityEngine;

[CreateAssetMenu(fileName = "Arrival", menuName = "Behaviours/Arrival")]
public class Arrival : Behaviour {
    public override string behaviourName => "Arrival";
    private float targetRadius = 3f;
    public override Vector3 CalculateForce(Agent agent) {
        if (agent.target == null) return Vector3.zero;
        
        Vector3 velocity;
        Vector3 rawDirection = agent.target.position - agent.transform.position;
        float distance = rawDirection.magnitude;

        if (distance <= targetRadius) return -agent.GetVelocity();

        float speed = agent.speed * (distance / targetRadius);
        float clampSpeed = Mathf.Min(speed, agent.speed);

        velocity = rawDirection.normalized * clampSpeed;

        return velocity - agent.GetVelocity();
    }
}