using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyMain : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> baskets;
    // Start is called before the first frame update

    [SerializeField]
    private Button btnStartGame;

    void Start()
    {
        this.btnStartGame.onClick.AddListener(() => {
            this.LoadGameScene();
        });
    }

    void Update()
    {
        //���̸� �����
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 1000f, Color.red, 2f);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000f)) {
                Debug.Log(hit.collider.gameObject.name);

                GameObject foundBasketGo = this.baskets.Find(x => x == hit.collider.gameObject);

                //int index = -1;
                //for (int i = 0; i < this.baskets.Count; i++) {
                //    if (foundBasketGo == this.baskets[i]) {
                //        index = i;
                //        break;
                //    }
                //}
                //Debug.LogFormat("<color=yellow>index: {0}</color>", index);

                int selectedBasketType = this.baskets.IndexOf(foundBasketGo);

                Debug.LogFormat("<color=yellow>selectedBasketType: {0}</color>", selectedBasketType);

                InfoManager.instance.selectedBasketType = selectedBasketType;

                foreach (var go in this.baskets) {
                    if (go != foundBasketGo) {
                        //���� ���� ���� �͵� 
                        go.SetActive(false);    //��Ȱ��ȭ 
                    }
                }
            }
        }
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}
