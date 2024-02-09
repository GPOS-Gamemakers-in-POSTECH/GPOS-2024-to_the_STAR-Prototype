using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirethrowerController : MonoBehaviour
{
    private ParticleSystem fire;

    // Start is called before the first frame update
    void Start()
    {
        fire = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            fire.Play();
            fire.Emit(1);
        }
        else
        {
            fire.Stop();
        }
    }

    void OnParticleCollision(GameObject other)
    {
        Debug.Log("Collision: " + other.gameObject.name);
        if (other.tag == "enemy")
        {
            Debug.Log("Hit enemy with firethrower!");
        }
    }
}
