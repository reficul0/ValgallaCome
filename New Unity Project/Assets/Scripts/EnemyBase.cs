using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour {

    [Range(3,0)]
    public ushort enemy_health;

    private int reward = 5;

    public delegate void Action(int reward);
    public static event Action isDie;


 
    void Start () {
        enemy_health = 3;
	}
	
	
	void FixedUpdate () {
        if (enemy_health == 0){
            isDie(reward);
            Destroy(this.gameObject);
        }
	}
    

}
