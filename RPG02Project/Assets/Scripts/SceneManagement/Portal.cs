using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;


namespace RPG.SceneManagement 
{
    public class Portal : MonoBehaviour
    {

        enum DestinationIdentifier
        {
            A, B, C, D, E
        }

        [SerializeField] int sceneToLoad = -1;
        [SerializeField] Transform spawnPoint;
        [SerializeField] DestinationIdentifier destination;


        private void OnTriggerEnter(Collider other) 
        {
            if (other.tag == "Player") 
            {

                //Debug.Log("Triggered");
                //SceneManager.LoadScene(sceneToLoad);
                StartCoroutine(Transition());
            }
        }

        private IEnumerator Transition() 
        {

            if (sceneToLoad < 0)
            {
                Debug.LogError("Scene to load not set.");
                yield break;
            }

            DontDestroyOnLoad(gameObject);
            yield return SceneManager.LoadSceneAsync(sceneToLoad);

            Portal otherPortal = GetOtherPortal();
            UpdatePlayer(otherPortal);

            
            Destroy(gameObject);
            

        }

        private void UpdatePlayer(Portal otherPortal) 
        {

            GameObject player = GameObject.FindWithTag("Player");
            player.GetComponent<NavMeshAgent>().Warp(otherPortal.spawnPoint.position);
            player.transform.rotation = otherPortal.spawnPoint.rotation;

            //player.GetComponent<NavMeshAgent>().enabled = false;
            //player.GetComponent<NavMeshAgent>().enabled = true;

        }

        private Portal GetOtherPortal()
        {
            foreach (Portal portal in FindObjectsOfType<Portal>())
            {
                if (portal == this) continue;
                if (portal.destination != destination) continue;

                return portal;
            }

            return null;
        }
    }


}

