using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmSlotCollisionDetection : MonoBehaviour
{
    [SerializeField] private Animator anim;
    private bool _canPlant;
    public bool CanPlant
    {
        get { return _canPlant;}
        set { _canPlant = value;}
    }

    private void OnTriggerEnter(Collider c) {
        if (!c.gameObject.CompareTag("Player")){
            //Debug.Log("Entrou: " + c.gameObject.name);
            anim.SetBool("CanPlant", false);
        }
    }

    private void OnTriggerExit(Collider c) {
        //Debug.Log("Saiu: " + c.gameObject.name);
    }
}
