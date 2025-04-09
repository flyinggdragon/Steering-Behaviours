using UnityEngine;

[CreateAssetMenu(fileName = "Wander", menuName = "Behaviours/Wander")]
public class Wander : Behaviour {
    public override string behaviourName => "Wander";
    public float wanderInteraval = 5f;
    public float strength = 5f;

    private float wanderTimer = 0f;
    private Vector3 direction = Vector3.zero;

    public override Vector3 CalculateForce(Agent agent) {
        wanderTimer -= Time.deltaTime;
        
        if (wanderTimer < 0f) {
            wanderTimer = wanderInteraval;

            float randomDirection = Random.Range(0f, 360f);
            float radians = randomDirection * Mathf.Deg2Rad;

            direction = new Vector3(Mathf.Cos(radians), Mathf.Sin(radians), 0f) * strength;
        }

        return direction - agent.GetVelocity();
    }
}