namespace Lab2
{
    public class Tower
    {
        public Poles[] Poles { get; set; }

        public int Moves = 0;

        public int NumOfDiscs { get; set; }

        public Tower() 
        {
            NumOfDiscs = 4;
            Poles = new Poles[]
            {
                new Poles(4, 1),
                new Poles(4, 2),
                new Poles(4, 3)
            };
        }

        public Tower(int discs)
        {
            NumOfDiscs = discs;
            Poles = new Poles[]
                { 
                    new Poles(discs, 1),
                    new Poles(discs, 2),
                    new Poles(discs, 3)
                };
        }

        public Tower SolveTower() =>
            Solve(NumOfDiscs, Poles[0], Poles[2], Poles[1]);

        public Tower Solve(int n, Poles from, Poles to, Poles holder)
        {
            Moves++;

            if (n == 1)
            {
                var discBeforeSolve = new Disc(from.Pole.Pop().Name);
                to.Pole.Push(discBeforeSolve);
                Console.WriteLine($"Move {discBeforeSolve.Name} from Pole {from.Position} to Pole {to.Position}");
                return this;
            }

            Solve(n - 1, from, holder, to);

            var discAfterSolve = new Disc(from.Pole.Pop().Name);
            to.Pole.Push(discAfterSolve);
            Console.WriteLine($"Move {discAfterSolve.Name} from Pole {from.Position} to Pole {to.Position}");

            Solve(n - 1, holder, to, from);

            return this;
        }
    }
}