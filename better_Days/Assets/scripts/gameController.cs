using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameController : MonoBehaviour
{
    public int player_one_character;
    public int player_two_character;
    public int map_number = 0;
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
        while (map_number == 0)
        {
            yield return null;
        }
        SceneManager.LoadScene(2);
    }
}
