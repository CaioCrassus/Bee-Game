using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexUnit : MonoBehaviour
{
    public Vector2 gridPos;
    public HexMap mapRef;

    private bool click;
    void Update(){
        click = Input.GetMouseButtonUp(0);
    }
    void OnMouseOver(){
        if (click){
            if(true){// && mapRef.GetHexUnitState(gridPos) == state.selectble){//Buy hex function - resource manager returnd true
                Debug.Log("Over");
                mapRef.ChangeHexState(gridPos, state.empty);
                mapRef.updateMap();
            }
        }
    }
}
