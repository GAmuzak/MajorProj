using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class ServiceWrapper : MonoBehaviour
{
    [SerializeField] EnumIInteractableDict enumIInteractable;
    
    private static ServiceWrapper _instance;
    private bool isServiceEnabled;
    public static ServiceWrapper Instance
    {
        get
        {
            if (_instance != null) return _instance;
            _instance = FindObjectOfType<ServiceWrapper>();
            if (_instance != null) return _instance;
            GameObject gg = new GameObject();
            gg.AddComponent<ServiceWrapper>();
            return _instance;
        }
    }
    
    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this);
        _instance = this;
    }

    public void ExecuteServiceUtil(SystemAction triggeredAction)
    {
        if(triggeredAction == SystemAction.NULL || isServiceEnabled) return;
        if (triggeredAction == SystemAction.Enable)
        {
            isServiceEnabled = !isServiceEnabled; return;
        }
        enumIInteractable[triggeredAction].GetComponent<IInteractable>().Interact();
    }

    public void EndServiceUtil(SystemAction triggeredAction)
    {
        if(triggeredAction == SystemAction.NULL) return;
        enumIInteractable[triggeredAction].GetComponent<IInteractable>().Complete();
    }
}

[Serializable]
public class EnumIInteractableDict : SerializableDictionary<SystemAction, GameObject> {}
