using UnityEngine;
using System.Collections;
using CaiUIFramework;

public class MainMenuPanel : BasePanel
{
    private CanvasGroup canvasGroup;

    private void Start()
    {
        if(canvasGroup==null)
            canvasGroup = GetComponent<CanvasGroup>();    
    }

    public override void OnEnter()
    {
        if (canvasGroup == null)
            canvasGroup = GetComponent<CanvasGroup>();

        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
    }

    public override void OnPause()
    {
        canvasGroup.blocksRaycasts = false;
    }

    public override void OnContinue()
    {
        canvasGroup.blocksRaycasts = true;
    }

    public void OnPushPanel(string panelTypeString)
    {
        UIPanelType panelType = (UIPanelType)System.Enum.Parse(typeof(UIPanelType), panelTypeString);
        UIManager.Instance.PushPanel(panelType);
    }
}
