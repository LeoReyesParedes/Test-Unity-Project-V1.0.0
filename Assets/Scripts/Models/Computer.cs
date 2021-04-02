using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public struct Computer{
    [Serializable]
    public struct dates{
        public string id;
        public string nombre;
        public string procesador;
        public string memoria;
        public string almacenamiento;
    }
    public dates[] computers;
    public string state;
}