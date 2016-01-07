using UnityEngine;
using System.Collections;
using UnityTool.Libgame;

/// <summary>
/// 普利亚大草原上生活着成群的羊与狼，羊吃草，狼吃羊，没羊的时候，狼也会吃狼，究竟生态平衡的情况会是如何呢
/// </summary>
public class Prairie : MonoBehaviour {

    static Prairie prairie;
    /// <summary>
    /// 狼群
    /// </summary>
    public Wolves wolves;

    /// <summary>
    /// 羊群
    /// </summary>
    public Sheep sheep;

    /// <summary>
    /// 草地
    /// </summary>
    public Grass grass;

	// Use this for initialization
	void Start () {
        prairie = this;
    }
	public static Prairie GetInstance()
    {
        return prairie;
    }

    // Update is called once per frame
    void Update () {
	
	}
}
