using UnityEngine;

public class EnemyState
{
    protected EnemyStateMachine enemyStateMachine;
    protected Enemy enemy;
    protected string animBoolName;
    protected bool triggercalled;
    protected float stateTimer;
    EnemyState(EnemyStateMachine _enemyStateMachine, Enemy _enemy, string _animBoolName)
    {
        this.enemyStateMachine = _enemyStateMachine;
        this.enemy = _enemy;
        this.animBoolName = _animBoolName;
    }
    public virtual  void Update()
    {

        stateTimer += Time.deltaTime;
    }
    public virtual void Enter()
    {
        triggercalled = false;
        enemy.animator.SetBool(animBoolName, true);

    }
    public virtual void Exit()
    {
        enemy.animator.SetBool(animBoolName, false);;
    }



    
}
