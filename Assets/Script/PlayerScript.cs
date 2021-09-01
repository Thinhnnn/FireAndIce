using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] Collider myCollider;

    // Start is called before the first frame update
    void Start()
    {
        ignorePlayerCollision();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ignorePlayerCollision()
    {
        myCollider = GetComponent<Collider>();
        //hàm này ngăn va chạm giữa các player
        GameObject[] colliders = GameObject.FindGameObjectsWithTag("Player");
        foreach(GameObject col in colliders)
        {
            Physics.IgnoreCollision(myCollider, col.GetComponent<Collider>());
        }
    }
}
