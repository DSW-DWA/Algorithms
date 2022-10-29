namespace Lab2
{
    public class Backpack
    {
        public List<ItemOfBackpack> AllItems { get; }
        public List<ItemOfBackpack> ItemsOfBackpack { get; }
        public int MaxWeight { get; }
        private int[,] allCombinations;
        public Backpack(List<ItemOfBackpack> all, int maxWeight)
        {
            AllItems = all;
            MaxWeight = maxWeight;
            ItemsOfBackpack = new List<ItemOfBackpack>();
            allCombinations = new int[AllItems.Count()+1,MaxWeight+1];
        }
        public void FindAnswer(int i, int j)
        {
            if (allCombinations[i,j] == 0)
            {
                return;
            }
            if (allCombinations[i-1,j] == allCombinations[i,j])
            {
                FindAnswer(i-1,j);
            }
            else 
            {
                FindAnswer(i-1,j - AllItems[i-1].Weight);
                ItemsOfBackpack.Add(AllItems[i-1]);
            }
        }
        public void ResolveBackpackProblem()
        {
            for (var i = 0; i < AllItems.Count()+1; i++)
            {
                allCombinations[i,0] = 0;
            }

            for (var i = 0; i < MaxWeight+1; i++)
            {
                allCombinations[0,i] = 0;
            }

            for (var i = 1; i < AllItems.Count()+1; i++ )
            {
                for (var j = 1; j < MaxWeight+1; j++ )
                {
                    if (j > AllItems[i-1].Weight)
                    {
                        allCombinations[i,j] = Math.Max(allCombinations[i-1,j], allCombinations[i-1,j-AllItems[i-1].Weight]+AllItems[i-1].Price);
                    }
                    else 
                    {
                        allCombinations[i,j] = allCombinations[i-1,j];
                    }
                }
            }
            FindAnswer(AllItems.Count(),MaxWeight);
        }
    }
}