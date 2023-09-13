using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CollectableItemSO", menuName = "ScriptableObjects/CollectableItemListSO", order = 0)]
public class CollectableItensInteractListSO : ScriptableObject
{
    public List<Sprite> interactableIcons;
}
