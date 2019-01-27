using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExchangeCell : MonoBehaviour {
    ControllerResources ctrlResources;
    public Vector2 gridPos;

    public Text textCostCell;
    public Text textQtdNectar;

    //private bool confirmPurchase;
    //public bool ConfirmPurchase {
    //    get { return confirmPurchase; }
    //    set { confirmPurchase = value; }
    //}

    void OnEnable()
    {
        ctrlResources = gameObject.transform.GetComponentInParent<ControllerResources>();

        textCostCell.text = (ctrlResources.CellsCount * 20).ToString();
        textQtdNectar.text = ctrlResources.Nectares.ToString();

        if (ctrlResources.CellsCount * 20 > ctrlResources.Nectares) {
            textCostCell.color = Color.red;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void confirmPurchase() {
        if (ctrlResources.CellsCount * 20 <= ctrlResources.Nectares) {
            HexMap.instance.ChangeHexState(gridPos, state.empty);
            HexMap.instance.updateMap();
            gameObject.SetActive(false);

        }
    }

    public void ClosePanel() {
        gameObject.SetActive(false);
    }
}
