using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform target = null;
    private Vector3 offset;
    public LogicScript logic;
    public bool bunnyAlive = true;

    [SerializeField]
    KeyCode keyRestart; 

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position;
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x, target.position.y, target.position.z) + offset, Time.deltaTime * 3);
        
        if (target.position.y < -3 || Input.GetKey(keyRestart))
        {
            logic.gameOver();
            bunnyAlive = false;
            // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
}
