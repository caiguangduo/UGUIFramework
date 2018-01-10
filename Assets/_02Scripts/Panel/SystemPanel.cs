using UnityEngine;
using System.Collections;
using CaiUIFramework;
using DG.Tweening;

public class SystemPanel : BasePanel
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

        transform.localPosition += new Vector3(1700.0f, 0.0f, 0.0f);
        transform.DOLocalMoveX(0, .5f, true);

        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
    }

    public override void OnExit()
    {
        transform.DOLocalMoveX(1700.0f, .5f, true).OnComplete(() =>
        {
            canvasGroup.alpha = 0;
            canvasGroup.blocksRaycasts = false;
        });

        
    }

    public void ForCloseBt()
    {
        UIManager.Instance.PopPanel();
    }
}
