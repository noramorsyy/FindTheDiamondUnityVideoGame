using UnityEngine;

public class Board : MonoBehaviour
{
    // Size of the board (assuming a square board)
    public int Size;

    // Depth of the board, determining the height of the stacks
    public int Depth;

    // Prefabs for different types of blocks and entities
    public GameObject Block;
    public GameObject Diamond;
    public GameObject DarkBlock;
    public GameObject CreeperBlock;
    public GameObject Enderman;
    public GameObject Grass;
    public GameObject Food;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the game board and spawn initial entities
        CreateBoard();
        CreateDiamond();
        CreateCreeper();
        CreateEnderman();
    }

    // --------------------------------------------------------------------

    // Create the game board using the specified blocks
    private void CreateBoard()
    {
        for (int i = 0; i < Size; i++)
        {
            for (int y = 0; y < Size; y++)
            {
                for (int j = 0; j < Depth; j++)
                {
                    // Instantiate Grass at the top layer
                    if (j == 0)
                        Instantiate(Grass, new Vector3(i, 0, y), Quaternion.identity);
                    // Instantiate regular Blocks in the middle layers
                    else if ((-1 * j) == -1)
                        Instantiate(Block, new Vector3(i, -j, y), Quaternion.identity);
                    // Instantiate DarkBlocks in the lower layers
                    else
                        Instantiate(DarkBlock, new Vector3(i, -j, y), Quaternion.identity);
                }
            }
        }
    }

    // --------------------------------------------------------------------

    // Create a Diamond at a random position on the board
    private void CreateDiamond()
    {
        var position = new Vector3(Random.Range(0, Size), 0, Random.Range(0, Size));
        Instantiate(Diamond, position, Quaternion.identity);
    }

    // Create a Creeper enemy at a random position on the board
    private void CreateCreeper()
    {
        var position = new Vector3(Random.Range(0, Size), 0.5f, Random.Range(0, Size));
        Instantiate(CreeperBlock, position, Quaternion.identity);
    }

    // Create an Enderman enemy at a random position on the board
    private void CreateEnderman()
    {
        var position = new Vector3(Random.Range(0, Size), 0f, Random.Range(0, Size));
        Instantiate(Enderman, position, Quaternion.identity);
    }
}
