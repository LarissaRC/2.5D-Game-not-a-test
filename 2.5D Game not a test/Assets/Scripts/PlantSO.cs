using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "plantSO", menuName = "ScriptableObjects/plantSO", order = 0)]
public class PlantSO : ScriptableObject
{
    public string plantName;
    public List<Sprite> plantStages;
    public int minSeeds;
    public int maxSeeds;
}
