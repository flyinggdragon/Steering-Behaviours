using UnityEngine;

[CreateAssetMenu(fileName = "Flee", menuName = "Behaviours/Flee")]
public class Flee : Behaviour {
    public override string behaviourName => "Flee";
    public override Vector3 CalculateForce(Agent agent) {
        if (agent.target == null) return Vector3.zero;

        Vector3 direction = (agent.target.position + agent.transform.position).normalized * agent.speed;
        return direction - agent.GetVelocity();
    }
}