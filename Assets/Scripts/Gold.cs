using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Gold/Gold Data")]
public class Gold : ScriptableObject
{
    public int score;
    public float m_Time;
    public bool IsDisPlayer;
    public int currclient = 0;
}
