using System.Collections;
using System.Collections.Generic;
using RPG.Core;
using RPG.Movement;
using UnityEngine;

namespace RPG.Combat 
{


    public class Fighter : MonoBehaviour, IAction
    {

        [SerializeField] float weaponRange = 2f;
        [SerializeField] float timeBetweenAttacks = 0.5f;
        [SerializeField] float weaponDamage = 10f;

        Transform target;

        float timeSinceLastAttack = 0f;

        // Update is called once per frame
        void Update()
        {

            timeSinceLastAttack += Time.deltaTime;

            if (target == null) return;

            if (!GetInRange()) 
            {
                GetComponent<Mover>().MoveTo(target.position);
            }
            else
            {
                GetComponent<Mover>().Cancel();
                AttackBehaviour();
            }


        }

        private void AttackBehaviour()
        {
            if (timeSinceLastAttack > timeBetweenAttacks) 
            {
                GetComponent<Animator>().SetTrigger("attack");
                timeBetweenAttacks = 0f;
            }

        }

        private bool GetInRange() 
        {

            return Vector3.Distance(transform.position, target.position) < weaponRange;
        }

        public void Attack(CombatTarget combatTarget)
        {

            GetComponent<ActionScheduler>().StartAction(this);
            target = combatTarget.transform;
            //Debug.Log("Attack");

        }

        public void Cancel()
        {

            target = null;

        }

        

        // Animation Event
        void Hit() 
        {
            Health healthComponent = target.GetComponent<Health>();
            healthComponent.TakeDamage(weaponDamage);
            //GetComponent<Animation>().SetTrigger("attack");
        }

    }

}
