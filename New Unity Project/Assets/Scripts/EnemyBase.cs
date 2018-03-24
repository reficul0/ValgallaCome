using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{

    [Range(3,0)]
    public ushort enemy_health;

    // Награда за убийство моба
    // TODO: в зависимости от класса моба должа меняться
    private uint reward;

    public delegate void Action(uint reward);
    // Событие смерти моба
    public static event Action isDie;

    void Start ()
    {
        enemy_health = 3;
        reward = 5;
    }
	
	void FixedUpdate ()
    {
        if (enemy_health == 0)
        {
            // Эммитим сигнал о смерти
            isDie(reward);
            // Разушаем объект
            Destroy(this.gameObject);
        }
	}
}
