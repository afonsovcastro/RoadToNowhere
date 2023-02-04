using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CicloDia : MonoBehaviour
{
    [SerializeField] private Transform luzDirecional;
    [SerializeField] [Tooltip("Duraç\ao do dia em segundos")] private int duracaoDoDia;
    
    private float segundos;
    private float multiplicador;
    // Start is called before the first frame update
    void Start()
    {
        multiplicador = 86400 / duracaoDoDia;
    }

    // Update is called once per frame
    void Update()
    {
        segundos += Time.deltaTime * multiplicador;
        if(segundos >= 86400)
        {
            segundos = 0;
        }

        ProcessarCeu();

    }

    private void ProcessarCeu()
    {
        float rotacaoX = Mathf.Lerp(-90, 270, segundos/86400);
        luzDirecional.rotation = Quaternion.Euler(rotacaoX + 135, 90, 90);
       
    }

    private void CalcularHorario()
    {
        
    }
}
