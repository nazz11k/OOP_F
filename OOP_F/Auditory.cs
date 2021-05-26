using System;

namespace OOP_F
{
    public class Auditory
    {
        public string Name;
        private bool[,] _isPair;

        public Auditory(string name)
        {
            Name = name;
            _isPair = new bool[10, 4];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    _isPair[i, j] = false;
                }
            }
        }

        public bool IsAvailable(Pair pair)
        {
            if (_isPair[pair.Day - 1, pair.PairNum - 1])
            {
                throw new Exception("This auditory is not free");
            }

            return true;
        }

        public void AddPair(Pair pair)
        { 
            _isPair[pair.Day - 1, pair.PairNum - 1] = true;
        }
    }

    
    
    public class Auditories
    {
        public Auditory[] _cabinets;
        private int _count;

        public Auditories()
        {
            _cabinets = new Auditory[0];
            _count = 0;
        }

        public Auditories(string name)
        {
            _cabinets = new Auditory[1];
            _cabinets[0] = new Auditory(name);
            _count = 1;
        }

        public void AddAuditory(string name)
        {
            bool exists = false;
            for (int i = 0; i < _count; i++)
            {
                if (_cabinets[i].Name == name)
                {
                    exists = true;
                }
            }

            if (!exists)
            {
                Auditory[] newCabinets = new Auditory[this._count + 1];
                for (int i = 0; i < this._count; i++)
                {
                    newCabinets[i] = _cabinets[i];
                }

                newCabinets[this._count] = new Auditory(name);
                _cabinets = newCabinets;
            }
            else
            {
                throw new Exception($"The Auditory {name} is already exists");
            }

            _count += 1;
        }
        
        public bool IsAvailable(Pair pair)
        {
            for (int i = 0; i < _count; i++)
            {
                if (_cabinets[i].Name == pair.Auditory)
                {
                    if (!_cabinets[i].IsAvailable(pair))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        
        public void AddPair(Pair pair)
        {
            for (int i = 0; i < _count; i++)
            {
                if (_cabinets[i].Name == pair.Auditory)
                {
                    _cabinets[i].AddPair(pair);
                }
            }
        }
    }
}