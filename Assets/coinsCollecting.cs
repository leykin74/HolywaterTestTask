using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class coinsCollecting : MonoBehaviour
{
    public int coins = 0;
    public TMPro.TextMeshProUGUI coinsText;

    // private void OnParticleCollision(GameObject other) {
    //     // coins++;
    //     // coinsText.text = coins.ToString();
    //     // Destroy(other);
    //     //Number of particles
    //     // int numCollisionEvents = part.GetCollisionEvents(other, collisionEvents);
 
    //     //         //Make sure a particle exists first....
    //     // if (part.GetParticles(particles) > 0)
    //     // {
    //     //     //Stop the particle from generating more than one so we move it to somewhere else so it wont collide
    //     //     particles[numCollisionEvents - 1].position = Vector3.zero;
    //     //     //Update the particle system with the new position
    //     //     part.SetParticles(particles);
    //     // }
    //     List<ParticleCollisionEvent> events;
    //     events = new List<ParticleCollisionEvent>();
 
    //     ParticleSystem m_System = other.GetComponent<ParticleSystem>();
 
    //     ParticleSystem.Particle[] m_Particles;
    //     m_Particles = new ParticleSystem.Particle[m_System.main.maxParticles];
 
    //     ParticlePhysicsExtensions.GetCollisionEvents(other.GetComponent<ParticleSystem>(), gameObject, events);
    //     foreach(ParticleCollisionEvent coll in events)
    //     {
    //         // if(coll.intersection!=Vector3.zero)
    //         // {
    //             int numParticlesAlive = m_System.GetParticles(m_Particles);
 
    //             float closestDistance = float.MaxValue;
    //             int closestIndex = 0;
    //             // Check only the particles that are alive
    //             for (int i = 0; i < numParticlesAlive; i++)
    //             {
                 
    //                 //If the collision was close enough to the particle position, destroy it
    //                 Debug.Log(Vector3.Magnitude(m_Particles[i].position - transform.position));
    //                 if (Vector3.Magnitude(m_Particles[i].position - transform.position) < closestDistance)
    //                 {
    //                     closestDistance = Vector3.Magnitude(m_Particles[i].position - transform.position);
    //                     closestIndex = i;
    //                 }
    //             }
                
    //             m_Particles[closestIndex].remainingLifetime = -1; //Kills the particle
    //             Debug.Log("Particle destroyed");
    //             m_System.SetParticles(m_Particles); // Update particle system
    //             coins++;
    //             coinsText.text = coins.ToString();
    //         // }
    //     }      
    // }

    // private void RemoveParticle (theParticle) {
 
    //     var particles = particleEmitter.particles;
    //     for (var i=0; i<particles.Length; i++) {
        
        
    //         if (particles[i]==theParticle){
    //             delete particles[i];
    //         //or you can try this: particles[i] = null;
    //         }
        
    //     }
    //     // copy them back to the particle system
    //     particleEmitter.particles = particles;
    // }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Coin"){
            Destroy(other.transform.parent.gameObject);
            coins++;
            coinsText.text = coins.ToString();
        }
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("Trigger");
        if(other.gameObject.tag == "Coin"){
            Destroy(other.transform.parent.gameObject);
            coins++;
            coinsText.text = coins.ToString();
        }
    }
}
