using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectivesComplete : MonoBehaviour
{
    [Header("Objectives to Complete")]
    public GameObject objective1;
    public GameObject objective2;
    public GameObject objective3;
    public GameObject objective4;

    public static ObjectivesComplete occurrence;


    private void Awake()
    {
        occurrence = this;
    }

    public void GetObjectivesDone(bool obj1, bool obj2, bool obj3, bool obj4)
    {
        // Objective - 1
        if (obj1 == true)
        {
            TextMeshProUGUI objective1_Text = objective1.GetComponent<TextMeshProUGUI>();
            if (objective1_Text != null)
            {
                objective1_Text.text = "01.  Find the Rifle  [Completed]";
                objective1_Text.color = Color.green;
            }
            else
            {
                Debug.LogError("TextMeshProUGUI component not found on Objective 1 GameObject.");
            }
        }
        else
        {
            TextMeshProUGUI objective1_Text = objective1.GetComponent<TextMeshProUGUI>();
            if (objective1_Text != null)
            {
                objective1_Text.text = "01.  Find the Rifle";
                objective1_Text.color = Color.white;
            }
            else
            {
                Debug.LogError("TextMeshProUGUI component not found on Objective 1 GameObject.");
            }
        }

        // Objective - 2
        if (obj2 == true)
        {
            TextMeshProUGUI objective2_Text = objective2.GetComponent<TextMeshProUGUI>();
            if (objective2_Text != null)
            {
                objective2_Text.text = "02.  Locate the Villagers  [Completed]";
                objective2_Text.color = Color.green;
            }
            else
            {
                Debug.LogError("TextMeshProUGUI component not found on Objective 2 GameObject.");
            }
        }
        else
        {
            TextMeshProUGUI objective2_Text = objective2.GetComponent<TextMeshProUGUI>();
            if (objective2_Text != null)
            {
                objective2_Text.text = "02.  Locate the Villagers";
                objective2_Text.color = Color.white;
            }
            else
            {
                Debug.LogError("TextMeshProUGUI component not found on Objective 2 GameObject.");
            }
        }
        
        // Objective - 3
        if (obj3 == true)
        {
            TextMeshProUGUI objective3_Text = objective3.GetComponent<TextMeshProUGUI>();
            if (objective3_Text != null)
            {
                objective3_Text.text = "03.  Find a Vehicle  [Completed]";
                objective3_Text.color = Color.green;
            }
            else
            {
                Debug.LogError("TextMeshProUGUI component not found on Objective 3 GameObject.");
            }
        }
        else
        {
            TextMeshProUGUI objective3_Text = objective3.GetComponent<TextMeshProUGUI>();
            if (objective3_Text != null)
            {
                objective3_Text.text = "03.  Find a Vehicle";
                objective3_Text.color = Color.white;
            }
            else
            {
                Debug.LogError("TextMeshProUGUI component not found on Objective 3 GameObject.");
            }
        }

        // Objective - 4
        if (obj4 == true)
        {
            TextMeshProUGUI objective4_Text = objective4.GetComponent<TextMeshProUGUI>();
            if (objective4_Text != null)
            {
                objective4_Text.text = "04.  Take all of the villagers into vehicle  [Completed]";
                objective4_Text.color = Color.green;
            }
            else
            {
                Debug.LogError("TextMeshProUGUI component not found on Objective 4 GameObject.");
            }
        }
        else
        {
            TextMeshProUGUI objective4_Text = objective4.GetComponent<TextMeshProUGUI>();
            if (objective4_Text != null)
            {
                objective4_Text.text = "04.  Take all of the villagers into vehicle";
                objective4_Text.color = Color.white;
            }
            else
            {
                Debug.LogError("TextMeshProUGUI component not found on Objective 4 GameObject.");
            }
        }
    }
}
