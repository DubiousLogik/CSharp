using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowersHanoi
{
    public class TowersGameBoard
    {
        private bool displayGameState;
        private int diskCount;
        private int maxValue = 99;
        private int countOfMoves;
        private int lastMoved;
        private int debugLimit = 1000000000;

        private Stack<int> postOne;
        private Stack<int> postTwo;
        private Stack<int> postThree;

        public TowersGameBoard(int diskCountInput, bool displayGameStateInput)
        {
            this.diskCount = diskCountInput;
            this.displayGameState = displayGameStateInput;
            this.InitializePosts();
        }

        public bool GameIsComplete
        {
            get
            {
                return this.CheckIfGameIsComplete();
            }
        }

        public void Play()
        {
            countOfMoves = 0;

            while (!this.GameIsComplete)
            {
                if (displayGameState)
                {
                    this.RenderCurrentState();
                }

                while (this.MoveRight())
                {
                    if (displayGameState)
                    {
                        Console.WriteLine("Direction moved: Right");
                        this.RenderCurrentState();
                    }
                }

                while (!this.GameIsComplete && this.MoveLeft())
                {
                    if (displayGameState)
                    {
                        Console.WriteLine("Direction moved: Left");
                        this.RenderCurrentState();
                    }
                }

                if (countOfMoves > debugLimit )
                {
                    Console.WriteLine("debug limit hit");
                    this.RenderCurrentState();
                    Console.WriteLine($"Count of moves {countOfMoves}");
                    break;
                }
            }

            Console.WriteLine($"Game is complete: {this.GameIsComplete}");
            Console.WriteLine($"Count of moves {countOfMoves}");
        }

        public bool MoveRight()
        {
            if (diskCount == 1)
            {
                lastMoved = 0;
            }

            //if 2 can move, move the larger one first
            if (this.PostTopValue(postOne) < this.PostTopValue(postThree) &&
                this.PostTopValue(postTwo) < this.PostTopValue(postThree))
            {
                if (this.PostTopValue(postOne) > this.PostTopValue(postTwo) 
                    && this.PostTopValue(postOne) != lastMoved)
                {
                    lastMoved = this.PostTopValue(postOne);
                    postThree.Push(postOne.Pop());
                    countOfMoves++;
                    return true;
                }
                else
                {
                    if (this.PostTopValue(postTwo) != lastMoved)
                    {
                        lastMoved = this.PostTopValue(postTwo);
                        postThree.Push(postTwo.Pop());
                        countOfMoves++;
                        return true;
                    }
                }
            }

            if (this.PostTopValue(postOne) < this.PostTopValue(postTwo) 
                && this.PostTopValue(postOne) != lastMoved)
            {
                lastMoved = this.PostTopValue(postOne);
                postTwo.Push(postOne.Pop());
                countOfMoves++;
                return true;
            }

            if (this.PostTopValue(postOne) < this.PostTopValue(postThree) 
                && this.PostTopValue(postOne) != lastMoved)
            {
                lastMoved = this.PostTopValue(postOne);
                postThree.Push(postOne.Pop());
                countOfMoves++;
                return true;
            }

            if (this.PostTopValue(postTwo) < this.PostTopValue(postThree) 
                && this.PostTopValue(postTwo) != lastMoved)
            {
                lastMoved = this.PostTopValue(postTwo);
                postThree.Push(postTwo.Pop());
                countOfMoves++;
                return true;
            }

            return false;
        }
        public bool MoveLeft()
        {
            if (this.PostTopValue(postThree) < this.PostTopValue(postTwo) 
                && this.PostTopValue(postThree) != diskCount
                && this.PostTopValue(postThree) != lastMoved)
            {
                lastMoved = this.PostTopValue(postThree);
                postTwo.Push(postThree.Pop());
                countOfMoves++;
                return true;
            }

            if (this.PostTopValue(postThree) < this.PostTopValue(postOne)
                && this.PostTopValue(postThree) != diskCount
                && this.PostTopValue(postThree) != lastMoved)
            {
                lastMoved = this.PostTopValue(postThree);
                postOne.Push(postThree.Pop());
                countOfMoves++;
                return true;
            }

            if (this.PostTopValue(postTwo) < this.PostTopValue(postOne) 
                && this.PostTopValue(postTwo) != lastMoved)
            {
                lastMoved = this.PostTopValue(postTwo);
                postOne.Push(postTwo.Pop());
                countOfMoves++;
                return true;
            }

            return false;
        }

        private int PostTopValue(Stack<int> post)
        {
            if (post.Count == 0)
            {
                return this.maxValue;
            }
            else
            {
                return post.Peek();
            }
        }

        public void RenderCurrentState()
        {
            List<string> linesToPrint = new List<string>();

            for (int i = 0; i < diskCount; i++)
            {
                string postOneValue = this.postOne.ElementAtOrDefault(i) == 0 ? "-" : this.postOne.ElementAt(i).ToString();
                string postTwoValue = this.postTwo.ElementAtOrDefault(i) == 0 ? "-" : this.postTwo.ElementAt(i).ToString();
                string postThreeValue = this.postThree.ElementAtOrDefault(i) == 0 ? "-" : this.postThree.ElementAt(i).ToString();

                linesToPrint.Add($"1: {postOneValue} \t 2: {postTwoValue} \t 3: {postThreeValue}");
            }

            foreach (string line in linesToPrint)
            {
                Console.WriteLine(line);
            }

            Console.WriteLine();
            Console.WriteLine($"Game is complete: {this.GameIsComplete}");
        }

        private bool CheckIfGameIsComplete()
        {
            if (this.postThree != null && this.postThree.Count == this.diskCount)
            {
                return true;
            }

            return false;
        }

        private void InitializePosts()
        {
            postOne = new Stack<int>();
            postTwo = new Stack<int>();
            postThree = new Stack<int>();

            for (int i = this.diskCount; i > 0; i--)
            {
                postOne.Push(i);
            }
        }
    }
}
