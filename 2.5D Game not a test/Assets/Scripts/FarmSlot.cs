using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmSlot : MonoBehaviour
{

    [SerializeField] private GameObject selectIndicator;
    private ToolsManager toolsManager;
    
    private bool _canPlant;

    private void Start() {
        toolsManager = FindObjectOfType<ToolsManager>();
    }

    private bool PlayerIsHoldingHoe() {
        return toolsManager.EquipedTool == 1;
    }
    
    private void OnTriggerEnter(Collider c) {
        if (c.gameObject.CompareTag("Player") && PlayerIsHoldingHoe()){
            selectIndicator.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider c) {
        if (c.gameObject.CompareTag("Player")){
            selectIndicator.SetActive(false);
        }
    }
}
