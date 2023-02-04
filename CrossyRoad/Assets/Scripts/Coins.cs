using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class Coins : MonoBehaviour
{
    public int coinCount = 0;

    public Text coinCountText;
    public Text coinCountTextAdv;
    public Text controlos;

    [SerializeField] private GameObject garra;



    void Start()
    {
        controlos.text = "W, A, S, D para movimentar!\nRato para rodar a camera!";
        Invoke("escondeMensagem", 5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
            if(collision.gameObject.tag == "Coin" && garra != null)
            {
                coinCountTextAdv.text = "Apanha o Coletor de Moedas primeiro!";
                Invoke("escondeMensagem", 1.5f);
                
            }
            if(collision.gameObject.tag == "Coin" && garra == null)
            {
                Destroy(collision.gameObject); 
                coinCount++;
                coinCountText.text = coinCount.ToString();
            }
            else if(collision.gameObject.tag == "Garra")
            {
                Destroy(collision.gameObject);
            }


        
    }
    void escondeMensagem()
    {
        coinCountTextAdv.text = " ";
        controlos.text = " ";
    }

}
