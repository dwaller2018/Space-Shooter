using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarFieldSlider : MonoBehaviour
{
    public GameController gameController;
    private ParticleSystem ps;
    public float ChallengeSpeed = 20.0F;
    // Start is called before the first frame update
    void Start()
    {
        
        ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameController.score >= 100)
        {
            var main = ps.main;
            main.simulationSpeed = ChallengeSpeed;
        }
      
    }
}
