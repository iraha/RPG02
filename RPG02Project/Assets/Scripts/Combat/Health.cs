using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Combat 
{

    public class Health : MonoBehaviour
    {

        [SerializeField] float health = 100f;
        [SerializeField] float perDamage = 10f;
        //float death;

        public void TakeDamage(float damage) 
        {

            health = Mathf.Max(health - damage, 0);
            print(health);
        }
    }

}
