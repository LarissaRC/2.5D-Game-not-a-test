using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    [SerializeField] private PlantSO plantSO;
    private SpriteRenderer spriteRenderer;
    private int _state; //0 - semente; 1 - screscida; 2 - Madura.
    
    private void Start() {
        _state = 0;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = plantSO.plantStages[0];
    }

    private void Grow() {
        if(_state < 2) {
            _state++;
            spriteRenderer.sprite = plantSO.plantStages[_state];
        }
    }
}
