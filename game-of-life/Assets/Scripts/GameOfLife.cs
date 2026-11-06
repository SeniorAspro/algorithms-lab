using System;
using Unity.VisualScripting;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] int width = 160;
    [SerializeField] int height = 90;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bool[,] grid = new bool[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                grid[x, y] = UnityEngine.Random.value < 0.25f;
            }
        }

        int alive = 0, not_alive = 0;
        foreach (bool cell in grid)
            if (cell) alive++;
            else if (!cell) not_alive++;

        Debug.Log("Alive: " + alive);
        Debug.Log("Not alive: " + not_alive);

        Texture2D texture2D = new Texture2D(width, height);
        texture2D.filterMode = FilterMode.Point;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Color color = grid[x, y] ? Color.white : Color.black;
                texture2D.SetPixel(x, y, color);
            }
        }
        texture2D.Apply();

        GameObject gameObjectGrid = new GameObject("Grid");
        SpriteRenderer spriteRenderer = gameObjectGrid.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = Sprite.Create(texture2D, new Rect(0, 0, width, height), new Vector2(0.5f, 0.5f), 1f);
        

        // 1. Ensure the camera is actually set to Orthographic mode
        Camera.main.orthographic = true;
        // 2. Set the orthographic size (e.g., 5.0 units)
        Camera.main.orthographicSize = 50.0f;




    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
