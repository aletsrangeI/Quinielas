using Quinielas.Application.DTO;
using Quinielas.Transversal.Common;

namespace Quinielas.Application.Interface.UseCases
{
    public interface IUsersApplication
    {
        Response<UserDTO> Authenticate(string username, string password);
        Response<UserDTO> Agregar(UserDTO userDTO);
    }
}