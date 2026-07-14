using UnityEngine;

public class PlayerController : MonoBehaviour
{
    bool isOnGround = false;
    Vector2 grav;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        if(!isOnGround){
            GetGroundState();
            grav = Physics2D.gravity;
            transform.Translate(grav * Time.deltaTime);
        }
        else{
            grav = Vector2.zero;
        }
    }

    void GetGroundState()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, Vector2.down, 1f);

        if (ray.collider != null && ray.collider.gameObject.CompareTag("Floor")){
            Debug.Log("piss");
            isOnGround = true;
        }
        else
        {
            isOnGround = false;
        }
    }
    private void OnCollisionEnter(Collision collision){
        Debug.Log("piss");
        if (collision.gameObject.name == "Floor"){
            isOnGround = true;
        }
        else{
            isOnGround = false;
        }
    }
}
