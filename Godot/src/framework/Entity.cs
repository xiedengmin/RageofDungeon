using Godot;
using System;
using System.Collections.Generic;

// Entity class
public class Entity
{
    public int Id { get; private set; }
    public List<IComponent> Components { get; private set; } = new List<IComponent>();

    public Entity(int id)
    {
        Id = id;
    }

    public void AddComponent(IComponent component)
    {
        Components.Add(component);
    }

    public void RemoveComponent<T>() where T : IComponent
    {
        Components.RemoveAll(c => c is T);
    }

    public T GetComponent<T>() where T : IComponent
    {
        return (T)Components.Find(c => c is T);
    }
}

// Component interface
public interface IComponent { }

// Position component
public class PositionComponent : IComponent
{
    public Vector2 Position;
    public PositionComponent(Vector2 position)
    {
        Position = position;
    }
}



// Player component
public partial class PlayerComponent<T> : CharacterBody2D,  IComponent
{
    public T PlayerBody;
    public PlayerComponent(T playerBody)
    {
        PlayerBody = playerBody;
    }
   
}

// Monster component
public class MonsterComponent : IComponent
{
    public CharacterBody2D MonsterBody;
    public float AttackRange;
    public MonsterComponent(CharacterBody2D monsterBody, float attackRange)
    {
        MonsterBody = monsterBody;
        AttackRange = attackRange;
    }
}
