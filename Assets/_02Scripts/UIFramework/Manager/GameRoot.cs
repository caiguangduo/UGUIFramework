using UnityEngine;
using System.Collections;
using CaiUIFramework;

public class GameRoot : MonoBehaviour
{
    private void Start()
    {
        UIManager.Instance.PushPanel(UIPanelType.MainMenu);
    }
}
