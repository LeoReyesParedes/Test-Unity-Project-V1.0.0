using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewComputer : MonoBehaviour
{
    public static ViewComputer instance_view;
    [SerializeField] private GameObject _panel_computer_list = null;
    
    private void Awake() {
        instance_view        = this;
        _panel_computer_list = GameObject.Find("Content_list");
    }
    public void DrawUIComputer(){
        GameObject computerTemplate = _panel_computer_list.transform.GetChild(0).gameObject;
        /// computerTemplate.SetActive(true);

        int allChildren = _panel_computer_list.transform.childCount;
        int n           = ControllerComputer.instance_controller.all_computer.computers.Length;
        
        for(int i = 0; i < n; i++){
            // Creación de computadores

            string id_item = ControllerComputer.instance_controller.all_computer.computers[i].id;
            GameObject g   = Instantiate(computerTemplate, _panel_computer_list.transform);
            
            // Parte 1: Nombre
            GameObject _image = g.transform.GetChild(0).gameObject;
            _image.transform.GetChild(1).GetComponent<Text>().text = ControllerComputer.instance_controller.all_computer.computers[i].nombre;
            
            // Parte 2: Datos: {procesador, memoria, almacenamiento}
            GameObject _data = g.transform.GetChild(1).gameObject;
            _data.transform.GetChild(0).GetComponent<Text>().text = ControllerComputer.instance_controller.all_computer.computers[i].procesador;
            _data.transform.GetChild(1).GetComponent<Text>().text = ControllerComputer.instance_controller.all_computer.computers[i].memoria;
            _data.transform.GetChild(2).GetComponent<Text>().text = ControllerComputer.instance_controller.all_computer.computers[i].almacenamiento;
            
            // Parte 3: Boton eliminar por {id} => id_item
            GameObject _button = g.transform.GetChild(2).gameObject;
            _button.gameObject.GetComponent<Button>().onClick.AddListener(delegate{DeleteComputer(id_item);});
        }
        for(int i = 0; i < allChildren; i++){

            // Elimina computadores anteriores
            GameObject computersTemplate = _panel_computer_list.transform.GetChild(i).gameObject;
            Destroy(computersTemplate);
        }
    }
    public void DeleteComputer(string id){
        StartCoroutine(ControllerComputer.instance_controller.ComputersDelete(id));
    }
}