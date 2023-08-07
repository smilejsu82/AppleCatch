using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//게임 씬에 있는 모든 애들 관리 
public class GameMain : MonoBehaviour
{
    [SerializeField]
    private  ItemGenerator itemGenerator;
    [SerializeField]
    private List<GameObject> baskPerfabs;

    private BasketController baskController;
    
    void Start()
    {
        Debug.LogFormat("<color=cyan>InfoManager.instance.selectedBasketType: {0}</color>", InfoManager.instance.selectedBasketType);

        this.CreateBasket();

        this.itemGenerator.StartGenerate();
    }

    private void CreateBasket()
    {
        GameObject prefab = this.baskPerfabs[InfoManager.instance.selectedBasketType];
        GameObject basketGo = Instantiate(prefab);
        basketGo.transform.position = Vector3.zero;
        this.baskController = basketGo.GetComponent<BasketController>();
        this.baskController.Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
