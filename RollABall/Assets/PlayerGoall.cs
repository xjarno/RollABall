using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class PlayerGoall : MonoBehaviour
{
    public GameObject winText;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Goal"))
        {
           winText.SetActive(true);
            Time.timeScale = 0f;

        }
    }
}
