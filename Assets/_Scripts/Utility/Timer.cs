using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class Timer
{
    public bool State;
    public float Time;

    public IEnumerator Cooldown(bool finalState)
    {
        yield return new WaitForSeconds(Time);
        State = finalState;
    }
}