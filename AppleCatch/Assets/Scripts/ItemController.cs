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
        //리지드바디가 없는 오브젝트의 이동 
        //this.transform.Translate(방향 * 속도 * 시간);
        //기본이 로컬좌표로 이동 
        this.transform.Translate(Vector3.down * this.moveSpeed * Time.deltaTime);
        //바닥에 도달하면 제거 
        if (this.transform.position.y <= 0) {
            Destroy(this.gameObject);   //Destroy(this); 완전히 다른 의미다 
        }
    }
}
