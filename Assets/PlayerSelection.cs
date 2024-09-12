using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class PlayerSelection : MonoBehaviour
{
    public Image p1Selector;
    public Image p2Selector;
    public Color p1Color = Color.blue;
    public Color p2Color = Color.red;
    public PjInfo[,] grid = new PjInfo[2, 2]; // Asumiendo que tienes 4 botones en una cuadrícula 2x2
    public Image characterImage1, characterImage2;
    private int p1X = 0, p1Y = 0;
    private int p2X = 1, p2Y = 1;
    private bool p1Selected = false;
    private bool p2Selected = false;
    private int p1CharacterID;
    private int p2CharacterID;
    public GameObject[] characterContainerP1;
    public GameObject[] characterContainerP2;

    void Start()
    {
        p1Selector.color = p1Color;
        p2Selector.color = p2Color;

        // Inicializar el grid dinámicamente
        InitializeGrid();

        UpdateSelectors();
    }

    void InitializeGrid()
    {
        // Asumiendo que los botones están bajo un objeto padre llamado "Grid"
        Transform gridParent = GameObject.Find("Grid").transform;
        PjInfo[] buttons = gridParent.GetComponentsInChildren<PjInfo>();

        foreach (PjInfo button in buttons)
        {
            grid[button.posX, button.posY] = button.GetComponent<PjInfo>();
            Debug.Log(button);
        }
    }

    void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
        // Movimiento P1
        if (Input.GetKeyDown(KeyCode.W)) { p1Y = Mathf.Clamp(p1Y - 1, 0, 1); }
        if (Input.GetKeyDown(KeyCode.S)) { p1Y = Mathf.Clamp(p1Y + 1, 0, 1); }
        if (Input.GetKeyDown(KeyCode.A)) { p1X = Mathf.Clamp(p1X - 1, 0, 1); }
        if (Input.GetKeyDown(KeyCode.D)) { p1X = Mathf.Clamp(p1X + 1, 0, 1); }

        // Selección P1
        if (Input.GetKeyDown(KeyCode.Space) && !p1Selected)
        {
            p1Selected = true;
            p1CharacterID = grid[p1X, p1Y].charId;
            ShowCharacterImage(p1CharacterID, characterImage1, 1);
            Debug.Log($"P1 seleccionado {p1CharacterID}");
        }

        // Movimiento P2
        if (Input.GetKeyDown(KeyCode.UpArrow)) { p2Y = Mathf.Clamp(p2Y - 1, 0, 1); }
        if (Input.GetKeyDown(KeyCode.DownArrow)) { p2Y = Mathf.Clamp(p2Y + 1, 0, 1); }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) { p2X = Mathf.Clamp(p2X - 1, 0, 1); }
        if (Input.GetKeyDown(KeyCode.RightArrow)) { p2X = Mathf.Clamp(p2X + 1, 0, 1); }

        // Selección P2
        if (Input.GetKeyDown(KeyCode.Return) && !p2Selected)
        {
            p2Selected = true;
            p2CharacterID = grid[p2X, p2Y].charId;
            ShowCharacterImage(p2CharacterID, characterImage2, 2);
            Debug.Log($"P2 seleccionado {p2CharacterID}");
        }

        UpdateSelectors();

        if (p1Selected && p2Selected)
        {
            StartCoroutine(LoadNextScene());
        }
    }

    void UpdateSelectors()
    {
        if (!p1Selected) { p1Selector.transform.position = grid[p1X, p1Y].transform.position; }
        if(!p2Selected){ p2Selector.transform.position = grid[p2X, p2Y].transform.position; }
    }

    void ShowCharacterImage(int characterID, Image personajeboton, int P)
    {
        switch (P)
        {
            case 1:
                Instantiate(characterContainerP1[characterID]);
                break;

            case 2:
                Instantiate(characterContainerP2[characterID]);
                break;
        }
        //PjInfo button = FindButtonById(characterID);
        //if (button != null)
        //{
        //    Image buttonImage = button.GetComponent<Image>();
        //    if (buttonImage != null)
        //    {
        //        Debug.Log("deberia mostrar imagen");
        //        Color color = personajeboton.color;
        //        personajeboton.sprite = buttonImage.sprite;
        //        color.a = 1f;
        //        personajeboton.color = color;
        //    }
        //    else
        //    {
        //        Debug.LogError("Button Image component is missing.");
        //    }
        //}
        //else
        //{
        //    Debug.LogError("Button with character ID not found.");
        //}
    }

    PjInfo FindButtonById(int characterID)
    {
        foreach (PjInfo button in grid)
        {
            if (button != null && button.charId == characterID)
            {
                return button;
            }
        }
        return null;
    }

    IEnumerator LoadNextScene()
    {
        Debug.Log("Seleccionados");
        SelectedCharacters.p1CharacterID = p1CharacterID;
        SelectedCharacters.p2CharacterID = p2CharacterID;
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("SampleScene");
    }
}
