using System.Security.Cryptography;
using PathCreation.Examples;
using UnityEngine;

public class InputInteractions : MonoBehaviour
{
    public GameObject vehicle;
    private bool haveDive = false;
    public Animator animator;
    
    
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //transform.position = new Vector3(100, 100, 0);
        

        

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
        animator.SetBool("Diving",true);
        if (haveDive == false)
        {
            PathFollower pathFollower = vehicle.GetComponent<PathFollower>();
            float tempHeightOffset = pathFollower.heightOffsetAnimation - pathFollower.widthOffset;
            pathFollower.heightOffsetAnimation = Mathf.Max(tempHeightOffset, -pathFollower.widthOffset);
            haveDive = true;
            Invoke("Up", 1.1f);
        }
        else
        {
            return;
        }

    }

    public void Up()
    {
        animator.SetBool("Diving",false);
        PathFollower pathFollower = vehicle.GetComponent<PathFollower>();
        float tempHeightOffset = pathFollower.heightOffsetAnimation + pathFollower.widthOffset;
        pathFollower.heightOffsetAnimation = Mathf.Min(tempHeightOffset, pathFollower.widthOffset);
        haveDive = false;
    }
}
