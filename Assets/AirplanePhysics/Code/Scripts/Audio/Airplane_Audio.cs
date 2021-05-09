using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Qubitech
{

    

    public class Airplane_Audio : MonoBehaviour
    {
        #region Variable

        [Header("Airplane Audio Properties")]
        public IP_Base_Airplane_Input input;
        public AudioSource idleSource;
        public AudioSource fullThrottleSource;
        private float finalVolume;
        public float maxPitchValue = 1.2f;
        private float finalPitchValue;

        public float FinalVolume
        {
            get { return finalVolume; }
        }

        #endregion
        #region Builtin Methods
        
        // Start is called before the first frame update
        void Start()
        {
            if (fullThrottleSource)
            {
                fullThrottleSource.volume = 0f;
            }

        }

        // Update is called once per frame
        void Update()
        {
            if (input)
            {
                HandleAudio();
            }
        }
        #endregion
        #region Custom Method

        protected virtual void HandleAudio()
        {
            finalVolume = Mathf.Lerp(0f, 1f, input.Throttle);
            finalPitchValue = Mathf.Lerp(1f, maxPitchValue, input.Throttle);
            if (fullThrottleSource)
            {
                idleSource.volume = 1 - finalVolume;
                fullThrottleSource.volume = finalVolume;
                fullThrottleSource.pitch = finalPitchValue;
            }
        }

        #endregion
    }

}