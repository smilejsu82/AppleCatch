using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip appleSfx;
    [SerializeField]
    private AudioClip bombSfx;
    [SerializeField]
    private GameDirector gameDirector;

    void Start()
    {
        this.audioSource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //���콺 ���� Ŭ�� �ϸ� (ȭ���� Ŭ���ϸ�)Ray�� ������ 
        if (Input.GetMouseButtonDown(0))
        {
            //ȭ����� ��ǥ -> Ray ��ü�� ���� 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float maxDistance = 100f;
            //ray�� ������ Ȯ�� 
            Debug.DrawRay(ray.origin, ray.direction * maxDistance, Color.green, 2f);

            //ray�� collider�� �浹�� �˻��ϴ� �޼��� 
            //out�Ű������� ����Ϸ��� �������Ǹ� ���� �ؾ� �Ѵ� 
            RaycastHit hit;
            //outŰ���带 ����ؼ� ���ڷ� �־�� 
            //Raycast �޼��忡�� ����� ����� hit �Ű����� �־��� 
            //�浹 �Ǿ��ٸ� ~ true , �ƴϸ� false 
            if (Physics.Raycast(ray, out hit, maxDistance))
            {
                //The impact point in world space where the ray hit the collider.
                Debug.LogFormat("hit.point:{0}", hit.point);

                //this.gameObject.transform.position = hit.point;
                //�ٱ����� ��ġ�� �浹�� �������� ����
                //this.transform.position = hit.point;
                //x��ǥ�� z��ǥ�� �ݿø� 
                float x = Mathf.RoundToInt(hit.point.x);
                float z = Mathf.RoundToInt(hit.point.z);
                //���ο� ��ǥ�� ����� �̵� 
                this.transform.position = new Vector3(x, 0, z);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);

        if (other.tag == "apple") 
        {
            Debug.Log("����");
            this.audioSource.PlayOneShot(this.appleSfx);
            this.gameDirector.IncreaseScore(100);
        }
        else 
        {
            Debug.Log("����");
            this.audioSource.PlayOneShot(this.bombSfx);
            this.gameDirector.DecreaseScore(50);
        }

        this.gameDirector.UpdateScoreUI();

        Destroy(other.gameObject);  //����Ǵ� ��ź�� ���� 
    }
}
