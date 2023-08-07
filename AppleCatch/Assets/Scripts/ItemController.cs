using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //������ٵ� ���� ������Ʈ�� �̵� 
        //this.transform.Translate(���� * �ӵ� * �ð�);
        //�⺻�� ������ǥ�� �̵� 
        this.transform.Translate(Vector3.down * this.moveSpeed * Time.deltaTime);
        //�ٴڿ� �����ϸ� ���� 
        if (this.transform.position.y <= 0) {
            Destroy(this.gameObject);   //Destroy(this); ������ �ٸ� �ǹ̴� 
        }
    }
}
