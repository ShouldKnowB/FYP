using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuitApplicationOnClick : MonoBehaviour
{
    [SerializeField] int sceneIndex;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(delegate ()
        {
            Application.Quit();
        });
    }
}
