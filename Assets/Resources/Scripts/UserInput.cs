using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UserInput  : MonoBehaviour 
{
    static UserInput instance;
    public static UserInput Instance
    {
        get { return instance; }
    }

    public GameObject card1;
    public GameObject card2;
    private CardManager cardManager;
    private int currentScene = 0;
    public AudioClip stackConfirm;
    // Start is called before the first frame update

    private void Awake()
    {
        
        currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        
    }
    void Start()
    {
        AudioSource audio = GetComponentInChildren<AudioSource>();
        audio.clip = stackConfirm;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(currentScene);
        }
    }

    
    // if card 1 is stackable on card 2
    // cards should stack in the same position and sort downwards
    public void Stack()
    {
        Interactable c1 = card1.GetComponent<Interactable>();
        Interactable c2 = card2.GetComponent<Interactable>();
        float yOffset = 3.0f;
        float zOffset = 0.03f;

        if (c1.value == (c2.value - 1) && c1.color != c2.color)
        {
            c1.gameObject.transform.position = new Vector3(card2.transform.position.x, card2.transform.position.y - yOffset,
           1 + zOffset);
        }

    }

    public void PlaySound()
    {
        GetComponentInChildren<AudioSource>().Play();
    }
}
