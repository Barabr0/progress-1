using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float minX = -8f;
    public float maxX = 8f;
    public float minY = -4.5f;
    public float maxY = 4.5f;

    public GameObject gameOverText;
    public TMP_Text scoreText;
    public GameObject Restart;

    private bool isGameOver = false;
    private int score = 0;

    void Update()
    {
        if (isGameOver) return;

        float moveX = 0f;
        float moveY = 0f;

        if (Keyboard.current.aKey.isPressed) moveX = -1f;
        if (Keyboard.current.dKey.isPressed) moveX = 1f;
        if (Keyboard.current.wKey.isPressed) moveY = 1f;
        if (Keyboard.current.sKey.isPressed) moveY = -1f;

        transform.Translate(new Vector3(moveX, moveY, 0) * speed * Time.deltaTime);

        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Coin")
        {
            Debug.Log("i got this coin!");
            score = score + 1;
            scoreText.text = "Score: " + score;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.name == "Enemy")
        {
            Debug.Log("GAME OVER!");
            isGameOver = true;
            gameOverText.SetActive(true);
            Restart.SetActive(true);
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}