using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.CompilerServices;

namespace c_sharp_fluid_sim;

public class PhysicsEngine
{
    public List<Particle> particleList;
    public int iteration;

    public uint height;
    public uint width;

    public PhysicsEngine(uint height,
        uint width)
    {
        iteration = 0;
        this.height = height;
        this.width = width;
        this.particleList = new List<Particle>();
    }

    public void AddParticle(double x, double y, double radius = 5)
    {
        
        particleList.Add(new Particle(x, y, radius));
       
    }

    public void Iterate()
    {
        iteration++;
        // gravity:
        foreach (var particle in particleList)
        {
            particle.displacementVector += new Vector2D(0, -0.1);
        }

        // apply collision with floor:
        foreach (var particle in particleList)
        {
            if (particle.Y + particle.displacementVector.Y + particle.radius < 0)
            {
                particle.displacementVector.Y = particle.radius - particle.Y;
            }
        }

        // move particles:
        foreach (var particle in particleList)
        {
            particle.Iterate();
        }
    }
}