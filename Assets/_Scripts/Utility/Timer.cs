using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class Timer
{
    public bool State;
    public float Time;

    public Timer(bool InitialState, float coolDownTime)
    {
        State = InitialState;
        Time = coolDownTime;
    }
    public IEnumerator Cooldown(bool finalState)
    {
        Debug.Log("tIMER sTARTED");
        yield return new WaitForSeconds(Time);
        State = finalState;
    }
}