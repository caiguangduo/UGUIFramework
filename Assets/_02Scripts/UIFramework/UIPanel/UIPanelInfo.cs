using UnityEngine;
using System.Collections;
using System;

namespace CaiUIFramework
{
    [Serializable]
    public class UIPanelInfo:ISerializationCallbackReceiver
    {
        [NonSerialized]
        public UIPanelType panelType;

        public string panelTypeString;
        public string path;

        public void OnAfterDeserialize()
        {
            UIPanelType type = (UIPanelType)Enum.Parse(typeof(UIPanelType), panelTypeString);
            panelType = type;
        }

        public void OnBeforeSerialize()
        {

        }
    }
}

