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

    public void Die()
    {
        enemy_health = 0;
    }

    /// <summary>
    /// Нанесение урона игроку
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            foreach (var contact in collision.contacts)
                if (contact.normal.y >= 0)
                {
                    collision.gameObject.GetComponent<PlayerStats>().TakeDamage();
                    return;
                }
        }
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
