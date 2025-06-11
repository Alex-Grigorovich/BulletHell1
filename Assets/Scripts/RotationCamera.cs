using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class RotationCamera : MonoBehaviour
{
        public Transform target; // Cube's transform

        public float rotationSpeed = 5.0f;

        CinemachineVirtualCamera vcam;
        CinemachineOrbitalTransposer transposer;


        private void Start()
        {
                vcam = GetComponent<CinemachineVirtualCamera>();
                transposer = vcam.GetCinemachineComponent<CinemachineOrbitalTransposer>();
        }

        void Update()
        
        {
                float horizontalInput = Input.GetAxis("Horizontal");
                transposer.m_Heading.m_Bias += horizontalInput * rotationSpeed * Time.deltaTime;
        }
}
