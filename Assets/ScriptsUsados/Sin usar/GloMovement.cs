using UnityEngine;



/*
 * Este Script se utiliza para manipular el RigidBody 
 * Y el Animator 
 * Para moverse, se utilizará el UserInput
 * 
 * 
 * 
 */

namespace UnityStandardAssets.Characters.ThirdPerson
{

    //Requerimientos
    [RequireComponent(typeof(Rigidbody))]
    //[RequireComponent(typeof(CapsuleCollider))]
    [RequireComponent(typeof(Animator))]
    public class GloMovement : MonoBehaviour
    {

        //=========DECLARACION VARIABLES==============

        float velocidadGiroMovimiento = 360;
        float velocidadGiroEstatico = 180;
        float fuerzaSalto = 12f;
        [Range(1f, 4f)] float multiplicacionGravedad = 2f;
        float offsetRunCycleLeg = 0.2f;
        //Modificar para personajes externos al standar asset
        float mutiplicacionVelocidadMovimiento = 1f;
        float multiplicacionVelocidadAnimacion = 1f;
        float comprobadorDistanciaSuelo = 0.1f;

        //Objetos necesarios para funcionar

        Rigidbody m_Rigidbody;
        Animator m_Animator;
        bool isGrounded;
        float comprobadorDistanciaSueloIni;
        const float k_half = 0.5f;  //Constante de la mitad (para todo)
        float cantidadGiro;
        float cantidadDelantera;
        Vector3 normalSuelo;
        //float alturaCapsule;
        //Vector3 centroCapsule;
        //CapsuleCollider m_Capsule;
        bool agachar;       

        //=========END DECLARACION VARIABLES===========

        //==================FUNCTIONS==================

        // Initialization
        void Start()
        {
            m_Animator = GetComponent<Animator>();
            m_Rigidbody = GetComponent<Rigidbody>();
            //Faltan los datos del collider

            m_Rigidbody.constraints = RigidbodyConstraints.FreezeRotationX |
                RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
            // Controlamos hacia donde se puede mover el rigidbody
            // Se utiliza el OR para combinarlos

            comprobadorDistanciaSueloIni = comprobadorDistanciaSuelo;
        }

     
        //El Update lo hará el UpdateAnimator

        public void Move(Vector3 movimiento, bool crouch, bool jump)
        {
            // Necesitamos convertir la entrada de movimiento (con las teclas)
            // A una cantidad local relativa 

            if (movimiento.magnitude > 1f) movimiento.Normalize();
            movimiento = transform.InverseTransformDirection(movimiento);
            CheckGroundStatus(); // Comprobamos si estamos en tierra
            movimiento = Vector3.ProjectOnPlane(movimiento, normalSuelo); 


        }

        //Modificar el collider al agacharse
        void ScaleCapsuleForCrouching (bool agachado) 
        {


        }

        //Evitar levantarnos en zonas bajas (No darnos un coscorron)
        void PreventStandingInLowHeadroom()
        {
            
        }

        //Actualizar el estado del animador
        void UpdateAnimator (Vector3 move)
        {
            
        }

        //Comprueba si se puede saltar
        void HandleAirborneMovement()
        {
            
        }

        //Ayuda a girar en la animación
        void ApplyExtraTurnRotation()
        {
            
        }

        //Reescribir la funcion permite modificar
        //la velocidad posicional antes de aplicarla
        public void OnAnimatorMove()
        {
        }

        //Comprobar si estamos tocando el suelo
        void CheckGroundStatus()
        {
            
        }

    }//END CLASS



}//END NAMESPACE
