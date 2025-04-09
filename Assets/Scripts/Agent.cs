using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour, IMoveable {
    public Vector3 velocity { get; private set; }
    public Vector3 direction;
    public float speed = 5f;
    public float force = 10f;
    public List<Behaviour> behaviours;
    public Behaviour currentBehaviour;
    public int behaviourIndex = 0;
    public Transform target;
    //public List<Player> targets;

    void Start() {
        
    }

    void Update() {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
        
        direction = Vector2.zero;
        direction += currentBehaviour.CalculateForce(this);

        direction = Vector3.ClampMagnitude(direction, force);
        velocity = Vector3.ClampMagnitude(velocity + direction * Time.deltaTime, speed);
        transform.position += velocity * Time.deltaTime;

        if (velocity.sqrMagnitude > 0.001f) transform.up = velocity.normalized;
    }

    public Vector3 GetVelocity() => velocity;   
}