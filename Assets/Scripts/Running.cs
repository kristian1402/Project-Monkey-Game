using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Running : MonoBehaviour
{
    SaveDataReader saveData;
    public Sprite Run1;
    public Sprite Run2;
    public Sprite Run3;
    string[] values;
    public Sprite mySprite;
    public GameObject exclusion;
    public float moveSpeed = 5f;
    public float jumpHeight = 100f;
    bool onfloor = true;
    float increasedGravityScale = 4f;
    float normalGravityScale = 1f;
    TMP_Text running;
    TMP_Text lostText;
    int score = 5;
    GameObject spriteObject;
    GameObject harambae;

    float zRotation;
    bool lost = false;
    float level;

void Start()
{
    saveData = GameObject.FindObjectOfType<SaveDataReader>();
    running = GameObject.Find("running").GetComponent<TMP_Text>();
    lostText = GameObject.Find("lost").GetComponent<TMP_Text>();

    harambae = GameObject.Find("HaramBae");


    // Create a new game object
    spriteObject = new GameObject("Sprite Object");

    // Add a Sprite Renderer component to the game object
    SpriteRenderer spriteRenderer = spriteObject.AddComponent<SpriteRenderer>();

    // Assign the sprite to the Sprite Renderer component
    spriteRenderer.sprite = mySprite;

    // Add a BoxCollider2D component to the game object
    BoxCollider2D boxCollider2D = spriteObject.AddComponent<BoxCollider2D>();

    // Add a Rigidbody2D component to the game object
    //Rigidbody2D rigidbody2D = spriteObject.AddComponent<Rigidbody2D>();

    // Set the gravity scale to 0
    //rigidbody2D.gravityScale = 0;

    // Set the position of the game object
    spriteObject.transform.position = new Vector3(10, -3, -1);
    values = saveData.getData();
    level = float.Parse(values[6]);
    Debug.Log(level);

    StartCoroutine(MoveText(spriteObject));
    StartCoroutine(ChangeImage());
}

IEnumerator MoveText(GameObject spriteObject)
{
    while (lost == false)
    {
        
        string excludedTag = exclusion.tag;
        
        // Move the sprite to the left
        Vector3 currentPosition = spriteObject.transform.position;
        Vector3 newPosition = new Vector3(currentPosition.x - score * Time.deltaTime, currentPosition.y, -1);
        
        // Check if the tag of the current game object is not the excluded tag

            // Update the position of the sprite
        spriteObject.transform.position = newPosition;
        

        // Wait for the next frame
        yield return null;
    }
}
void Update()
    
    {

    if (lost == false)
    {
        mainrunner();
    }
    if (lost == true)
    {
        lostText.text = "Exhausted";
    }

    }
void mainrunner(){
        zRotation = harambae.transform.rotation.eulerAngles.z;
    Vector3 dodgepostition = spriteObject.transform.position;   
    if (zRotation <= 300 && zRotation >= 60)
    {
        lost = true;
    }

    if (lost == false)
    {
        lostText.text = "";
    }


    running.text = (score-5).ToString();

    if (dodgepostition.x < -10)
    {
        Vector3 newPosition2 = new Vector3(10, -3, 0);
        score++;
        spriteObject.transform.position = newPosition2;
    }
    // Get the keyboard input
    float horizontalInput = Input.GetAxis("Horizontal");
    float verticalInput = Input.GetAxis("Vertical");

    // Move the excluded object left or right
    Vector3 currentPosition = exclusion.transform.position;
    Vector3 newPosition = new Vector3(currentPosition.x + horizontalInput * moveSpeed * Time.deltaTime, currentPosition.y, currentPosition.z);
    exclusion.transform.position = newPosition;
    if (currentPosition.x < -8)
    {
        Vector3 xnegative = new Vector3(-8, currentPosition.y , currentPosition.z);
        exclusion.transform.position = xnegative;
    }

        if (currentPosition.x > 8)
    {
        Vector3 xpositive = new Vector3(8, currentPosition.y , currentPosition.z);
        exclusion.transform.position = xpositive;
    }

    if (currentPosition.y < -1.17f)
    {
        Vector3 touchfloor = new Vector3(currentPosition.x, -1.17f , currentPosition.z);
        exclusion.transform.position = touchfloor;
        onfloor = true;
    }

    if (Input.GetKeyDown(KeyCode.DownArrow))
    {
        exclusion.GetComponent<Rigidbody2D>().gravityScale = increasedGravityScale;
    }

    // Reset gravity scale when down arrow key is released
    if (Input.GetKeyUp(KeyCode.DownArrow))
    {
        exclusion.GetComponent<Rigidbody2D>().gravityScale = normalGravityScale;
    }

    // Make the excluded object jump
    if (verticalInput > 0 && onfloor == true)
    {
        Vector3 jumpVector = new Vector3(0, jumpHeight, 0);
        exclusion.GetComponent<Rigidbody2D>().velocity = jumpVector;
        onfloor = false;
    }

}
IEnumerator ChangeImage()
{
    // Get the Image component of the exclusion game object
    Image exclusionImage = exclusion.GetComponent<Image>();

    while (lost == false)
    {
        // Set the source image of the exclusion Image component to Run1
        exclusionImage.sprite = Run3;

        // Wait for half a second
        yield return new WaitForSeconds(0.5f);

        // Set the source image of the exclusion Image component to Run2
        exclusionImage.sprite = Run1;

        // Wait for half a second
        yield return new WaitForSeconds(0.5f);

        exclusionImage.sprite = Run3;
        // Wait for half a second
        yield return new WaitForSeconds(0.5f);

        exclusionImage.sprite = Run2;
        // Wait for half a second
        yield return new WaitForSeconds(0.5f);
    }
}
}