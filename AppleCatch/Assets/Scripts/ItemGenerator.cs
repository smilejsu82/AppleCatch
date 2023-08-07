using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    private float elasedTime;   //��� �ð�
    private float spawnTime = 1f;   //1�ʿ� �ѹ��� 
    //�����ϱ� ���ؼ� Prefab�� �ʿ��� 
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

        //�ð� ��� 
        //������ Time.deltaTime���ض� 
        this.elasedTime += Time.deltaTime;
        //1�ʰ� �����ٸ� 
        if (this.elasedTime >= this.spawnTime) {
            //�������� ���� 
            this.CreateItem();
            //�ʱ�ȭ 
            this.elasedTime = 0;
        }
    }

    private void CreateItem()
    {
        //��� �Ǵ� ��ź 
        int rand = Random.Range(1, 11); //1 ~ 10
        GameObject itemGo = null;
        if (rand > 2)  //3, 4, 5, 6, 7, 8, 9, 10
        {
            //��� 
            itemGo = Instantiate(this.applePrefab);
        }
        else    //1, 2
        {
            //��ź 
            itemGo = Instantiate(this.bombPrefab);
        }
        //��ġ ���� 
        //x: -1, 1
        //z: -1, 1 
        int x = Random.Range(-1, 2);    //-1, 0, 1
        int z = Random.Range(-1, 2);
        //��ġ�� ���� 
        itemGo.transform.position = new Vector3(x, 3.5f, z);
    }
}
