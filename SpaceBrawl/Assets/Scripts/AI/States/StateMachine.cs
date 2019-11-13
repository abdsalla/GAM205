using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private GameManager instance;
    private Dictionary<Type, BaseState> availableStates;

    public BaseState CurrentState { get; private set; }
    public event Action<BaseState> OnStateChanged;

    public void SetStates ( Dictionary<Type, BaseState> states )
    {
        availableStates = states;
    }

    public void SwitchToNewState(Type nextState)
    {
        CurrentState = availableStates[nextState];
        OnStateChanged?.Invoke(CurrentState);
    }

    void Awake()
    {
        instance = GameManager.Instance;
    }

    void Update()
    {
        if (CurrentState == null)
        {
            CurrentState = availableStates.Values.First();
        }

        var nextState = CurrentState?.Tick();

        if (nextState != null && nextState != CurrentState.GetType())
        {
            SwitchToNewState(nextState);
            OnStateChanged?.Invoke(CurrentState);
        }
    }
}