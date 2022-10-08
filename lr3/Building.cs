using System;

namespace lr3
{
    internal abstract class Building
    {
        protected FlatType _flatType;
        protected BuildingType _buildingType;
        protected int _flatsCount;
        protected double _square;
        public readonly string _address;

        protected static readonly Dictionary<FlatType, int> _roomsCount = new Dictionary<FlatType, int>
        {
            [FlatType.Economy] = 2,
            [FlatType.Business] = 3,
            [FlatType.Elite] = 4
        };

        protected Building(BuildingType buildingType, FlatType type, int flatsCount, string address)
        {
            BuildingType = buildingType;
            Type = type;
            _flatsCount = flatsCount;
            _address = address;
        }

        protected Building(BuildingType buildingType, FlatType type, double square, string address)
        {
            BuildingType = buildingType;
            Type = type;
            _square = square;
            _address = address;
        }

        public FlatType Type
        {
            get { return _flatType; }
            set { _flatType = value; }
        }

        public BuildingType BuildingType
        {
            get { return _buildingType; }
            set { _buildingType = value; }
        }

        public abstract double Average { get; }
    }
}
