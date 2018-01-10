using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace CaiUIFramework
{
    public class UIManager
    {
        private static UIManager instance;
        public static UIManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UIManager();
                }
                return instance;
            }
        }

        private Transform canvasTransform;
        private Transform CanvasTransform
        {
            get
            {
                if (canvasTransform == null)
                {
                    canvasTransform = GameObject.Find("Canvas").transform;
                }
                return canvasTransform;
            }
        }

        private Dictionary<UIPanelType, string> panelPathDict;
        private Dictionary<UIPanelType, BasePanel> panelDict;

        private Stack<BasePanel> panelStack;

        private UIManager()//构造方法是私有的，所以外界无法构造该类的对象只能通过公共静态的单例来访问
        {
            ParseUIPanelTypeJson();
        }
        private void ParseUIPanelTypeJson()
        {
            panelPathDict = new Dictionary<UIPanelType, string>();

            TextAsset ta = Resources.Load<TextAsset>("UIPanelType");

            UIPanelTypeJson uiPanelInfoList = JsonUtility.FromJson<UIPanelTypeJson>(ta.text);

            foreach (UIPanelInfo info in uiPanelInfoList.infoList)
            {
                panelPathDict.Add(info.panelType, info.path);
            }
        }
        private BasePanel GetPanel(UIPanelType panelType)
        {
            if (panelDict == null)
            {
                panelDict = new Dictionary<UIPanelType, BasePanel>();
            }

            //BasePanel panel;
            //panelDict.TryGetValue(panelType, out panel);

            BasePanel panel = panelDict.TryGet(panelType);//TryGet是字典类的扩展方法，用于尝试获取某一个键所对应的值

            if (panel == null)
            {
                //string path;
                //panelPathDict.TryGetValue(panelType, out path);

                string path = panelPathDict.TryGet(panelType);

                GameObject instancePanel = GameObject.Instantiate(Resources.Load(path)) as GameObject;
                instancePanel.transform.SetParent(CanvasTransform,false);
                panelDict.Add(panelType, instancePanel.GetComponent<BasePanel>());
                return instancePanel.GetComponent<BasePanel>();
            }
            else
            {
                return panel;
            }
        }

        public void PushPanel(UIPanelType panelType)
        {
            if (panelStack == null)
            {
                panelStack = new Stack<BasePanel>();
            }

            if (panelStack.Count > 0)
            {
                BasePanel topPanel = panelStack.Peek();
                topPanel.OnPause();
            }

            BasePanel panel = GetPanel(panelType);
            panel.OnEnter();
            panelStack.Push(panel);
        }
        public void PopPanel()
        {
            if (panelStack == null)
                panelStack = new Stack<BasePanel>();

            if (panelStack.Count == 0) return;

            BasePanel topPanel01 = panelStack.Pop();
            topPanel01.OnExit();

            if (panelStack.Count == 0) return;
            BasePanel topPanel02 = panelStack.Peek();
            topPanel02.OnContinue();
        }

        public void Test()
        {
            string path;
            panelPathDict.TryGetValue(UIPanelType.Knapsack, out path);
            Debug.Log(path);
        }
    }

    [Serializable]
    public class UIPanelTypeJson
    {
        public List<UIPanelInfo> infoList;
    }
}

