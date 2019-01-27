using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Exchange : MonoBehaviour
{
    ControllerResources ctrlResources;

    int qtdWorkers;
    public Text textQtdWorkers;
    public Text textCostWorkers;
    public Text textQtdNectar;    

    void OnEnable() {
        ctrlResources = gameObject.transform.GetComponentInParent<ControllerResources>();

        qtdWorkers = 1;
        textQtdWorkers.text = qtdWorkers.ToString();
        textCostWorkers.text = (qtdWorkers * 10).ToString();
        textQtdNectar.text = ctrlResources.Nectares.ToString();

        if (qtdWorkers * 10 > ctrlResources.Nectares) {
            textCostWorkers.color = Color.red;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }   

    public void qtdPlus() {
        qtdWorkers++;
        textQtdWorkers.text = qtdWorkers.ToString();
        textCostWorkers.text = (qtdWorkers * 10).ToString();

        if (qtdWorkers * 10 > ctrlResources.Nectares) {
            textCostWorkers.color = Color.red;
        } 

    }

    public void qtdMinor() {
        qtdWorkers--;
        if (qtdWorkers < 1) qtdWorkers = 1;
        textQtdWorkers.text = qtdWorkers.ToString();
        textCostWorkers.text = (qtdWorkers * 10).ToString();

        if (qtdWorkers * 10 <= ctrlResources.Nectares) {
            textCostWorkers.color = Color.white;
        }
    }

    public void buyWorker() {
        if (qtdWorkers * 10 <= ctrlResources.Nectares) {
            ctrlResources.Nectares -= qtdWorkers * 10;
            ctrlResources.BeeWorkers += qtdWorkers;
            gameObject.SetActive(false);
        }

        
    }

    public void buySoldier() {

    }


}
