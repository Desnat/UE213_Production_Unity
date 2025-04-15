using System.Security.Cryptography;
using PathCreation.Examples;
using UnityEngine;

public class InputInteractions : MonoBehaviour
{
    public GameObject vehicle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = new Vector3(100, 100, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Left()
    {
        PathFollower pathFollower = vehicle.GetComponent<PathFollower>();
        float tempOffset = pathFollower.offset - pathFollower.widthOffset;
        pathFollower.offset = Mathf.Max(tempOffset, -pathFollower.widthOffset);
    }

    public void Right()
    {

        PathFollower pathFollower = vehicle.GetComponent<PathFollower>();
        float tempOffset = pathFollower.offset + pathFollower.widthOffset;
        pathFollower.offset = Mathf.Min(tempOffset, pathFollower.widthOffset);
    }

    public void Down()
    {
        PathFollower pathFollower = vehicle.GetComponent<PathFollower>();
        float tempHeightOffset = pathFollower.heightOffset - pathFollower.widthOffset;
        pathFollower.heightOffset = Mathf.Max(tempHeightOffset, -pathFollower.widthOffset);
        Invoke("Up",2);

    }

    public void Up()
    {
        PathFollower pathFollower = vehicle.GetComponent<PathFollower>();
        float tempHeightOffset = pathFollower.heightOffset + pathFollower.widthOffset;
        pathFollower.heightOffset = Mathf.Min(tempHeightOffset, pathFollower.widthOffset);
    }
}
