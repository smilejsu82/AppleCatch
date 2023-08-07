using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    private float elasedTime;   //경과 시간
    private float spawnTime = 1f;   //1초에 한번씩 
    //생성하기 위해서 Prefab이 필요함 
    public GameObject applePrefab;
    public GameObject bombPrefab;

    private bool isStart = false;
    void Start()
    {
        
    }

    public void StartGenerate()
    {
        this.isStart = true;
        Debug.Log("StartGenerate");
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isStart == false) return;

        //시간 재기 
        //변수에 Time.deltaTime더해라 
        this.elasedTime += Time.deltaTime;
        //1초가 지났다면 
        if (this.elasedTime >= this.spawnTime) {
            //아이템을 생성 
            this.CreateItem();
            //초기화 
            this.elasedTime = 0;
        }
    }

    private void CreateItem()
    {
        //사과 또는 폭탄 
        int rand = Random.Range(1, 11); //1 ~ 10
        GameObject itemGo = null;
        if (rand > 2)  //3, 4, 5, 6, 7, 8, 9, 10
        {
            //사과 
            itemGo = Instantiate(this.applePrefab);
        }
        else    //1, 2
        {
            //폭탄 
            itemGo = Instantiate(this.bombPrefab);
        }
        //위치 설정 
        //x: -1, 1
        //z: -1, 1 
        int x = Random.Range(-1, 2);    //-1, 0, 1
        int z = Random.Range(-1, 2);
        //위치를 설정 
        itemGo.transform.position = new Vector3(x, 3.5f, z);
    }
}
