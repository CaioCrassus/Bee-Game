using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.SceneManagement;


public class ControllerResources : MonoBehaviour {

    private static int nectares; 
    public int Nectares {
        get { return nectares; }
        set { nectares = value; }
    }

    private static int beeWorkers;
    public int BeeWorkers {
        get { return beeWorkers; }
        set { beeWorkers = value; }
    }
    private static int beeSoldiers;
    public int BeeSoldiers {
        get { return beeSoldiers; }
        set { beeSoldiers = value; }
    }

    public Text txtCells;
    public Text txtNectares;
    public Text txtBeeWorkers;
    public Text txtBeeSoldiers;

    public GameObject panelPurchaseWorker;
    public GameObject panelPurchaseSoldier;

    HexMap hexMap;
    private int cellsCount;
    public int CellsCount {
        get { return cellsCount; }
        set { cellsCount = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        hexMap = GameObject.Find("GameObject").GetComponent<HexMap>();
        

        nectares += 100;
        // beeWorkers += 0;
        // beeSoldiers += 0;

        setTexts();

    }

    // Update is called once per frame
    void Update()
    {
        setTexts();
    }

    private void setTexts() {
        cellsCount = hexMap.fullCount + hexMap.emptyCount;
        txtCells.text = cellsCount.ToString();
        txtNectares.text = nectares.ToString();
        txtBeeWorkers.text = beeWorkers.ToString();
        txtBeeSoldiers.text = beeSoldiers.ToString();
    }

    public void openPanelExchange(bool worker) {
        if (!worker) {
            panelPurchaseSoldier.SetActive(true);
            panelPurchaseWorker.SetActive(false);  
        }
        else {
            panelPurchaseWorker.SetActive(true);
            panelPurchaseSoldier.SetActive(false);
        }
    }

    public void ClosePanelExchange(bool worker) {
        if (!worker) {
            panelPurchaseSoldier.SetActive(false);
        }
        else {
            panelPurchaseWorker.SetActive(false);
        }
    }

    public void startMission(int level) {
        EditorSceneManager.LoadScene(level);
    }
}
