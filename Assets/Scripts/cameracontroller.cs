using UnityEngine;

public class CameraController : MonoBehaviour
{
    //odadan odaya geçiş
    [SerializeField] private float hiz;
    private float currentPosX;
    private Vector3 velocity = Vector3.zero;



    private void Update()
    {
        //odadan odaya geçiş
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPosX, transform.position.y, transform.position.z), ref velocity, hiz);


    }

    public void MoveToNewRoom(Transform _newRoom)
    {
        currentPosX = _newRoom.position.x;
    }
    //karakteri takip eden kamera

    //[SerializeField] private Transform player;
    //[SerializeField] private float aheadDistance;
    //[SerializeField] private float kamerahiz;
    //private float lookAhead;

    //karakteri takip eden kamera
   // private void private void Update()
   // {


        //transform.position = new Vector3(player.position.x + lookAhead, transform.position.y, transform.position.z);
        //lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x), Time.deltaTime * kamerahiz);
   // }
}