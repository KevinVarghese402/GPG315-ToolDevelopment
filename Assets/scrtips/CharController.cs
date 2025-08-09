using UnityEngine;

public class CharController : MonoBehaviour
{
    private CharacterController _characterController;

    public float speed = 20f; 
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update() 
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        
        _characterController.Move(speed * move * Time.deltaTime);
    }
}
