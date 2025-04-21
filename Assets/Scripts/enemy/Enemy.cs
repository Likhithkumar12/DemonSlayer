using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D rb {get; private set;}
    public Animator animator {get; private set;}
    public EnemyStateMachine enemyStateMachine {get; private set;}
    void Start()
    {
        enemyStateMachine = new EnemyStateMachine();
        
    }


    void Update()
    {
        enemyStateMachine.currentState.Update();
        
    }
}
