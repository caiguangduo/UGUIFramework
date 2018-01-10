using UnityEngine;
using System.Collections;
using CaiUIFramework;
using DG.Tweening;

public class KnapsackPanel : BasePanel
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

        canvasGroup.alpha = 0;

        canvasGroup.DOFade(1, .5f).OnComplete(()=> {
            canvasGroup.alpha = 1;
            canvasGroup.blocksRaycasts = true;
        });
        
    }

    public override void OnPause()
    {
        canvasGroup.blocksRaycasts = false;
    }

    public override void OnContinue()
    {
        canvasGroup.blocksRaycasts = true;
    }

    public override void OnExit()
    {
        canvasGroup.DOFade(0, .5f).OnComplete(() => {
            canvasGroup.alpha = 0;
            canvasGroup.blocksRaycasts = false;
        });
    }

    public void ForCloseBt()
    {
        UIManager.Instance.PopPanel();
    }

    public void ForTestBt()
    {
        UIManager.Instance.PushPanel(UIPanelType.ItemMessage);
    }
}
