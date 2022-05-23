using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laberinto : MonoBehaviour
{
    [Header("View Stuff")]
    public GameObject characterPrefab;

    [Header("Prefabs and stuff")]
    public GameObject cellPrefab;

    [Header("Size")]
    public int width;
    public int height;

    private Celdas[,] cellGrid;

    private Stack<Celdas> stack;

    private bool generationStarted = false;

    public int cellSize;
    // Start is called before the first frame update
    void Start()
    {
        this.cellGrid=new Celdas[this.width,this.height];
        this.stack=new Stack<Celdas>();
        
    }
    IEnumerator InstantiteCells()
    {
        for (int i = 0; i < this.width; i++)
        {
            for (int j = 0; j < this.height; j++)
            {
                GameObject cellGO = Instantiate(this.cellPrefab, new Vector3(i* cellSize, 0, j* cellSize), Quaternion.identity);
                this.cellGrid[i,j]=cellGO.GetComponent<Celdas>();
            }
            yield return null;
        }
        Celdas start = this.cellGrid[Random.Range(0, this.width), Random.Range(0, this.height)];
        start.isVisited=true;
        this.stack.Push(start);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && !this.generationStarted)
        {
            this.generationStarted = true;
            StartCoroutine(InstantiteCells());
        }
        if (this.stack.Count>0)
        {
            Celdas current = this.stack.Peek();
            bool valid = false;
            int checks = 0;
            int current_x = (int)current.transform.position.x/ cellSize;
            int current_y = (int)current.transform.position.z/cellSize;

            while (checks<10 && !valid)
            {
                checks++;
                WallOrientation direction = (WallOrientation)Random.Range(0, 4);

                switch (direction)
                {
                    case WallOrientation.WEST:
                        if (current_x>0)
                        {
                            Celdas next = this.cellGrid[current_x - 1, current_y];
                            if (!next.isVisited)
                            {
                                current.HideWall(WallOrientation.WEST);
                                next.HideWall(WallOrientation.EAST);
                                next.isVisited = true;
                                this.stack.Push(next);
                                valid = true;
                            }
                        }
                        break;
                    case WallOrientation.NORTH:
                    if (current_y<(this.height - 1))
                        {
                            Celdas next = this.cellGrid[current_x, current_y+1];
                            if (!next.isVisited)
                            {
                                current.HideWall(WallOrientation.NORTH);
                                next.HideWall(WallOrientation.SOUTH);
                                next.isVisited = true;
                                this.stack.Push(next);
                                valid=true;
                            }
                        }
                        break;
                    case WallOrientation.EAST:
                    if (current_x<(this.width-1))
                        {
                            Celdas next = this.cellGrid[current_x + 1, current_y];
                            if (!next.isVisited)
                            {
                                current.HideWall(WallOrientation.EAST);
                                next.HideWall(WallOrientation.WEST);
                                next.isVisited=true;
                                this.stack.Push(next);
                                valid=(true);
                            }
                        }
                        break;
                    case WallOrientation.SOUTH:
                        if (current_y > 0)
                        {
                            Celdas next = this.cellGrid[current_x, current_y-1];
                            if (!next.isVisited)
                            {
                                current.HideWall(WallOrientation.SOUTH);
                                next.HideWall(WallOrientation.NORTH);
                                next.isVisited = true;
                                this.stack.Push(next);
                                valid = true;
                            }
                        }
                            break;
                }
            }
            if (!valid)
            {
                this.stack.Pop();
            }
        }

    }
    private void OnDrawGizmos()
    {
        if (this.stack==null)
        {
            return;
        }
        Celdas[] celdas = this.stack.ToArray();
        foreach (var item in celdas)
        {
            Gizmos.DrawSphere(item.transform.position, 0.25f);
        }
    }
}
