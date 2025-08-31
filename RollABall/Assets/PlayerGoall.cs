using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerGoall : MonoBehaviour
{
    private void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Goal"))
        {
            Time.timeScale = 0f;
        }
    }
}
