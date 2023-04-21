using System;
using UnityEngine;

public class ServiceWrapper : MonoBehaviour
{
    [SerializeField] public EnumIInteractableDict enumIInteractable;

    private Stopwatch timer;
    private static ServiceWrapper _instance;
    [SerializeField] private Timer isServiceEnabled;
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

    public void ExecuteService(SystemAction triggeredAction)
    {
        if(triggeredAction == SystemAction.NULL || !isServiceEnabled.State) return;
        if (triggeredAction == SystemAction.Enable)
        {
            isServiceEnabled.State = true;
            return;
        }

        Debug.Log(triggeredAction);
        enumIInteractable[triggeredAction].Interact();
    }

    public void EndService(SystemAction triggeredAction)
    {
        if(triggeredAction == SystemAction.NULL) return;
        isServiceEnabled.State = false;
        StartCoroutine(isServiceEnabled.Cooldown(true));
        enumIInteractable[triggeredAction].Complete();
    }
}

[Serializable]
public class EnumIInteractableDict : SerializableDictionary<SystemAction, InteractableMonoBehaviour> {}
