using UnityEngine;

[CreateAssetMenu(fileName = "Seek", menuName = "Behaviours/Seek")]
public class Seek : Behaviour {
    public override string behaviourName => "Seek";
    public override Vector3 CalculateForce(Agent agent) {
        if (agent.target == null) return Vector3.zero;

        Vector3 direction = (agent.target.position - agent.transform.position).normalized * agent.speed;
        return direction - agent.GetVelocity();
    }
}