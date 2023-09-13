using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractBtn : MonoBehaviour
{
    [SerializeField] private CollectableItensInteractListSO btnIcons;
    [SerializeField] private Image btnIcon;

    public void ChangeIcon(int iconType)
    {
        btnIcon.sprite = btnIcons.interactableIcons[iconType];
    }
}
