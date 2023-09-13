using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CollectableItemSO", menuName = "ScriptableObjects/CollectableItemSO", order = 0)]
public class CollectableItemSO : ScriptableObject {
    public string itemName;
    public string itemDescription;
    public Sprite itemImage;
    public int itemType;
}
