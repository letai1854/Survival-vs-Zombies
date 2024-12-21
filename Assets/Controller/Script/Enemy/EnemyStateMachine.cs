using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    public EnemyState currentState { get; private set; }
    

    public void Initialize(EnemyState newCurrentState)
    {
        currentState = newCurrentState;
        currentState.Enter();
    }
    public void changeState(EnemyState newCurrentState)
    {
        currentState.Exit();
        currentState = newCurrentState;
        currentState.Enter();
    }
}
