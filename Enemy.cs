using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //protected
    public float HP, attack, defense;
    public GameObject hurt;
    public void Death()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        GetComponent<Collider2D>().enabled = false;//防止摧毁时二次碰撞
        GetComponent<Animator>().SetBool("death", true);
        SoundManager.instance.EnemyDeathAudio();
        
    }
    public void ChangeHP(float attacked)
    {
        float damage = attacked * (1f - defense / (defense + 10));
        HP -= damage;
        SoundManager.instance.EnemyHurtAudio();
        hurt.SetActive(true);
        Invoke("HurtClose", 0.2f);
    }
    void HurtClose()
    {
        hurt.SetActive(false);
    }
    void Destroy()
    {
        Destroy(gameObject);
    }
}
