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

    private void Awake()
    {

    }

    public void Init()
    {
        GameObject gameDirectorGo = GameObject.Find("GameDirector");
        this.gameDirector = gameDirectorGo.GetComponent<GameDirector>();
        Debug.LogFormat("Awake: {0}", gameDirectorGo);
        this.audioSource = this.GetComponent<AudioSource>();
        Debug.LogFormat("Awake: {0}", audioSource);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //마우스 왼쪽 클릭 하면 (화면을 클릭하면)Ray를 만들자 
        if (Input.GetMouseButtonDown(0))
        {
            //화면상의 좌표 -> Ray 객체를 생성 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float maxDistance = 100f;
            //ray를 눈으로 확인 
            Debug.DrawRay(ray.origin, ray.direction * maxDistance, Color.green, 2f);

            //ray와 collider의 충돌을 검사하는 메서드 
            //out매개변수를 사용하려면 변수정의를 먼저 해야 한다 
            RaycastHit hit;
            //out키워드를 사용해서 인자로 넣어라 
            //Raycast 메서드에서 연산된 결과를 hit 매개변에 넣어줌 
            //충돌 되었다면 ~ true , 아니면 false 
            if (Physics.Raycast(ray, out hit, maxDistance))
            {
                //The impact point in world space where the ray hit the collider.
                Debug.LogFormat("hit.point:{0}", hit.point);

                //this.gameObject.transform.position = hit.point;
                //바구니의 위치를 충돌한 지점으로 변경
                //this.transform.position = hit.point;
                //x좌표와 z좌표를 반올림 
                float x = Mathf.RoundToInt(hit.point.x);
                float z = Mathf.RoundToInt(hit.point.z);
                //새로운 좌표를 만들고 이동 
                this.transform.position = new Vector3(x, 0, z);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);

        if (other.tag == "apple") 
        {
            Debug.Log("득점");

            Debug.LogFormat("audioSource: {0}", this.audioSource);
            Debug.LogFormat("appleSfx: {0}", this.appleSfx);

            this.audioSource.PlayOneShot(this.appleSfx);
            this.gameDirector.IncreaseScore(100);
            this.gameDirector.UpdateScoreUI();
            Destroy(other.gameObject);  //사과또는 폭탄을 제거 
        }
        else if(other.tag == "bomb")
        {
            Debug.Log("감점");
            Debug.LogFormat("audioSource: {0}", this.audioSource);
            Debug.LogFormat("bombSfx: {0}", this.bombSfx);

            this.audioSource.PlayOneShot(this.bombSfx);
            this.gameDirector.DecreaseScore(50);
            this.gameDirector.UpdateScoreUI();
            Destroy(other.gameObject);  //사과또는 폭탄을 제거 
        }
        
    }
}
