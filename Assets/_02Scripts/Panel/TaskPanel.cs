using UnityEngine;
using System.Collections;
using CaiUIFramework;
using DG.Tweening;

public class TaskPanel : BasePanel
{
    private CanvasGroup canvasGroup;

    private void Start()
    {
        if (canvasGroup == null)
            canvasGroup = GetComponent<CanvasGroup>();
    }

    public override void OnEnter()
    {
        if (canvasGroup == null)
            canvasGroup = GetComponent<CanvasGroup>();

        transform.localScale = Vector3.zero;
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;

        transform.DOScale(Vector3.one, .5f);

    }

    public override void OnExit()
    {
        transform.DOScale(Vector3.zero, .5f).OnComplete(()=> {
            canvasGroup.alpha = 0;
            canvasGroup.blocksRaycasts = false;
        });
    }

    public void ForCloseBt()
    {
        UIManager.Instance.PopPanel();
    }
}
