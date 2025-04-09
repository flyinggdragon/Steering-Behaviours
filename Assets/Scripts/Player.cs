using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour, IMoveable {
    public float moveSpeed = 5f;
    public Vector3 velocity { get; private set; }
    public Text behaviourName;
    private Agent agent;

    private void Start() {
        agent = FindFirstObjectByType<Agent>();
    }

    private void Update() {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        velocity = new Vector3(moveX, moveY, 0f).normalized;

        transform.Translate(velocity * moveSpeed * Time.deltaTime);

        if (agent.behaviours.Count > 1) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                SwitchBehaviours();
            }
        } else {
            behaviourName.text = agent.currentBehaviour.behaviourName;
        }
    }

    private void SwitchBehaviours() {
        agent.behaviourIndex = (agent.behaviourIndex + 1) % agent.behaviours.Count;
        agent.currentBehaviour = agent.behaviours[agent.behaviourIndex];

        behaviourName.text = agent.currentBehaviour.behaviourName;
    }
}