using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Zoo
{
    class Pig : Omnivore
    {
        public Pig() : base("oink oink", "nomnomnom oink thx", "munch munch oink", true)
        {
        }
    }
}
