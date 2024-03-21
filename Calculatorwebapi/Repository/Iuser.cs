using Calculatorwebapi.model;

namespace Calculatorwebapi.Repository
{
    public interface Iuser
    {
        User Authenticate(string username, string password);
        User Create(User user, string password,string Email,string FirstName,string LastName);
    }
}
