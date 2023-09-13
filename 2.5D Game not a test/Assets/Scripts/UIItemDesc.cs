using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIItemDesc : MonoBehaviour
{
    [SerializeField] PlayerInteractions playerInteractions;
    [SerializeField] private Image itemImage;
    [SerializeField] private Image newItemImage;
    [SerializeField] private TMP_Text itemName;
    [SerializeField] private TMP_Text newItemName;
    [SerializeField] private TMP_Text itemDescription;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerInteractions.OnInteractWithItem += PlayerInteractions_OnInteractWithItem;
    }

    private void PlayerInteractions_OnInteractWithItem(object sender, PlayerInteractions.OnInteractWithItemEventArgs item) {
        /*
        if(!PlayerPrefs.HasKey("nome do item")) {
            newItemImage.sprite = item.item.collectableItemSO.itemImage;
            newItemName.text = item.item.collectableItemSO.itemName;
        }
        */
        itemImage.sprite = item.item.collectableItemSO.itemImage;
        itemName.text = item.item.collectableItemSO.itemName;
        itemDescription.text = item.item.collectableItemSO.itemDescription;
        animator.Play("item_collected_ui_anim");
    }
}
