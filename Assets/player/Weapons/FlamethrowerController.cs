using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamethrowerController : MonoBehaviour
{
    // particle system
    private ParticleSystem fire;

    // pointing vector
    private float angle;
    private Vector2 target, mouse;

    // state
    private bool isFire = false;
    private bool isSleep = false;
    
    // stopwatch
    System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();

    // coroutine
    Coroutine coroutineController = null;

    // Start is called before the first frame update
    void Start()
    {
        fire = GetComponent<ParticleSystem>();

        fire.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            watch.Reset();
            if (!isFire && !isSleep)
            {
                coroutineController = StartCoroutine(Attack());
                watch.Start();
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (coroutineController != null)
            {
                StopCoroutine(coroutineController);
                watch.Stop();
                Debug.Log("Elapsed time: " + watch.ElapsedMilliseconds / 1000.0f + "s");
                StartCoroutine(Cooltime(1 + watch.ElapsedMilliseconds / 1000.0f));
            }
            isFire = false;
            coroutineController = null;
        }

        // rotate flaemthrower
        target = transform.parent.position;
        mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        angle = Mathf.Atan2(mouse.y - target.y, mouse.x - target.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.Euler(-angle, 90, 0);
    }

    void OnParticleCollision(GameObject other)
    {
        if (other.tag == "enemy")
        {
            Debug.Log("Hit enemy with flamethrower!");
        }
    }

    IEnumerator Attack()
    {
        isFire = true;

        for (int i = 0; i < 20; i++)
        {
            fire.Emit(1);
            yield return new WaitForSeconds(0.1f);
        }

        isFire = false;
        StartCoroutine(Cooltime(3.0f));
    }

    IEnumerator Cooltime(float time)
    {
        isSleep = true;

        yield return new WaitForSeconds(time);

        isSleep = false;
        Debug.Log("Cooltime is over!");
    }
}
