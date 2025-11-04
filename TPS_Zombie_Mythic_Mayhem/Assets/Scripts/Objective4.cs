using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Objective4 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Vehicle")
        {
            // Complete Objective
            ObjectivesComplete.occurrence.GetObjectivesDone(true, true, false, true);

            SceneManager.LoadScene("MainMenu");
        }
    }
}
