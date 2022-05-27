using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject path;
    
    Transform targetPathNode;
    int pathNodeIndex = 0;
    
    public float speed = 3f;
    public float health = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
        path = GameObject.Find("Path");
    }

    void GetNextPathNode()
    {
        if(pathNodeIndex < path.transform.childCount) {
            targetPathNode = path.transform.GetChild(pathNodeIndex);
            pathNodeIndex++;
        }
        else {
            targetPathNode = null;
            //ReachedDestination();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (targetPathNode == null)
        {
            GetNextPathNode();
            if (targetPathNode == null)
            {
                ReachedDestination();
                return;
            }
        }

        Vector3 direction = targetPathNode.position - this.transform.localPosition;
        float distThisFrame = speed * Time.deltaTime;

        if (direction.magnitude <= distThisFrame)
        {
            targetPathNode = null;
        }
        else
        {
            transform.Translate(direction.normalized * distThisFrame, Space.World);
        }
    }

    void ReachedDestination()
    {
        GameObject.FindObjectOfType<Manager>().LoseLife();
        Destroy(gameObject);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
