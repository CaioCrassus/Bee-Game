using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexUnit : MonoBehaviour
{
    public Vector2 gridPos;
    public HexMap mapRef;

    //GameObject panelPurchase;
    //ExchangeCell exchangeCell;

    ControllerResources ctrlResources;


    private bool click;

    void Start() {
        //panelPurchase = GameObject.Find("Canvas").transform.Find("panelPurchaseCell").gameObject;
        //exchangeCell = panelPurchase.GetComponent<ExchangeCell>();

        ctrlResources = GameObject.Find("Canvas").GetComponent<ControllerResources>();

    }

    void Update(){
        click = Input.GetMouseButtonUp(0);
    }
    void OnMouseOver(){
        if (click){
            //panelPurchase.gameObject.SetActive(true);
            if(ctrlResources.CellsCount * 20 <= ctrlResources.Nectares) { 
                ctrlResources.Nectares -= ctrlResources.CellsCount * 20;
                mapRef.ChangeHexState(gridPos, state.empty);
                mapRef.updateMap();
            }


            //if (true) {// && mapRef.GetHexUnitState(gridPos) == state.selectble){//Buy hex function - resource manager returnd true
            //    Debug.Log("Over");



            //}
        }
    }
}
