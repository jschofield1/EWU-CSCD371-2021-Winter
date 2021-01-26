using System;

namespace CanHazFunny
{
    public class Jester
    {
        private IJokeService jokeService;
        private IJokeOutput jokeOutput;

        public IJokeService JokeService 
        { 
            get => jokeService; 
            set => jokeService = value ?? 
                throw new ArgumentNullException(nameof(value)); 
        }
        
        public IJokeOutput JokeOutput 
        { 
            get => jokeOutput; 
            set => jokeOutput = value ?? 
                throw new ArgumentNullException(nameof(value)); 
        }

        public Jester(IJokeService jokeService, IJokeOutput jokeOutput)
        {
            JokeService = jokeService;
            JokeOutput = jokeOutput;
        }

        public void TellJoke()
        {
            string joke = JokeService.GetJoke();
            while (joke.Contains("Chuck Norris"))
                joke = JokeService.GetJoke();
            JokeOutput.PrintJoke(joke);
        }
    }
}
