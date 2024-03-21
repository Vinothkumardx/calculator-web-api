using Calculatorwebapi.Database;
using Calculatorwebapi.model;
using Calculatorwebapi.Repository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Calculatorwebapi.Service
{
    public class Calculatorservice : Icalculator
    {
        private readonly Dbcontextclass _dbcontextclass;

        public Calculatorservice(Dbcontextclass dbcontextclass)
        {
           _dbcontextclass = dbcontextclass;
        }
            
        public async Task<int> Addvalue(Calculatormodel calculator)
        {
            var parameter = new List<SqlParameter>();

            parameter.Add(new SqlParameter("@Num1", calculator.Num1));
            parameter.Add(new SqlParameter("@Num2",calculator.Num2));
            parameter.Add(new SqlParameter("@MathOption", calculator.MathOption));

            var Result=await Task.Run(()=>_dbcontextclass.Database.ExecuteSqlRawAsync(@"Exec [dbo.Addvalue] @Num1,@Num2,@MathOption",parameter.ToArray()));
            return Result;
        }

        public async Task<int> Deletevalue(int Id)
        {
            return await Task.Run(()=>_dbcontextclass.Database.ExecuteSqlInterpolatedAsync($"[dbo.Deletevalue] { Id}"));
        }

        public async Task<List<Calculatormodel>> Getcalculatorlist()
        {
            return await _dbcontextclass.user.FromSqlRaw("[dbo.Getallvalue]").ToListAsync();
        }

        public async Task<IEnumerable<Calculatormodel>> Getvaluebyid(int Id)
        {
            var para=new SqlParameter("@Id",Id);

            var Idresult=await Task.Run(()=>_dbcontextclass.user.FromSqlRaw(@"Exec [dbo.Getvaluebyid] @Id",para).ToListAsync());
            return Idresult;
        }

        public async Task<int> Updatevalue(Calculatormodel calculator)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@Id", calculator.Id));
            parameter.Add(new SqlParameter("@Num1", calculator.Num1));
            parameter.Add(new SqlParameter("@Num2", calculator.Num2));
            parameter.Add(new SqlParameter("@MathOption", calculator.MathOption));

            var updateresult = await Task.Run(() => _dbcontextclass.Database.ExecuteSqlRawAsync(@"Exec [dbo.updatevalue] @Id, @Num1,@Num2,@MathOption", parameter.ToArray()));
            return updateresult;
        }
    }
}
