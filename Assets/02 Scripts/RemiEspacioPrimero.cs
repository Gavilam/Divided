using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemiEspacioPrimero : MonoBehaviour
{
    private int contador = 0;
    private int N = 10;
    [SerializeField] GameObject segundaNarrativa;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(contador > N){
                segundaNarrativa.SetActive(true);
                Events.ChangeCharacter?.Invoke();
                Destroy(gameObject);
            }
            else{
                contador++;
            }
        }
    }
}
