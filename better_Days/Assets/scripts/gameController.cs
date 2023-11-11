using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameController : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        StartCoroutine(main_menu());
    }

    private IEnumerator main_menu()
    {
        while (!Input.GetKeyDown(KeyCode.Space)){
            yield return null;
        }
        SceneManager.LoadScene(1);

    }
}
