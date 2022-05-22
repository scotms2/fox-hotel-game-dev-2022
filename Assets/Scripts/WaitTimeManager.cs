using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaitTimeManager{
    private static TaskBehaviour m_Task;
    static WaitTimeManager()
    {
        GameObject go = new GameObject("#WaitTimeManager#");
        //GameObject.DontDestroyOnLoad(go);
        m_Task = go.AddComponent<TaskBehaviour>();
    }

    static public Coroutine WaitTime(float time,UnityAction callBack)
    {
        return m_Task.StartCoroutine(Coroutine(time, callBack));
    }

    static public void CancelWait(ref Coroutine coroutine)
    {
        if (coroutine != null)
        {
            m_Task.StopCoroutine(coroutine);
            coroutine = null;
        }
    }

    static IEnumerator Coroutine(float time,UnityAction callBack)
    {
        yield return new WaitForSeconds(time);
        if (callBack != null)
        {
            callBack();
        }
    }


    static IEnumerator ReaptCoroutine(float delayTime, float reaptTime, UnityAction callBack)
    {
        yield return new CustonWait(delayTime,reaptTime,callBack);
    }


    static public Coroutine ReaptWaitTime(float endTime,float reaptTime,UnityAction callBack)
    {
        return m_Task.StartCoroutine(ReaptCoroutine(endTime, reaptTime, callBack));
    }
   

    class TaskBehaviour : MonoBehaviour { }

    public class CustonWait : CustomYieldInstruction
    {
        private UnityAction m_IntervalCallback;
        private float m_StartTime;
        private float m_LastTime;
        private float m_Interval;
        private float m_Time;

        public CustonWait(float time,float interval,UnityAction callBack)
        {
            m_StartTime = Time.time;
            m_LastTime = Time.time;
            m_Interval = interval;
            m_Time = time;
            m_IntervalCallback = callBack;
        }

        public override bool keepWaiting
        {
            get
            {
                if (Time.time - m_StartTime >= m_Time)
                {
                    return false;
                }else if (Time.time - m_LastTime >= m_Interval)
                {
                    m_LastTime = Time.time;
                    m_IntervalCallback();
                }
                return true;
            }
        }
    }
}
