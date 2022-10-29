namespace Lab2
{
    public class Backpack
    {
        public List<ItemOfBackpack> AllItems { get; }
        public List<ItemOfBackpack> ItemsOfBackpack { get; }
        public int MaxWeight { get; }
        private int[,] _allCombinations;
        public Backpack(List<ItemOfBackpack> all, int maxWeight)
        {
            AllItems = all;
            MaxWeight = maxWeight;
            ItemsOfBackpack = new List<ItemOfBackpack>();
            _allCombinations = new int[AllItems.Count()+1,MaxWeight+1];
        }
        public void FindAnswer(int i, int j)
        {
            if (_allCombinations[i,j] == 0)
            {
                return;
            }
            if (_allCombinations[i-1,j] == _allCombinations[i,j])
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
                _allCombinations[i,0] = 0;
            }

            for (var i = 0; i < MaxWeight+1; i++)
            {
                _allCombinations[0,i] = 0;
            }

            for (var i = 1; i < AllItems.Count()+1; i++ )
            {
                for (var j = 1; j < MaxWeight+1; j++ )
                {
                    if (j > AllItems[i-1].Weight)
                    {
                        _allCombinations[i,j] = Math.Max(_allCombinations[i-1,j], _allCombinations[i-1,j-AllItems[i-1].Weight]+AllItems[i-1].Price);
                    }
                    else 
                    {
                        _allCombinations[i,j] = _allCombinations[i-1,j];
                    }
                }
            }
            FindAnswer(AllItems.Count(),MaxWeight);
        }
    }
}