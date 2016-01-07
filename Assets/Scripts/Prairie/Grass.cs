using UnityEngine;
using System.Collections;
using UnityTool.Libgame;

/// <summary>
/// 普利亚大草原上的草原
/// </summary>
public class Grass : MonoBehaviour {

    /// <summary>
    /// 草的数量
    /// </summary>
    public float numbers;

    /// <summary>
    /// 草的饱和数目
    /// </summary>
    public int saturation = 100000;
    // Use this for initialization
    void Start () {
        State state = new State("WaitForGrass", null, WaitForGrass, null);
        StateMachine.ChangeState("Grass", state);
    }

    void WaitForGrass(string stateName)
    {
        if (numbers == 0)
        {
            if (Random.Range(0, 100) == 1)
            {
                numbers += 1;
                State state = new State("GrowGrass", null, GrowGrass, null);
                StateMachine.ChangeState("Grass", state);
            }
        }
    }

    void GrowGrass(string stateName)
    {
        if (numbers == 0)
        {
            StateMachine.ChangeState("Grass", "WaitForGrass");
            return;
        }
        if(numbers >= saturation)
        {
            State state = new State("Overload", null, Overload, null);
            StateMachine.ChangeState("Grass", state);
            return;
        }
        numbers += saturation * 0.01F;
    }

    void Overload(string stateName)
    {
        if (numbers >= saturation)
        {
            numbers = numbers * 0.9F + saturation * 0.01F;
            return;
        }
        StateMachine.ChangeState("Grass", "GrowGrass");
    }

}
