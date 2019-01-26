using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exchange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //if bee false: bee = worker else: bee = soldier
    public void openPanelExchange(bool bee){
        gameObject.SetActive(true);
        if (bee){
            gameObject.GetComponent<Image>().color = new Color(1, 0.92f, 0.016f, 0.5f);
            gameObject.transform.Find("iBeeWorker").gameObject.SetActive(true);
            gameObject.transform.Find("iBeeSoldier").gameObject.SetActive(false);
            gameObject.transform.Find("btnPurchase").Find("iPurchaseWorker").gameObject.SetActive(true);
            gameObject.transform.Find("btnPurchase").Find("iPurchaseSoldier").gameObject.SetActive(false);

        }
        else {
            gameObject.GetComponent<Image>().color = new Color(1, 0, 0, 0.5f);
            gameObject.transform.Find("iBeeWorker").gameObject.SetActive(false);
            gameObject.transform.Find("iBeeSoldier").gameObject.SetActive(true);
            gameObject.transform.Find("btnPurchase").Find("iPurchaseWorker").gameObject.SetActive(false);
            gameObject.transform.Find("btnPurchase").Find("iPurchaseSoldier").gameObject.SetActive(true);

        }
        
    }

    public void ClosePanelExchange() {
        gameObject.SetActive(false);
    }
}
