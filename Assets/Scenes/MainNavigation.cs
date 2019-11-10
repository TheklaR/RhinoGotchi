using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainNavigation : MonoBehaviour
{
	public void GoToScene(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
