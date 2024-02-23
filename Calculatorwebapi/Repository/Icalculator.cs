using Calculatorwebapi.model;

namespace Calculatorwebapi.Repository
{
    public interface Icalculator
    {
        public Task<List<Calculatormodel>> Getcalculatorlist();

        public Task<IEnumerable<Calculatormodel>> Getvaluebyid(int Id);

        public Task<int>Addvalue(Calculatormodel calculator);

        public Task<int>Updatevalue(Calculatormodel calculator);

        public Task<int>Deletevalue(int Id);
    }
}
