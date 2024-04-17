using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGrabEffect
{
    float cooldown { get; set; }
    void effect();
}
