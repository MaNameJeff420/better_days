using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_select_controller : MonoBehaviour
{
    private gameController gameController;
    private int local_character = 0;
    [SerializeField] private GameObject map_screen;
    [SerializeField] private GameObject character_screen;
    private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<gameController>() ;
        StartCoroutine(character_select());
    }
    public void lenin_pick()
    {
        local_character = 1;
    }
    public void sam_pick()
    {
        local_character = 2;
    }

    private IEnumerator character_select()
    {
        while(local_character == 0)
        {
            yield return null;
        }
        gameController.player_one_character = local_character;
        local_character = 0;
        while (local_character == 0)
        {
            yield return null;
        }
        gameController.player_two_character = local_character;
        character_screen.SetActive(false);
        map_screen.SetActive(true);
        local_character = 0;
        while (local_character == 0)
        {
            yield return null;
        }
        gameController.map_number = local_character;
    }

}
