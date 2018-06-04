using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Zoo
{
    public class Debugger : MonoBehaviour
    {
        public void Log(string message)
        {
            Debug.Log(message);
        }
    }
}