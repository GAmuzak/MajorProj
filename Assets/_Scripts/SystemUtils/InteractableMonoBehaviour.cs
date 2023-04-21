using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Object = UnityEngine.Object;
[Serializable]
public class InteractableMonoBehaviour : MonoBehaviour
{
    public virtual void Interact()
    {
        
    }

    public virtual void Complete()
    {
        
    }
}

public interface IInteractable
{
    public void Interact();

    public void Complete();
}
