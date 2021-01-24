using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            //if (jokeService == null || jokeOutput == null)
                //throw new ArgumentNullException();

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
