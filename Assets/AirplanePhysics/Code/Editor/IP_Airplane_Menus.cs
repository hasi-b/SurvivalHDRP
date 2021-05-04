using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Qubitech
{

    public static class IP_Airplane_Menus 
    {
       [MenuItem("Airplane Tools/Create New Airplane")]
       public static void CreateNewAirPlane()
        {
            GameObject curSelcted = Selection.activeGameObject;
            if (curSelcted)
            {
                IP_Airplane_Controller curController = curSelcted.AddComponent<IP_Airplane_Controller>();
                GameObject curCOG = new GameObject("COG");
                curCOG.transform.SetParent(curSelcted.transform);
                curController.centerOfGravity = curCOG.transform;
            }
        }


    }
}
