﻿namespace CanHazFunny
{
    class Program
    {
        static void Main()
        {
            new Jester(new JokeService(), new JokeOutput()).TellJoke();
        }
    }
}
