using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour{

    public delegate void Action();
    public static event Action isDie;

    private short health;

    private int money;

    private void OnEnable() { 
        EnemyBase.isDie += IncreacseMoney;//Enemy.isDie
    }
    private void OnDisable(){
        EnemyBase.isDie -= IncreacseMoney;
    }

    void Start(){
        health = 3;
        money = 0;
    }

    // Update is called once per frame
    void FixedUpdate(){
        if (health == 0)
            Die();
    }
    private void Die(){
        if (health == 0){
            //TODO
            //animation of die
            //text "u die ballsucker"
            //reload scene or load scene "valhalla"
        }
    }

    public void IncreacseMoney(int reward) {
        money += reward;
        Debug.Log(money);
    }
}

  

   

