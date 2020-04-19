using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedParameter : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    [SerializeField] private ParticleSystem rainParticle;
    [SerializeField] private float startParticleSpeed;
    [SerializeField] private float rainSpeedMultiplier;

    [SerializeField] private Waves waveSystem;
    private float waveStartSpeed;
    private float waveStartHeight;
    [SerializeField] private float waveSpeedMultiplier;
    [SerializeField] private float waveLerpSpeed = 0.1f;
    [SerializeField] private float waveHeightMultiplier;

    [SerializeField] private ParticleSystem waterParticle;
    private float waterStartSpeed;
    private float waterStartRate;
    [SerializeField] private float waterSpeedMultiplier;
    [SerializeField] private float waterRateMultiplier;


    private float currentTimer;

    // Start is called before the first frame update
    void Start()
    {
        waveStartSpeed = waveSystem.Speed;
        waveStartHeight = waveSystem.WaveHeight;
        waterStartSpeed = waterParticle.startSpeed;
        waterStartRate = waterParticle.emission.rateOverTime.constant;
    }

    // Update is called once per frame
    void Update()
    {
        float score = gameManager.Score;

        ParticleSystem.VelocityOverLifetimeModule velocity = rainParticle.velocityOverLifetime;
        velocity.xMultiplier = rainSpeedMultiplier * score;

        float targetVelocity = score * waveSpeedMultiplier + waveStartSpeed;
        if (targetVelocity > waveSystem.Speed)
        {
            waveSystem.Speed += waveLerpSpeed;
        } else
        {
            waveSystem.Speed -= waveLerpSpeed;
        }
        waterParticle.startSpeed = score * waterSpeedMultiplier + waterStartSpeed;
        waterParticle.emissionRate = score * waterRateMultiplier + waterStartRate;


        waveSystem.WaveHeight = waveStartHeight + gameManager.CurrentDist * waveHeightMultiplier;

    }
}
