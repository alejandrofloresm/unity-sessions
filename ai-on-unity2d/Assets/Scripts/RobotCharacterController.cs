using UnityEngine;
using System.Collections;

public class RobotCharacterController : MonoBehaviour {

	/// <summary>
	/// Establecemos la velocidad máxima que podrá tener nuestro personaje.
	/// </summary>
	public float MaxSpeed = 10f;
	/// <summary>
	/// Definimos hacía donde está viendo el personaje, cuando el personaje
	/// inicia, este se encuentra viendo hacía la derecha.
	/// </summary>
	private bool _facingRight = true;

	/// <summary>
	/// Componente Animator de este objeto.
	/// </summary>
	private Animator _animator;

	/// <summary>
	/// Indica si el personaje está pisando el suelo
	/// </summary>
	private bool _grounded = false;

	/// <summary>
	/// Indicación en dónde se va a realizar la colisión con el suelo
	/// </summary>
	public Transform GroundCheck;

	/// <summary>
	/// Radio para checar por colisiones
	/// </summary>
	private float _groundRadius = 0.2f;

	/// <summary>
	/// Indica cuales son las capas que podemos considerar como el suelo
	/// </summary>
	public LayerMask WhatIsGround;

	// Use this for initialization
	void Start () {
		// Obtenemos el animator
		_animator = gameObject.GetComponent<Animator>();
	}
	
	/// <summary>
	/// En vez de utilizar Update utilizamos FixedUpdate, este método te asegura
	/// que el método solo se ejecuta una vez cada cuadro. 
	/// 
	/// Es recomendable utilizar FixedUpdate cuando estamos haciendo manipulaciones
	/// de física en los objetos.
	/// </summary>
	void FixedUpdate () {
		// Identificamos si estamos chocando con el suelo, esto se hace utilizando
		// el componente de Physics2D, lo que hace el método es crear un círculo
		// en la posición: GroundCheck.position con un radio de _groundRadius y va
		// a buscar colisiones con la capa WhatIsGround.
		_grounded = Physics2D.OverlapCircle(GroundCheck.position, _groundRadius, WhatIsGround);
		// Envíamos este estado al animator
		_animator.SetBool("Ground", _grounded);
		// Envíamos la velocidad vertical al animator
		_animator.SetFloat("vSpeed", gameObject.GetComponent<Rigidbody2D>().velocity.y);

		// Obtenemos el valor del eje horizontal
		float move = Input.GetAxis("Horizontal");
		// Obtenemos el componente Rigidbody 2D del objeto
		Rigidbody2D r2d = gameObject.GetComponent<Rigidbody2D>();
	
		// Alteramos el atributo Speed del componente Animator con el valor
		// absoluto de move.
		_animator.SetFloat("Speed", Mathf.Abs(move));

		// Para hacer el movimiento, manipulamos el movimiento del personaje.
		r2d.velocity = new Vector2(move * MaxSpeed, r2d.velocity.y);

		// Gira el objeto según el valor del eje horizontal.
		if (move > 0 && !_facingRight) {
			Flip();
		} else if (move < 0 && _facingRight) {
			Flip();
		}
	}

	/// <summary>
	/// Variable para manejar de forma paramétrica a la fuerza del salto
	/// </summary>
	public float JumpForce = 400;
	void Update() {
		// Revisamos si el personaje está en el suelo y el jugador a presionado
		// la barra espaciadora
		if (_grounded &&
			Input.GetKeyDown(KeyCode.Space))
		{
			// Indicamos que ya no estamos tocando el suelo
			_animator.SetBool("Ground", false);
			// Agregamos la fuerza al personaje
			gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, JumpForce));
		}
	}

	/// <summary>
	/// Volteamos al personaje
	/// </summary>
	void Flip() {
		// Hacemos el giro en la lógica del juego
		_facingRight = !_facingRight;
		// Invertimos su escala en el eje de las x
		Vector3 myScale = gameObject.transform.localScale;
		myScale.x *= -1;
		// Asignamos la nueva escala al personaje
		gameObject.transform.localScale = myScale;
	}
}
