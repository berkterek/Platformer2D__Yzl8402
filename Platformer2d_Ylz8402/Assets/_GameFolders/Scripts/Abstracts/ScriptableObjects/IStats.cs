﻿namespace Platformer2d.Abstracts.ScriptableObjects
{
    public interface IStats
    {
        float MoveSpeed { get; }
        int MaxHealth { get; }
        int Damage { get; }
    }
}