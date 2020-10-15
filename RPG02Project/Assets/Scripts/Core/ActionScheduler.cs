using System;
using System.Collections;
using System.Collections.Generic;
using RPG.Combat;
using UnityEngine;

namespace RPG.Core 
{

    public class ActionScheduler : MonoBehaviour
    {

        IAction currentAction;

        public void StartAction(IAction action) 
        {
            if (currentAction == action) return;

            if (currentAction != null) 
            {
                currentAction.Cancel();
                //Debug.Log("Cancel" + currentAction);
            }
            currentAction = action;

        }

        public void CancelCurrentAntion() 
        {
            StartAction(null);
        }

    }

}
