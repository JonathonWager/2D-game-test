using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyStats : MonoBehaviour
{
    public int hp;
    public float speed;

    public decimal dmg;
    public int dmg2;

    public float def;

    public int getHp(){
        return hp;
    }
    public decimal getDmg(){
        return dmg;
    }
    public float getSpeed(){
        return speed;
    }
    public float getDef(){
        return def;
    }
    // Start is called before the first frame update
    void Start()
    {
        dmg = (int)dmg2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}