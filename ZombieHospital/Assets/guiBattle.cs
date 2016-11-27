using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace battle
{
    class battle : MonoBehaviour
    {
        String test = "";
        Boolean testVal = true;
        Rect testRect = new Rect(100, 0, 100, 50);

        void Start()
        {
            test = "Enemy Health:";
            testVal = true;
        }

        void OnGUI()
        {
            if (testVal)
            {
                GUIStyle enemyHealth = new GUIStyle(GUI.skin.label);
                enemyHealth.normal.textColor = Color.red;
                GUI.Label(testRect, test, enemyHealth);
            }
        }
    }
}
