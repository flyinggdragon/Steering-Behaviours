using UnityEngine;

[CreateAssetMenu(fileName = "Departure", menuName = "Behaviours/Departure")]
public class Departure : Behaviour {
    public override string behaviourName => "Departure";
    private float targetRadius = 3f;
    public override Vector3 CalculateForce(Agent agent) {
        if (agent.target == null) return Vector3.zero;

        Vector3 velocity;
        Vector3 rawDirection = agent.transform.position - agent.target.position;
        float distance = rawDirection.magnitude;

        if (distance >= targetRadius) {
            velocity = rawDirection.normalized * agent.speed;
            return velocity - agent.GetVelocity();
        }

        float speed = agent.speed * (distance / targetRadius);
        float clampSpeed = Mathf.Min(agent.speed, speed);

        velocity = rawDirection.normalized * clampSpeed;

        return velocity - agent.GetVelocity();
    }
}