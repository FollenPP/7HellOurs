using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collidable : MonoBehaviour
{
    public ContactFilter2D filter;
    private BoxCollider2D collide;
    private BoxCollider2D[] hits = new BoxCollider2D [10];

    public virtual void Start()
    {
        collide = GetComponent<BoxCollider2D>();
    }
    
    public virtual void Update()
    {
       collide.OverlapCollider(filter, hits);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null)
                continue;

            OnCollide(hits[i]);
            hits[i] = null;
            
        }
    }

    public virtual void OnCollide(Collider2D coll)
    {
        Debug.Log(coll.name);
    }
}
