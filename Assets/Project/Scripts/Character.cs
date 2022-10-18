using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField]protected float health=5;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual IEnumerator MoveRoutine()
    {
        yield return  null;
    }
    
    public abstract Vector3 SetInput();

}
