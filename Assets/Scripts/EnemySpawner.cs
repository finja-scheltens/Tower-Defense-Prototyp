using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject monsterPrefab;
    private GameObject cloned;
    
    // Start is called before the first frame update
    void Start()
    {
         for (int i = 0; i < 4; i++) 
         {
            cloned = Instantiate(monsterPrefab, new Vector3(-1.6f, 0.5f, -17.6f * i/4), Quaternion.identity); 
         }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
