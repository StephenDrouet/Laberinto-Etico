using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

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
        listaPrincipios.Add("1. Sociedad.\nLos ingenieros de software actuar�n en forma congruente con el inter�s social.");
        listaPrincipios.Add("2. Cliente. y empresario.\nLos ingenieros de software actuar�n de manera que se concilien los mejores intereses de sus clientes y empresarios, congruentemente con el inter�s social.");
        listaPrincipios.Add("3. Producto.\nLos ingenieros de software asegurar�n que sus productos y modificaciones correspondientes cumplen los est�ndares profesionales m�s altos posibles.");
        listaPrincipios.Add("4. Juicio.\nLos ingenieros de software mantendr�n integridad e independencia en su juicio profesional.");
        listaPrincipios.Add("5. Administraci�n.\nLos ingenieros de software gerentes y l�deres promover�n y se suscribir�n a un enfoque �tico en la administraci�n del desarrollo y mantenimiento de software.");
        listaPrincipios.Add("6. Profesi�n.\nLos ingenieros de software incrementar�n la integridad y reputaci�n de la profesi�n congruentemente con el inter�s social.");
        listaPrincipios.Add("7. Colegas.\nLos ingenieros de software apoyar�n y ser�n justos con sus colegas.");
        listaPrincipios.Add("8. Personal.\nLos ingenieros de software participar�n toda su vida en el aprendizaje relacionado con la pr�ctica de su profesi�n y promover�n un enfoque �tico en la pr�ctica de la profesi�n.");
    
        textoCodigoEtica = codigoEtica.GetComponentInChildren<TextMeshProUGUI>();
    }

    private void actualizarContador()
    {
        NumeroPrincipios++;
        textoNumPrincipio.SetText("Principios encontrados: " + NumeroPrincipios + " de 8");        
    }

    // La funcio permite esperar un determinado tiempo y luego sigue la ejecuci�n
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

    public void SalirJuego()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();        
#else
        Application.Quit();
#endif
    }
}
