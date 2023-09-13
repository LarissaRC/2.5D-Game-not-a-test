using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ToolSO", menuName = "ScriptableObjects/ToolSO", order = 0)]
public class ToolSO : ScriptableObject
{
    public string toolName;
    public string toolDescription;
    public Sprite toolImage;
    public int toolType;
}
