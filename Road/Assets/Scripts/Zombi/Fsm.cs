using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM.Scripts;

public class Fsm
{
    private FsmState StateCurrent { get; set; }

    public Dictionary<Type, FsmState> _states = new Dictionary<Type, FsmState>();

    public void AddState(FsmState state)
    {
        _states.Add(state.GetType(), state);
    }

    public void SetState<T>() where T : FsmState
    {
        var type = typeof(T);

        if(StateCurrent != null && StateCurrent.GetType() == type)
        {
            return;
        }

        if(_states.TryGetValue(type, out var newState))
        {
            StateCurrent?.Exit();

            StateCurrent = newState;

            StateCurrent.Enter();
        }
    }

    public void FixedUpdate()
    {
        StateCurrent?.FixedUpdate();
    }

}
