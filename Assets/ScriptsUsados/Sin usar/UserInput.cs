using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

//Utilizamos su namespace para usar los scripts del StandarAssets
namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof(GloMovement))]
    public class UserInput : MonoBehaviour
    {

        private GloMovement character;      //Referencia al player (Glo)
        private Transform m_camera;         //Referencia a la cámara principal
        private Vector3 camera_direction;   //Referencia a la posición de la cámara
        private Vector3 movement;           //Direccion del world, calculado desde la posicion de la caara
        private bool salto;


       private void Start()
        {
            //Obtener los parámetros de la cámara
            if (Camera.main != null)
            {
                m_camera = Camera.main.transform;
            }
            else {
                Debug.LogWarning("No hay cámara principal asignada");
            }

            //Obtener la referencia al personaje

            character = GetComponent<GloMovement>();
        }

       
        private void Update()
        {
            //Se comprueba si no está saltando ya, si se está pulsando el boton "Jump" ->Space
            if ( !salto )
            {
                salto = CrossPlatformInputManager.GetButtonDown("Jump");
            }
        }

        //Para las llamadas a las físicas
        private void FixedUpdate()
        {
            //Lectura de entradas
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");
            //Agacharse
            bool agachado = Input.GetKey(KeyCode.C);

            //Calcular el movimiento del personaje

            if( m_camera != null ){

                //Dirección Relativa

                camera_direction = Vector3.Scale(m_camera.forward, new Vector3(1, 0, 1)).normalized;
                movement = v * camera_direction + h * m_camera.right;
            }
            else {
                //SI no hay camara, se usará relativo al mundo
                movement = v * Vector3.forward + h * Vector3.right;
            }

            //So se quiere ir andando, pulsando tecla shift
            if (Input.GetKey(KeyCode.LeftShift)) movement *= 0.5f;


            character.Move(movement, agachado, salto);
            salto = false;

        }
        //END FIXED UPDATE


        //END CLASS
    }
//END NAMESPACE
}