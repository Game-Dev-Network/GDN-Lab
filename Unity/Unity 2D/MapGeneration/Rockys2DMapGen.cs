using System;
using UnityEngine;

public class Rockys2DMapGen : MonoBehaviour
{
    //init chunks (Chunks are prefabs that are squared, so example: 64x64 rooms
    public static GameObject Chunk01;
    public static GameObject Chunk02;
    public static GameObject Chunk03;
    public static GameObject Chunk04;
    public GameObject[] Chunks = //get chunks into array
    {
        Chunk01,
        Chunk02,
        Chunk03,
        Chunk04
    };
    public int Across; 
    public int Down; 
    public Vector3 Start_pos = new Vector3(0, 0); //init start position
    // Use this for level initialization

    void Start()
    {
        float GameObject_Height = Chunks[0].GetComponent<SpriteRenderer>().bounds.size.y; //init prefab height for spacing calculation
        float GameObject_Width = Chunks[0].GetComponent<SpriteRenderer>().bounds.size.x; //init prefab width for spacing calculation
        System.Random rnd = new System.Random(); //init randomizer
        int x = rnd.Next(0, Chunks.Length); //use Chunks.Length, so we dont have a static value
        int i = 2; //to keep multiplication smooth
        x = rnd.Next(1, Chunks.Length);
        Vector3 Chunk_X = new Vector3(GameObject_Width, 0); //set up Chunk X axis measurement
        Vector3 Chunk_Y = new Vector3(0, GameObject_Height); //set up Chunk Y axis measurement
        int Column = 1;
        while (Column <= Across) //Loop through the X Axis
        {
            Chunk_X = new Vector3(GameObject_Width, 0);
            Chunk_Y = new Vector3(0, GameObject_Height);
            for (int Loop = 0; Loop < Down; Loop++) // generation loop
            {
                Instantiate(Chunks[x], Chunk_X * Column + Start_pos + Chunk_Y, transform.rotation);
                Chunk_Y = new Vector3(0, GameObject_Height * i); //multiply the width by 2
                x = rnd.Next(0, Chunks.Length);
                i++;
            }
            i = 2;
            Column++;
        }
    }
    // Update is called once per frame
    private void Update()
    {
        
    }
}
