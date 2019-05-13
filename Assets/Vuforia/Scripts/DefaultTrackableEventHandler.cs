/*==============================================================================
Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;



namespace Vuforia
{
    /// <summary>
    /// A custom handler that implements the ITrackableEventHandler interface.
    /// </summary>
    public class DefaultTrackableEventHandler : MonoBehaviour,
                                                ITrackableEventHandler
    {
        //------------Begin Sound----------
        public AudioSource soundTarget;
        public AudioClip clipTarget;
        private AudioSource[] allAudioSources;

        //function to stop all sounds
        void StopAllAudio()
        {
            allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
            foreach (AudioSource audioS in allAudioSources)
            {
                audioS.Stop();
            }
        }

        //function to play sound
        void playSound(string ss)
        {
            clipTarget = (AudioClip)Resources.Load(ss);
            soundTarget.clip = clipTarget;
            soundTarget.loop = false;
            soundTarget.playOnAwake = false;
            soundTarget.Play();
        }

        //-----------End Sound------------

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
            soundTarget = (AudioSource)gameObject.AddComponent<AudioSource>();
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
            if (newStatus == TrackableBehaviour.Status.DETECTED ||
                newStatus == TrackableBehaviour.Status.TRACKED ||
                newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
            {
                OnTrackingFound();
            }
            else
            {
                OnTrackingLost();
            }
        }

        #endregion // PUBLIC_METHODS



        #region PRIVATE_METHODS


        private void OnTrackingFound()
        {
            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

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

            if (mTrackableBehaviour.TrackableName == "flashcard_apel")
            {
                playSound("Audio/apple");
            }

            if (mTrackableBehaviour.TrackableName == "flashcard_pear")
            {
                playSound("Audio/pear");
            }

            if (mTrackableBehaviour.TrackableName == "flashcard_mangga")
            {
                playSound("Audio/mangga");
            }

            if (mTrackableBehaviour.TrackableName == "flashcard_semangka")
            {
                playSound("Audio/semangka");
            }

            if (mTrackableBehaviour.TrackableName == "flashcard_jeruk")
            {
                playSound("Audio/orange");
            }

            if (mTrackableBehaviour.TrackableName == "flashcard_kereta")
            {
                playSound("Audio/train");
            }

            if (mTrackableBehaviour.TrackableName == "flashcard_bike")
            {
                playSound("Audio/sepeda");
            }

            if (mTrackableBehaviour.TrackableName == "flashcard_plane")
            {
                playSound("Audio/airplane");
            }

            if (mTrackableBehaviour.TrackableName == "flashcard_car")
            {
                playSound("Audio/car");
            }

            if (mTrackableBehaviour.TrackableName == "flashcard_boat")
            {
                playSound("Audio/boat");
            }

            if (mTrackableBehaviour.TrackableName == "flashcard_guru")
            {
                playSound("Audio/guru");
            }

            if (mTrackableBehaviour.TrackableName == "flashcard_pengacara")
            {
                playSound("Audio/pengacara");
            }

            if (mTrackableBehaviour.TrackableName == "flashcard_dokter")
            {
                playSound("Audio/dokter");
            }

            if (mTrackableBehaviour.TrackableName == "flashcard_astronot")
            {
                playSound("Audio/astronot");
            }

            if (mTrackableBehaviour.TrackableName == "flashcard_masinis")
            {
                playSound("Audio/masinis");
            }
        }


        private void OnTrackingLost()
        {
            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

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

            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
            StopAllAudio();
        }

        #endregion // PRIVATE_METHODS
    }
}
