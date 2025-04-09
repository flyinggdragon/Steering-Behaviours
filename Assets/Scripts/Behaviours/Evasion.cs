using UnityEngine;

[CreateAssetMenu(fileName = "Evasion", menuName = "Behaviours/Evasion")]
public class Evasion : Behaviour {
    public override string behaviourName => "Evasion";

    public override Vector3 CalculateForce(Agent agent) {
        if (agent.target == null) return Vector3.zero;
        
        Vector3 targetPosition = agent.target.position;
        Vector3 targetVelocity = agent.target.GetComponent<IMoveable>().velocity;

        Vector3 futurePosition = targetPosition + targetVelocity * 1.5f;

        Vector3 direction = (agent.transform.position - futurePosition).normalized * agent.speed;
        return direction - agent.GetVelocity();
    }
}