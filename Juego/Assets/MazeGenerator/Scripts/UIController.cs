using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI textoNumPrincipio;
    private TextMeshProUGUI textoCodigoEtica;
    public GameObject codigoEtica;

    private float tiempoPrincipio = 5;
    private int NumeroPrincipios;
    private List<string> listaPrincipios = new List<string>();


    // Start is called before the first frame update
    void Start()
    {
        NumeroPrincipios = 0;
        listaPrincipios.Add("1. Sociedad.\nLos ingenieros de software actuarán en forma congruente con el interés social.");
        listaPrincipios.Add("2. Cliente. y empresario.\nLos ingenieros de software actuarán de manera que se concilien los mejores intereses de sus clientes y empresarios, congruentemente con el interés social.");
        listaPrincipios.Add("3. Producto.\nLos ingenieros de software asegurarán que sus productos y modificaciones correspondientes cumplen los estándares profesionales más altos posibles.");
        listaPrincipios.Add("4. Juicio.\nLos ingenieros de software mantendrán integridad e independencia en su juicio profesional.");
        listaPrincipios.Add("5. Administración.\nLos ingenieros de software gerentes y líderes promoverán y se suscribirán a un enfoque ético en la administración del desarrollo y mantenimiento de software.");
        listaPrincipios.Add("6. Profesión.\nLos ingenieros de software incrementarán la integridad y reputación de la profesión congruentemente con el interés social.");
        listaPrincipios.Add("7. Colegas.\nLos ingenieros de software apoyarán y serán justos con sus colegas.");
        listaPrincipios.Add("8. Personal.\nLos ingenieros de software participarán toda su vida en el aprendizaje relacionado con la práctica de su profesión y promoverán un enfoque ético en la práctica de la profesión.");
    
        textoCodigoEtica = codigoEtica.GetComponentInChildren<TextMeshProUGUI>();
    }

    private void actualizarContador()
    {
        NumeroPrincipios++;
        textoNumPrincipio.SetText("Principios encontrados: " + NumeroPrincipios + " de 8");        
    }

    // La funcio permite esperar un determinado tiempo y luego sigue la ejecución
    public IEnumerator mostrarPrincipio()
    {
        if (NumeroPrincipios <= 7)
        {
            codigoEtica.SetActive(true);
            textoCodigoEtica.SetText(listaPrincipios[NumeroPrincipios]);
            actualizarContador();
        }
        yield return new WaitForSeconds(tiempoPrincipio);        
        codigoEtica.SetActive(false);
        
    }

}
