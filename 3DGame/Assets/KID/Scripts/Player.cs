using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class Player : MonoBehaviour
{
    [Header("結束畫面")]
    public GameObject final;
    [Header("吃寶箱音效")]
    public AudioClip soundChest;

    private AudioSource aud;
    private bool dead;

    private void Start()
    {
        aud = GetComponent<AudioSource>();

        Cursor.visible = false;
    }

    private void Update()
    {
        Dead();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "寶箱")
        {
            GetChest(other.gameObject);
        }
    }

    private void GetChest(GameObject obj)
    {
        aud.PlayOneShot(soundChest, 1.5f);
        final.SetActive(true);
        Cursor.visible = true;
        Destroy(obj, 0.1f);
    }

    private void Dead()
    {
        if (!dead && transform.position.y < -1)
        {
            dead = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
