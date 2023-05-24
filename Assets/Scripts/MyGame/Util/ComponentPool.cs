using System;
using System.Collections.Generic;
using UnityEngine;

namespace QFramework
{
    public class ComponentPool<T> where T: Behaviour
    {
        private GameObject mRoot; // �������
        private string mRootName;
        private List<T> mOpenList = new List<T>(); // �����Ѽ������
        private Queue<T> mCloseList = new Queue<T>(); // ����δʹ�����
        public ComponentPool(string rootObjName)
        {
            mRootName = rootObjName;
        }
        public void SetAllEnabledComponents(Action<T> callBack)
        {
            foreach (T component in mOpenList)
            {
                callBack(component);
            }
        }
        // ��ȡ��ʹ�����
        public void Get(out T component)
        {
            if (mCloseList.Count > 0)
            {
                component = mCloseList.Dequeue();
                component.enabled = true;
            }
            else
            {
                if (mRoot == null)
                {
                    mRoot = new GameObject(mRootName);
                    GameObject.DontDestroyOnLoad(mRoot);
                }
                component = mRoot.AddComponent<T>();
            }
            mOpenList.Add(component);
        }
        // �Զ��������
        public void AutoPush(Func<T, bool> condition)
        {
            for (int i = mOpenList.Count - 1; i >= 0; i--)
            {
                if (condition(mOpenList[i]))
                {
                    mOpenList[i].enabled = false;
                    mCloseList.Enqueue(mOpenList[i]);
                    mOpenList.RemoveAt(i);
                }
            }
        }
        // ���յ������
        public void Push(T component, Action callBack = null)
        {
            if (mOpenList.Contains(component))
            {
                callBack?.Invoke();
                mOpenList.Remove(component);
                component.enabled = false;
                mCloseList.Enqueue(component);
            }
        }
    }
}

