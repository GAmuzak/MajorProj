using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenAppManager : InteractableMonoBehaviour
{
    [SerializeField] private Vector3 targetScale = Vector3.one;
    private WindowManager windowManager;
    private WindowPlacement windowPlacement;
    private static Vector2Int centralWindowIndex;
    // Start is called before the first frame update
    void Start()
    {
        windowManager = GetComponent<WindowManager>();
        windowPlacement = GetComponentInChildren<WindowPlacement>();
        centralWindowIndex = windowManager.centralWindowIndex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Interact()
    {
        var centreWindow = windowManager.Windows[centralWindowIndex.x, centralWindowIndex.y];
        var currentWindow = windowManager.SelectedWindow;
        ChangeWindowScale(windowPlacement.gameObject, centreWindow, new Vector3(0.3f,0.3f,0.3f));
        currentWindow.isOpen = false;
        Debug.Log("Trying to minimize");
    }
    
    public override void Complete()
    {
        var currentWindow = windowManager.SelectedWindow;
        ChangeWindowScale(windowPlacement.gameObject, currentWindow, targetScale);
        currentWindow.isOpen = true;
    }

    private void ChangeWindowScale(GameObject target, Window pivotWindow, Vector3 newScale)
    {
        var centreWindow = windowManager.Windows[centralWindowIndex.x, centralWindowIndex.y];
        Vector2Int relativeScreenIndex=  centralWindowIndex - pivotWindow.containerIndex;
        Vector3 relativeScreenIndexVector3 = new Vector3(relativeScreenIndex.x, relativeScreenIndex.y, 0f);
        float RS = newScale.x / target.transform.localScale.x; // relative scale factor
        Debug.Log($"Relative Scale {RS}");
        // calc final position post-scale
        Vector3 FP = new Vector3(1920, 1080);
        FP.Scale(relativeScreenIndexVector3);
        // finally, actually perform the scale/translation
        target.transform.LeanScale(newScale, 0.3f);
        target.GetComponent<RectTransform>().LeanMove(FP, 0.3f);
    }
}
