using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject tutorial;

    private void Start()
    {
      
        tutorial.SetActive(false);
    }

    public void TurnOnTutorial()
    {
        tutorial.SetActive(true);
    }

}
