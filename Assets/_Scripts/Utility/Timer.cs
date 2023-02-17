using System.Collections;
using UnityEngine;

public class Timer
{
    public bool State;
    public float Time;

    public IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(Time);
        State = !State;
    }
}