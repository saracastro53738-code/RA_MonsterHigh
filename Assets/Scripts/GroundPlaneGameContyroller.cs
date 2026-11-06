using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class GroundPlaneGameContyroller : MonoBehaviour
{
    private Rigidbody rb;
    private float velocidad = 0f;
    private float giroVehiculo = 0f;
    private Quaternion giro;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movimiento = transform.forward * velocidad * Time.deltaTime;
        rb.MovePosition(rb.position + movimiento);

        if (velocidad != 0f)
        {
            float cantidadGiro = giroVehiculo * Time.deltaTime;
            Quaternion giro = Quaternion.Euler(0f, cantidadGiro, 0f);
        }   rb.MoveRotation(rb.rotation * giro);
    }

    public void acelerar()
    {
        velocidad++;
    }

	public void frenar()
	{
		velocidad--;
	}
    public void girarDerecha()
    {
        giroVehiculo = 30f;
    }
	public void girarIzquierda()
	{
		giroVehiculo = -30f;
	}
    public void Agrandar()
    {
        Vector3 nuevaEscala = transform.localScale + Vector3.one * 5;
        transform.localScale = nuevaEscala;
    }
}


