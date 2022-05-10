using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void DOChangeScene(string _name) {
        SceneManager.LoadScene(_name);
    }
}
