using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.SceneManagement;


public class ControllerResources : MonoBehaviour {

    private int nectares; 
    public int Nectares {
        get { return nectares; }
        set { nectares = value; }
    }

    private int beeWorkers;
    public int BeeWorkers {
        get { return beeWorkers; }
        set { beeWorkers = value; }
    }
    private int beeSoldiers;
    public int BeeSoldiers {
        get { return BeeSoldiers; }
        set { BeeSoldiers = value; }
    }

    public Text txtNectares;
    public Text txtBeeWorkers;
    public Text txtBeeSoldiers;

    public GameObject panelPurchase;

    // Start is called before the first frame update
    void Start()
    {
        nectares = 100;
        beeWorkers = 0;
        beeSoldiers = 0;

        txtNectares.text = nectares.ToString();
        txtBeeWorkers.text = beeWorkers.ToString();
        txtBeeSoldiers.text = beeSoldiers.ToString();        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //if bee false: bee = worker else: bee = soldier
    public void openPanelExchange(bool bee) {
        panelPurchase.SetActive(true);
        if (bee) {
            panelPurchase.GetComponent<Image>().color = new Color(1, 0.92f, 0.016f, 0.5f);
            panelPurchase.transform.Find("iBeeWorker").gameObject.SetActive(true);
            panelPurchase.transform.Find("iBeeSoldier").gameObject.SetActive(false);
            panelPurchase.transform.Find("btnPurchaseWorker").gameObject.SetActive(true);
            panelPurchase.transform.Find("btnPurchaseSoldier").gameObject.SetActive(false);
        }
        else {
            panelPurchase.GetComponent<Image>().color = new Color(1, 0, 0, 0.5f);
            panelPurchase.transform.Find("iBeeWorker").gameObject.SetActive(false);
            panelPurchase.transform.Find("iBeeSoldier").gameObject.SetActive(true);
            panelPurchase.transform.Find("btnPurchaseWorker").gameObject.SetActive(false);
            panelPurchase.transform.Find("btnPurchaseSoldier").gameObject.SetActive(true);
        }

    }

    public void ClosePanelExchange() {
        panelPurchase.SetActive(false);
    }

    public void startMission(int level) {
        EditorSceneManager.LoadScene(level);
    }
}
