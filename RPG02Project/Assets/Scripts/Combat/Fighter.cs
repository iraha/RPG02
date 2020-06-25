using System.Collections;
using System.Collections.Generic;
using RPG.Movement;
using UnityEngine;

namespace RPG.Combat 
{


    public class Fighter : MonoBehaviour
    {

        [SerializeField] float weaponRange = 2f;

        Transform target;

        // Update is called once per frame
        void Update()
        {
            if (target == null) return;

            if (!GetInRange()) 
            {
                GetComponent<Mover>().MoveTo(target.position);
            }
            else 
            {
                GetComponent<Mover>().Stop();
            }


        }

        private bool GetInRange() 
        {

            return Vector3.Distance(transform.position, target.position) < weaponRange;
        }

        public void Attack(CombatTarget combatTarget)
        {
            target = combatTarget.transform;
            Debug.Log("Attack");

        }

        public void Cancel()
        {

            target = null;

        }

    }

}
