using UnityEngine;
using System.Collections;
using UnityTool.Libgame;

/// <summary>
/// 普利亚大草原上的羊群
/// </summary>
public class Sheep : MonoBehaviour {

    /// <summary>
    /// 羊的数量
    /// </summary>
    public float numbers;
    // Use this for initialization
    void Start () {
        State state = new State("WaitForSheep", null, WaitForSheep, null);
        StateMachine.ChangeState("Sheep", state);
    }
    void WaitForSheep(string stateName)
    {
        if (numbers == 0 && Prairie.GetInstance().grass.numbers != 0) 
        {
            if (Random.Range(0, 100) == 1)
            {
                numbers += 1;
                State state = new State("GrowSheep", null, GrowSheep, null);
                StateMachine.ChangeState("Sheep", state);
            }
        }
    }

    void GrowSheep(string stateName)
    {
        if (numbers == 0)
        {
            StateMachine.ChangeState("Sheep", "WaitForSheep");
            return;
        }
        float grass = Prairie.GetInstance().grass.numbers;
        numbers = numbers * 0.9F + grass / 100;
        Prairie.GetInstance().grass.numbers -= numbers/10 + Prairie.GetInstance().grass.numbers/100;
        if (Prairie.GetInstance().grass.numbers <= 0)
        {
            Prairie.GetInstance().grass.numbers = 0;
        }
    }
}
