using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoManager 
{
    //�̱��� 
    public static readonly InfoManager instance = new InfoManager();

    public int selectedBasketType = -1;  //0 : yellow, 1: red, 2 : green 
    public int score;

    //������ 
    private InfoManager() { 

    }
}
