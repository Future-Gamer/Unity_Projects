using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameExit : MonoBehaviour
{
    public void exitGame ()
    {
        if (!Application.isEditor)
        {
            Application.Quit ();
        }
    }
}
