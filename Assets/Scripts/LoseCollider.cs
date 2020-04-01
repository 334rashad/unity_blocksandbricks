using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    [SerializeField] AudioClip destroySound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioSource.PlayClipAtPoint(destroySound, Camera.main.transform.position);
        FindObjectOfType<SceneLoader>().LoadStartScene();
        
        SceneManager.LoadScene("Start Menu");
    }
}
