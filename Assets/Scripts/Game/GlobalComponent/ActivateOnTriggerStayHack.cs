using UnityEngine;

namespace Game.GlobalComponent
{
	public class ActivateOnTriggerStayHack : MonoBehaviour
	{
		private void OnTriggerStay(Collider other)
		{
		}

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.tag=="Pole")
            {
                print("collides with pole");
                collision.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                collision.gameObject.GetComponent<Rigidbody>().useGravity = true;
                collision.gameObject.GetComponent<DestroyMe>().enabled = true;
            }
        }
    }
}
