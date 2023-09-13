using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ToolsManager : MonoBehaviour
{
    [SerializeField] private List<ToolSO> tools;
    private int equipedTool = 0;
    public int EquipedTool {
        get { return equipedTool;}
    }

    [SerializeField] private Image toolImage;
    [SerializeField] private TMP_Text toolName;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.E))
            ChangeTool(1);
        if (Input.GetKeyDown(KeyCode.Q))
            ChangeTool(-1);
    }

    private void ChangeTool(int value)
    {
        equipedTool += value;
        if(equipedTool > tools.Count - 1)
            equipedTool = 0;
        
        if(equipedTool < 0)
            equipedTool = tools.Count - 1;

        UpdateUI();
    }

    private void UpdateUI() {
        toolImage.sprite = tools[equipedTool].toolImage;
        toolName.text = "Tool: " + tools[equipedTool].toolName;
    }
}
