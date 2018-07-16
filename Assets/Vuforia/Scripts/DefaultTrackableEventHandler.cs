/*==============================================================================
Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine;
using UnityEngine.SceneManagement;

namespace Vuforia
{
    /// <summary>
    /// A custom handler that implements the ITrackableEventHandler interface.
    /// </summary>
    public class DefaultTrackableEventHandler : MonoBehaviour,
                                                ITrackableEventHandler
    {


        private int foundCount = 0;
        private int lostCount = 0;
        private bool onTrack;


        #region PRIVATE_MEMBER_VARIABLES
 
        private TrackableBehaviour mTrackableBehaviour;
    
        #endregion // PRIVATE_MEMBER_VARIABLES



        #region UNTIY_MONOBEHAVIOUR_METHODS
    

      
        void Start()
        {
          


             mTrackableBehaviour = GetComponent<TrackableBehaviour>();
            if (mTrackableBehaviour)
            {
                mTrackableBehaviour.RegisterTrackableEventHandler(this);
            }
        }

        #endregion // UNTIY_MONOBEHAVIOUR_METHODS



        #region PUBLIC_METHODS

        /// <summary>
        /// Implementation of the ITrackableEventHandler function called when the
        /// tracking state changes.
        /// </summary>
        public void OnTrackableStateChanged(
                                        TrackableBehaviour.Status previousStatus,
                                        TrackableBehaviour.Status newStatus)
        {

            /*if (newStatus == TrackableBehaviour.Status.DETECTED ||
                newStatus == TrackableBehaviour.Status.TRACKED ||
                newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)*/
            if (newStatus == TrackableBehaviour.Status.DETECTED ||
                newStatus == TrackableBehaviour.Status.TRACKED ||
                newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED


                )
            {
                OnTrackingFound();
            }
            else 
            {
                OnTrackingLost();
                //SceneManager.LoadScene("Main_Scene_1");
            }

           
        }

        #endregion // PUBLIC_METHODS



        #region PRIVATE_METHODS


        private void OnTrackingFound()
        {
            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

            foundCount++;

            Debug.Log("Ontracking Found");

            onTrack = true;

            // Enable rendering:
            foreach (Renderer component in rendererComponents)
            {
                component.enabled = true;
              
    }

            // Enable colliders:
            foreach (Collider component in colliderComponents)
            {
                component.enabled = true;
            }

            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
        }


        private void OnTrackingLost()
        {
            lostCount++;

            onTrack = false;


            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

            Debug.Log("Ontracking Lost");

            // Disable rendering:
            foreach (Renderer component in rendererComponents)
            {
                component.enabled = false;
                

            }

            // Disable colliders:
            foreach (Collider component in colliderComponents)
            {
                component.enabled = false;
                

            }

            if(foundCount==1 && lostCount != null)
            {
                SceneManager.LoadScene("Main_Scene_1");
            }
            onTrack = false;

            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
     



            
       



        }


        #endregion // PRIVATE_METHODS

    }
}
