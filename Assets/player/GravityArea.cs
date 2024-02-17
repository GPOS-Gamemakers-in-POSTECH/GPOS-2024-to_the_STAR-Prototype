using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityArea : MonoBehaviour
{
    
    Dictionary<string, (Vector2, Vector2, Vector2)> dictOfGravitySource;
    // Start is called before the first frame update
    void Start()
    {
        dictOfGravitySource = new Dictionary<string, (Vector2, Vector2, Vector2)> ();

        // Add all gravity source points
        // Min bound, Max bound, gravitySource
        dictOfGravitySource.Add("-33 39 -32 40", (new Vector2(-33, 39), new Vector2(-32, 40), new Vector2(-33, 40)));
        dictOfGravitySource.Add("1 39 2 40", (new Vector2(1, 39), new Vector2(2, 40), new Vector2(2, 40)));
        dictOfGravitySource.Add("-33 25 -32 26", (new Vector2(-33, 25), new Vector2(-32, 26), new Vector2(-33, 25)));
        dictOfGravitySource.Add("1 25 2 26", (new Vector2(1, 25), new Vector2(2, 26), new Vector2(2, 25)));
        dictOfGravitySource.Add("-23 19 -22 20", (new Vector2(-23, 19), new Vector2(-22, 20), new Vector2(-22, 20)));
        dictOfGravitySource.Add("-25 -10 -24 9", (new Vector2(-25, -10), new Vector2(-24, 9), new Vector2(-25, -10)));
        dictOfGravitySource.Add("-20 -11 -19 -10", (new Vector2(-20, -11), new Vector2(-19, -10), new Vector2(-20, -11)));
        dictOfGravitySource.Add("-11 -10 -10 -9", (new Vector2(-11, -10), new Vector2(-10, -9), new Vector2(-10, -10)));
        dictOfGravitySource.Add("-10 -5 -9 -4", (new Vector2(-10, -5), new Vector2(-9, -4), new Vector2(-9, -5)));
        dictOfGravitySource.Add("-4 -4 -3 -3", (new Vector2(-4, -4), new Vector2(-3, -3), new Vector2(-3, -4)));
        dictOfGravitySource.Add("4 -4 5 -3", (new Vector2(4, -4), new Vector2(-5, -3), new Vector2(4, -4)));
        dictOfGravitySource.Add("17 -5 18 -4", (new Vector2(17, -5), new Vector2(18, -4), new Vector2(17, -5)));
        dictOfGravitySource.Add("17 -11 18 -10", (new Vector2(17, -11), new Vector2(18, -10), new Vector2(17, -10)));
        dictOfGravitySource.Add("8 -10 9 -9", (new Vector2(8, -10), new Vector2(9, -9), new Vector2(9, -9)));
        dictOfGravitySource.Add("7 -8 8 -7", (new Vector2(7, -8), new Vector2(8, -7), new Vector2(8, -7)));
        dictOfGravitySource.Add("26 -20 27 -19", (new Vector2(26, -20), new Vector2(27, -19), new Vector2(27, -20)));
        dictOfGravitySource.Add("17 -22 18 -21", (new Vector2(17, -22), new Vector2(18, -21), new Vector2(17, -21)));
        dictOfGravitySource.Add("26 -27 27 -26", (new Vector2(26, -27), new Vector2(27, -26), new Vector2(27, -27)));
        dictOfGravitySource.Add("22 -28 23 -27", (new Vector2(22, -28), new Vector2(23, -27), new Vector2(23, -28)));
        dictOfGravitySource.Add("21 -31 22 -30", (new Vector2(21, -31), new Vector2(22, -30), new Vector2(22, -31)));
        dictOfGravitySource.Add("-10 -31 -9 -30", (new Vector2(-10, -31), new Vector2(-9, -30), new Vector2(-10, -31)));
        dictOfGravitySource.Add("-11 -10 -10 -9", (new Vector2(-11, -28), new Vector2(-10, -27), new Vector2(-11, -28)));
        dictOfGravitySource.Add("-11 -10 -10 -9", (new Vector2(-19, -27), new Vector2(-18, -26), new Vector2(-19, -27)));

    }


    void FixedUpdate()
    {
        // Add all areas and map ids of area.
        string key = string.Format("{0} {1} {2} {3}",
            Mathf.Floor(PlayerState.playerCoordinateVector.x),
            Mathf.Floor(PlayerState.playerCoordinateVector.y),
            Mathf.Ceil(PlayerState.playerCoordinateVector.x),
            Mathf.Ceil(PlayerState.playerCoordinateVector.y));

        if (dictOfGravitySource.ContainsKey(key))
        {

            Vector2 gravitySourceVector = dictOfGravitySource[key].Item3;
            PlayerState.gravitySourceVector = new Vector2(gravitySourceVector.x, gravitySourceVector.y);
        }

        else
        {
            PlayerState.gravitySourceVector = new Vector2(0, 0); // naive exception.
        }
    }
}
