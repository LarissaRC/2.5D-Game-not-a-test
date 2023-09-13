using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractions : MonoBehaviour
{

    [SerializeField] private InteractBtn interactBtn;
    private Vector3 lastInteractDir;
    private List<GameObject> triggeredItens;

    public event EventHandler<OnInteractWithItemEventArgs> OnInteractWithItem;
    public class OnInteractWithItemEventArgs : EventArgs {
        public CollectableItem item;
    }

    private PlayerInput playerInput;

    private void Start() {
        triggeredItens = new List<GameObject>();
    }

    public void HandleInteractions(GameObject item)
    {
        if (item.transform.TryGetComponent(out CollectableItem collectableItem)) {
            // Change icon according the item
            //print(item.GetComponent<CollectableItem>().collectableItemSO.itemName);
            interactBtn.ChangeIcon(item.GetComponent<CollectableItem>().collectableItemSO.itemType);

        } else {
            // change icom to null
            print("Null");
        }
    }

    private void OnTriggerEnter(Collider col) {
        if(col.gameObject.layer == LayerMask.NameToLayer("Item")) {
            HandleInteractions(col.gameObject);
            triggeredItens.Add(col.gameObject);
        }
    }

    private void OnTriggerExit(Collider col) {
        if(col.gameObject.layer == LayerMask.NameToLayer("Item")) {
            triggeredItens.Remove(col.gameObject);
            if(triggeredItens.Count == 0) {
                interactBtn.ChangeIcon(3);
            }
        }
    }

    public void InteractWithItem() {
        if(triggeredItens.Count != 0){
            OnInteractWithItem?.Invoke(this, new OnInteractWithItemEventArgs
            {
                item = triggeredItens.Last().GetComponent<CollectableItem>()
            });
        }
    }
}
