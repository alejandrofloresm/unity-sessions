using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    /// <summary>
    /// Arreglo que almacena todas las visitas posibles
    /// </summary>
    public Transform[] Targets;
    /// <summary>
    /// Velocidad del sprite
    /// </summary>
    public float Speed;
    /// <summary>
    /// Indice del target que estamos buscando
    /// </summary>
    private int targetIndex = -1;
    /// <summary>
    /// Target al que queremos llegar
    /// </summary>
    private Vector3 target;
    /// <summary>
    /// Renderer del sprite
    /// </summary>
    private SpriteRenderer spriteRenderer;

    public EnemyController Controller;

    public RobotCharacterController PlayerController;

    public float Move;

    // Use this for initialization
    void Start () {
      spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
      CalcNextTarget();
    }
  
  // Update is called once per frame
    void Update () {
        if (Controller.Status == EnemyController.EnemyStatus.patrol) {
          // Si hemos llegado a nuestro target
          if (Vector2.Distance(transform.position, target) < .1) {
              // Obtenemos el siguiente target
              CalcNextTarget();
          }
        } else if (Controller.Status == EnemyController.EnemyStatus.chase) {
          target = PlayerController.transform.position;
          if (Vector2.Distance(transform.position, target) > 5) {
            Controller.SetPatrol();
            PlayerController.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            targetIndex = -1;
            CalcNextTarget();
          }
        }

        transform.position = Vector2.MoveTowards(transform.position, target, Speed * Time.deltaTime);
         
        Move = target.x > transform.position.x ? 1 : -1;
    }

    /// <summary>
    /// Calculamos la siguiente posición a donde queremos llegar
    /// </summary>
    private void CalcNextTarget() {
        // Aumentamos el índice actual
        targetIndex++;
        // Si el índice al que queremos llegar es superior al tamaño del arreglo
        // de targets entonces el índice se regresa a cero
        targetIndex = targetIndex % Targets.Length;
        // La posición a la que queremos llegar es la que está almacenada en el
        // arreglo de targets en la posición del índice que aumentamos
        target = Targets[targetIndex].position;
    }

}
