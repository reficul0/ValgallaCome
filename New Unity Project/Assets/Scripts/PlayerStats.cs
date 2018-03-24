using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{

    private short health;
    private uint money;

    private HpBar hpBar;

    public delegate void Action();
    // Событие, вызываемое во время убийства персонажей
    public static event Action isDie;

    public delegate void ActionDamage(uint damage);
    // Событие, вызываемое во время получения игроком урона
    public static event ActionDamage takeDamage;



    void Start()
    {
        // Установим значения по умолчанию
        health = 3;
        money = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Умираем если здоровье упало до 0
        if (health == 0)
            Die();
    }

    private void Die()
    {
        if (health == 0)
        {
            //TODO: Воспроизводим анимацию смерти
            //TODO: text "u die ballsucker"
            //TODO: reload scene or load scene "valhalla
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void TakeDamage(uint damage) {
        --health;
        takeDamage(damage);

       // Debug.Log(health);
    }
    /// <summary>
    /// Вызывается по сигналу смерти моба
    /// и дает денежную награду за него герою
    /// </summary>
    /// <param name="reward">Количество денег</param>
    public void IncreacseMoney(uint reward)
    {
        money += reward;
        Debug.Log(money);
    }
}

  

   

