﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{

    [SerializeField] Transform target;

    NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0)) 
        {
            MoveToCursor();
        }
        //Debug.DrawRay(lastRay.origin, lastRay.direction * 100);

        UpdateAnimator();


    }

    private void MoveToCursor() 
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool hasHit = Physics.Raycast(ray, out hit);
        
        if (hasHit) 
        {
            GetComponent<NavMeshAgent>().destination = hit.point;
        }
        
    }

    public void UpdateAnimator()
    {
        Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        float speed = localVelocity.z;
        GetComponent<Animator>().SetFloat("forwardSpeed", speed);
    }
    
}
