using UnityEngine;

[CreateAssetMenu(fileName = "Behaviour", menuName = "Behaviours/Behaviour")]
public abstract class Behaviour : ScriptableObject {
    public abstract string behaviourName { get; }
    public abstract Vector3 CalculateForce(Agent agent);
}