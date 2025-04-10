# Steering Behaviours
Entrega do exercício Steering Behaviours para a cadeira IA Para Jogos, 2025/1.
O projeto foi desenvolvido inteiramente na Unity Engine, versão 6 (6000.0.24f1).

## Steering Behaviours Aplicados:
+ Seek/Flee
    + Seek: O agente se move em direção ao seu alvo.
    + Flee: O agente se afasta de seu alvo. 
+ Pursuit/Evasion
    + Pursuit: O agenta se move em direção ao seu alvo, seguindo o local previsto onde o alvo estará baseado em sua velocidade.
    + Evasion: O agente se afasta de seu alvo, considerando a provável localização do alvo baseado em sua velocidade.
+ Arrival/Departure
    + Arrival: O agente se move em direção ao seu alvo, mas ao se aproximar de seu alvo, atenua sua velocidade para uma aproximação gradual.
    + Departure: O agente se afasta de seu alvo, mas aumenta sua velocidade ao se afastar do alvo.
+ Path Following
    + O agente passa sequencialmente por vários pontos definidos na tela. Na minha implementação ao atingir o último ponto o agente retorna ao primeiro.
+ Wander
    + O agente se move aleatoriamente. Seu vetor de direção muda após uma estipulada quantidade de tempo.
 
## Como utilizar:
O projeto é uma build executável. Baixe-a na seção [releases](https://github.com/flyinggdragon/Steering-Behaviours/releases), descompacte o .zip e execute o .exe.

## Controles: <sup>_(quando houver jogador disponível em cena)_</sup>
- WASD -> Movimentação nos eixos X e Y.
- Espaço -> Alternar entre Behaviours quando múltiplos estiverem disponíves na cena.

## Estrutura:
Foram criadas três classes principais. Agent, Player e Behaviour (ScriptableObject), esta última sendo abstrata.

Cada steering behaviour foi programado em uma classe que herda de Behaviour.
```cs
[CreateAssetMenu(fileName = "Behaviour", menuName = "Behaviours/Behaviour")]
public abstract class Behaviour : ScriptableObject {
    public abstract string behaviourName { get; }
    public abstract Vector3 CalculateForce(Agent agent);
}
```
Exemplo de behaviour programado:
```cs
[CreateAssetMenu(fileName = "Flee", menuName = "Behaviours/Flee")]
public class Flee : Behaviour {
    public override string behaviourName => "Flee";
    public override Vector3 CalculateForce(Agent agent) {
        if (agent.target == null) return Vector3.zero;

        Vector3 direction = (agent.target.position + agent.transform.position).normalized * agent.speed;
        return direction - agent.GetVelocity();
    }
}
```
A classe Agent, no método Update, utiliza o script do(s) Behaviour(s) associado(s) a ele, calcula a direção e aplica a força.
```cs
public class Agent : MonoBehaviour, IMoveable {
    public Vector3 velocity { get; private set; }
    public Vector3 direction;
    //...
    public List<Behaviour> behaviours;
    public Behaviour currentBehaviour;
    public Transform target; // Poderia ser expandido para vários targets.
    //...

    void Update() {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
        
        direction = Vector2.zero;
        direction += currentBehaviour.CalculateForce(this);

        direction = Vector3.ClampMagnitude(direction, force);
        velocity = Vector3.ClampMagnitude(velocity + direction * Time.deltaTime, speed);
        transform.position += velocity * Time.deltaTime;

        if (velocity.sqrMagnitude > 0.001f) transform.up = velocity.normalized;
    }
   
    //...
}
```

A classe Player cuida somente dos controles do jogador, portanto não é relevante à atividade. Também há outros scripts que também não são relavantes à atividade, e sim à UI e outros elementos básicos da aplicação.

## Desafios:
- A mistura de classe abstratas e herdadas com ScriptableObjects foi um pouco esquisita para mim em primeiro lugar, então foi bastante tentativa e erro. Li ocasionalmente documentação do C# e da Unity.
- Programar os vetores dos behaviours foi complicado. Cálculo de vetores definitivamente não era um ponto que estava fresco na minha memória. Também foi muita tentativa e erro e foi bem frustrante.
- Foi necessário entender um pouco mais sobre as propriedades dos vetores da Unity, foi necessário usar algumas delas para conseguir programar tudo.

## Referências:
Reynolds, C. W. (1999). 'Steering Behaviors For Autonomous Characters', in Proceedings of Game Developers Conference 1999, held in San Jose, California. Miller Freeman Game Group, San Francisco, California, pp. 763-782.

## Visual:
A bola azul é o Player. O triângulo amarelo é o Agente. Pontos vermelhos são waypoints.
![image](https://github.com/user-attachments/assets/6ace1825-dabb-45ec-baab-cb872507aa35)

