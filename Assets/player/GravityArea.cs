using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityArea : MonoBehaviour
{

    Dictionary<string, (Vector2, Vector2, Vector2, int)> dictOfGravitySource;

    public GameObject lever1;
    public GameObject lever2;
    scrt_lever leverComponent1;
    scrt_lever leverComponent2;

    // Start is called before the first frame update
    void Awake()
    {
        dictOfGravitySource = new Dictionary<string, (Vector2, Vector2, Vector2, int)>();

        // Add all gravity source points
        // Min bound, Max bound, gravitySource
        dictOfGravitySource.Add("-33 39 -32 40", (new Vector2(-33, 39), new Vector2(-32, 40), new Vector2(-32, 39), -1));
        dictOfGravitySource.Add("1 39 2 40", (new Vector2(1, 39), new Vector2(2, 40), new Vector2(1, 39), -1));
        dictOfGravitySource.Add("-33 25 -32 26", (new Vector2(-33, 25), new Vector2(-32, 26), new Vector2(-32, 26), -1));
        dictOfGravitySource.Add("1 25 2 26", (new Vector2(1, 25), new Vector2(2, 26), new Vector2(1, 26), -1));
        dictOfGravitySource.Add("-26 24 -25 25", (new Vector2(-26, 24), new Vector2(-25, 25), new Vector2(-26, 24), 1));
        dictOfGravitySource.Add("-23 24 -22 25", (new Vector2(-23, 24), new Vector2(-22, 25), new Vector2(-22, 24), 1));
        dictOfGravitySource.Add("-23 19 -22 20", (new Vector2(-23, 19), new Vector2(-22, 20), new Vector2(-22, 20), 1));
        dictOfGravitySource.Add("-25 -10 -24 -9", (new Vector2(-25, -10), new Vector2(-24, -9), new Vector2(-24, -9), -1));
        dictOfGravitySource.Add("-20 -11 -19 -10", (new Vector2(-20, -11), new Vector2(-19, -10), new Vector2(-20, -11), 1));
        dictOfGravitySource.Add("-11 -10 -10 -9", (new Vector2(-11, -10), new Vector2(-10, -9), new Vector2(-11, -9), -1));
        dictOfGravitySource.Add("-10 -5 -9 -4", (new Vector2(-10, -5), new Vector2(-9, -4), new Vector2(-9, -5), 1));
        dictOfGravitySource.Add("-3 -2 -2 -1", (new Vector2(-3, -2), new Vector2(-2, -1), new Vector2(-2, -2), 1));
        dictOfGravitySource.Add("-4 -4 -3 -3", (new Vector2(-4, -4), new Vector2(-3, -3), new Vector2(-4, -3), -1));
        dictOfGravitySource.Add("3 -2 4 -1", (new Vector2(3, -2), new Vector2(4, -1), new Vector2(3, -2), 1));
        dictOfGravitySource.Add("4 -4 5 -3", (new Vector2(4, -4), new Vector2(5, -3), new Vector2(5, -3), -1));
        dictOfGravitySource.Add("17 -5 18 -4", (new Vector2(17, -5), new Vector2(18, -4), new Vector2(17, -5), 1));
        dictOfGravitySource.Add("17 -11 18 -10", (new Vector2(17, -11), new Vector2(18, -10), new Vector2(17, -10), 1));
        dictOfGravitySource.Add("8 -11 9 -10", (new Vector2(8, -11), new Vector2(9, -10), new Vector2(9, -10), 1));
        dictOfGravitySource.Add("7 -8 8 -7", (new Vector2(7, -8), new Vector2(8, -7), new Vector2(7, -8), -1));
        dictOfGravitySource.Add("17 -22 18 -21", (new Vector2(17, -22), new Vector2(18, -21), new Vector2(17, -21), 1));
        dictOfGravitySource.Add("26 -27 27 -26", (new Vector2(26, -27), new Vector2(27, -26), new Vector2(26, -26), -1));
        dictOfGravitySource.Add("22 -28 23 -27", (new Vector2(22, -28), new Vector2(23, -27), new Vector2(23, -28), 1));
        dictOfGravitySource.Add("21 -31 22 -30", (new Vector2(21, -31), new Vector2(22, -30), new Vector2(21, -30), -1));
        dictOfGravitySource.Add("-10 -31 -9 -30", (new Vector2(-10, -31), new Vector2(-9, -30), new Vector2(-9, -30), -1));
        dictOfGravitySource.Add("-11 -28 -10 -27", (new Vector2(-11, 28), new Vector2(-10, -27), new(-11, 28), 1));
        dictOfGravitySource.Add("-19 -27 -18 -26", (new Vector2(-19, -27), new Vector2(-18, -26), new Vector2(-18, -26), -1));

    }

    void Start()
    {
        lever1 = GameObject.Find("Lever2 (1)");
        lever2 = GameObject.Find("Lever5");
        leverComponent1 = lever1.GetComponent<scrt_lever>();
        leverComponent2 = lever2.GetComponent<scrt_lever>();

    }

    void FixedUpdate()
    {
        // Add all areas and map ids of area.
        string upper_key = string.Format("{0} {1} {2} {3}",
            Mathf.Floor(PlayerState.playerCoordinateVector.x + 0.3f * PlayerState.gravityVector.x),
            Mathf.Floor(PlayerState.playerCoordinateVector.y + 0.3f * PlayerState.gravityVector.y),
            Mathf.Ceil(PlayerState.playerCoordinateVector.x + 0.3f  * PlayerState.gravityVector.x),
            Mathf.Ceil(PlayerState.playerCoordinateVector.y + 0.3f * PlayerState.gravityVector.y));

        if (dictOfGravitySource.ContainsKey(upper_key))
        {

            Vector2 gravitySourceVector = dictOfGravitySource[upper_key].Item3;
            PlayerState.gravitySourceVector = new Vector2(gravitySourceVector.x, gravitySourceVector.y);
            PlayerState.gravitySourceDirection = dictOfGravitySource[upper_key].Item4;
        }

        else
        {
            PlayerState.gravitySourceVector = new Vector2(0, 0); // naive exception.
        }


        // Add all areas and map ids of area.
        string lower_key = string.Format("{0} {1} {2} {3}",
            Mathf.Floor(PlayerState.playerCoordinateVector.x + 0.7f * PlayerState.gravityVector.x),
            Mathf.Floor(PlayerState.playerCoordinateVector.y + 0.7f * PlayerState.gravityVector.y),
            Mathf.Ceil(PlayerState.playerCoordinateVector.x + 0.7f * PlayerState.gravityVector.x),
            Mathf.Ceil(PlayerState.playerCoordinateVector.y + 0.7f * PlayerState.gravityVector.y));

        if (dictOfGravitySource.ContainsKey(lower_key))
        {

            Vector2 gravitySourceVector = dictOfGravitySource[lower_key].Item3;
            PlayerState.gravitySourceVector = new Vector2(gravitySourceVector.x, gravitySourceVector.y);
            PlayerState.gravitySourceDirection = dictOfGravitySource[lower_key].Item4;
        }

        else
        {
            PlayerState.gravitySourceVector = new Vector2(0, 0); // naive exception.
        }

        if (leverComponent1.leverCode == 0)
        {
            if (dictOfGravitySource.ContainsKey("17 -11 18 -10"))
            {
                Debug.Log("Gravity Source Off");

                dictOfGravitySource.Remove("17 -11 18 -10");
            }

        }

        else
        {
            if(!dictOfGravitySource.ContainsKey("17 -11 18 -10"))
            {
                Debug.Log("Gravity Source On");

                dictOfGravitySource.Add("17 -11 18 -10", (new Vector2(17, -11), new Vector2(18, -10), new Vector2(17, -10), 1));
            }
        }
    
        if (leverComponent2.leverCode == 0)
        {
            if (dictOfGravitySource.ContainsKey("-20 -11 -19 -10"))
            {
                Debug.Log("Gravity Source Off");

                dictOfGravitySource.Remove("-20 -11 -19 -10");
            }
        }

        else
        {
            if (!dictOfGravitySource.ContainsKey("-20 -11 -19 -10"))
            {
                Debug.Log("Gravity Source On");

                dictOfGravitySource.Add("-20 -11 -19 -10", (new Vector2(-20, -11), new Vector2(-19, -10), new Vector2(-20, -11), 1));
            }
        }

        //Debug.Log(PlayerState.gravityVector);
    }
}
