using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

namespace Qubitech
{
    public class PostProcessingControl : MonoBehaviour
{
        #region variable

        
        public Volume volume;
        VolumeProfile volumeProfile;
        public IP_Airplane_Controller controller;
        public AnimationCurve ChromaticCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);



        #endregion

        #region Builtin Method
        // Start is called before the first frame update
        void Start()
    {
            volume = GetComponent<Volume>();
            volumeProfile = volume.sharedProfile;
            
    }

    // Update is called once per frame
    void Update()
    {
            HandleChromaticAbs();
    }
        #endregion
        #region custom Method

        void HandleChromaticAbs()
        {
            if(!volumeProfile.TryGet<ChromaticAberration>(out var chrom))
            {
                chrom = volumeProfile.Add<ChromaticAberration>();
            }

            Debug.Log("ch "+chrom.intensity.value);

            chrom.intensity.value = ChromaticCurve.Evaluate(controller.maxxforce);

        }

        #endregion
    }
}