using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityArea : MonoBehaviour
{
    
    Dictionary<string, Vector2> gravitySource;
    // Start is called before the first frame update
    void Start()
    {
        gravitySource = new Dictionary<string, Vector2> ();

        // Add all gravity source points

        gravitySource.Add("sample", new Vector2(0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        
        // Add all areas and map ids of area.




    }
}
