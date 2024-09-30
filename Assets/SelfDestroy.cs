using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destroy", 7f);
    }
    public virtual void Destroy()
    {
        Destroy(gameObject);
    }
}
