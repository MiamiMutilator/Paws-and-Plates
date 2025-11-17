using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CustomerSpawner : MonoBehaviour
{
    [SerializeField] //this array will hold all the customer prefabs
    public GameObject[] customers;

    public float customerInterval = 8f; // how often customers spawn in

    public Transform spawnPoint; // where the customer will spawn
    public Transform waypoint1; // front of the line
    public Transform waypoint2; // middle of the line
    public Transform waypoint3; // end of the line

    public int maxCustomersInScene = 2; // how many customers can spawn at a time

    private Coroutine spawnRoutine;

    private void Awake()
    {
        int spawnerCount = FindObjectsOfType<CustomerSpawner>().Length;
        if (spawnerCount > 1)
            Debug.LogWarning($"CustomerSpawner: found {spawnerCount} instances in scene - this may cause more than {maxCustomersInScene} customers.");
    }

    private void OnEnable()
    {
        if (spawnRoutine == null)
            spawnRoutine = StartCoroutine(SpawnLoop());
    }

    private void OnDisable()
    {
        if (spawnRoutine != null)
        {
            StopCoroutine(spawnRoutine);
            spawnRoutine = null;
        }
    }



    public IEnumerator SpawnLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(customerInterval);

            if (customers == null || customers.Length == 0)
                continue;
            
            Customer[] allCustomers = FindObjectsOfType<Customer>(true); // counts customer in the scene including inactive objects
            int currentCustomers = GameObject.FindGameObjectsWithTag("Customer").Length;
            
            if (currentCustomers >= maxCustomersInScene) // limits how many customers can be in scene
                continue;

            int index = UnityEngine.Random.Range(0, customers.Length); //spawn random customer prefabs that was put in the array

            GameObject prefab = customers[index];
            if (prefab == null)
                continue;

            GameObject move = Instantiate(prefab, spawnPoint);

            Customer cr = move.GetComponent<Customer>();
            if (cr != null)
            {
                cr.waypoints = new Transform[] { waypoint3, waypoint2, waypoint1 };
            }


        }

    }

}
