
using apiTr2Part2.Model;

namespace apiTr2Part2.Data
{
    public interface IDestinos
    {
        Task<IEnumerable<Destinos>> ListarDestino();
        Task<Destinos> MostrarDestino(String codigo);
        Task<bool> RegistrarDestino(Destinos Destino);
        Task<bool> ActualizarDestino(Destinos Destino);
        Task<bool> EliminarDestino(String codigo);
    }
}
