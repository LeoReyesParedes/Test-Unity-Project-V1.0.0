using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ControllerComputer : MonoBehaviour
{
    public static ControllerComputer instance_controller;
    private string url_computer_list   = "http://testingcomputers.000webhostapp.com/Tests/get_all_computer.php";
    private string url_computer_delete = "http://testingcomputers.000webhostapp.com/Tests/delete_computer.php";
    
    public Computer all_computer;

    private void Awake() {
        instance_controller = this;
    }

    private void Start() {
        StartCoroutine(ComputersList());
    }
    
    public IEnumerator ComputersList() {
        WWWForm form        = new WWWForm();
        UnityWebRequest www = UnityWebRequest.Get(url_computer_list);
        yield return www.SendWebRequest();

        if(www.result == UnityWebRequest.Result.ConnectionError){
            Debug.Log("Error Server: " + www.error);
        }else{
            Debug.Log("Response " + www.downloadHandler.text);

            all_computer = JsonUtility.FromJson<Computer>(www.downloadHandler.text);
            ViewComputer.instance_view.DrawUICustomer();
        }
    }
    public IEnumerator ComputersDelete(string id) {
        WWWForm form        = new WWWForm();
        form.AddField("id", id);
		UnityWebRequest www = UnityWebRequest.Post(url_computer_delete, form);
		yield return www.SendWebRequest();

		if(www.result == UnityWebRequest.Result.ConnectionError){
			Debug.Log("Error Server!, " + www.error);
		}else{
            Debug.Log("Response " + www.downloadHandler.text);
            
			all_computer = JsonUtility.FromJson<Computer>(www.downloadHandler.text);
            ViewComputer.instance_view.DrawUICustomer();
		}
    }
}