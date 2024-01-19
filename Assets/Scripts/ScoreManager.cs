using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] GameObject scoreText;

    public float Score = 0f; //sets score to 0

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() //takes the player to the completion scene once the score reaches 100 or above
    {
        scoreText.GetComponent<TextMeshProUGUI>().text = Score.ToString(); 
        if (Score >= 100)
        {
            SceneManager.LoadScene("CompletionScreen");
        }
    }
}
