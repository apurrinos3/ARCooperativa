using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapsScene : MonoBehaviour
{

    public void VolverMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void SituarEdificio()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex  +1);

    }
}
