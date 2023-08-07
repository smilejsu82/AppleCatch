using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMain : MonoBehaviour
{
    [SerializeField]
    private Text txtScore;
    [SerializeField]
    private Button btnLobby;
    [SerializeField]
    private Button btnRestart;

    [SerializeField]
    private List<GameObject> basketPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        this.txtScore.text = string.Format("{0} Point", InfoManager.instance.score);

        this.btnLobby.onClick.AddListener(() => {
            InfoManager.instance.score = 0;
            InfoManager.instance.selectedBasketType = -1;
            SceneManager.LoadScene("LobbyScene");
        });

        this.btnRestart.onClick.AddListener(() => {
            InfoManager.instance.score = 0;
            SceneManager.LoadScene("GameScene");
        });

        this.CreateBasket();
    }

    private void CreateBasket()
    {
        int index = InfoManager.instance.selectedBasketType;


        GameObject prefab = this.basketPrefabs[index];
        GameObject basketGo = Instantiate(prefab);
        basketGo.transform.position = Vector3.zero;
    }

}
