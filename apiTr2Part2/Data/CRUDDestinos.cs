using apiTr2Part2.Model;
using Dapper;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;

namespace apiTr2Part2.Data
{
    public class CRUDDestinos : IDestinos
    {
        private Configuracion _conexion;

        public CRUDDestinos(Configuracion conexion)
        {
            _conexion = conexion;
        }

        protected MySqlConnection Conectar()
        {
            return new MySqlConnection(_conexion.Conectar);
        }

        public async Task<IEnumerable<Destinos>> ListarDestino()
        {
            using (var bd = Conectar())
            {
                string cad_sql = @"select * from destinos";
                return await bd.QueryAsync<Destinos>(cad_sql);
            }
        }

        public async Task<Destinos> MostrarDestino(string codigo)
        {
            using (var bd = Conectar())
            {
                string cad_sql = @"select * from destinos where ID_Destino = @cod";
                return await bd.QueryFirstAsync<Destinos>(cad_sql, new { cod = codigo });
            }
        }

        public async Task<bool> RegistrarDestino(Destinos destino)
        {
            using (var bd = Conectar())
            {
                string cad_sql = @"insert into destinos (NombreDestino, Descripcion, PrecioPorPersona, FechaInicioDisponibilidad, FechaFinDisponibilidad, Disponibilidad) 
                           values (@NombreDestino, @Descripcion, @PrecioPorPersona, @FechaInicioDisponibilidad, @FechaFinDisponibilidad, @Disponibilidad)";

                int n = await bd.ExecuteAsync(cad_sql, new
                {
                    NombreDestino = destino.NombreDestino,
                    Descripcion = destino.Descripcion,
                    PrecioPorPersona = destino.PrecioPorPersona,
                    FechaInicioDisponibilidad = destino.FechaInicioDisponibilidad,
                    FechaFinDisponibilidad = destino.FechaFinDisponibilidad,
                    Disponibilidad = destino.Disponibilidad
                });
                return n > 0;
            }
        }

        public async Task<bool> ActualizarDestino(Destinos destino)
        {
            using (var bd = Conectar())
            {
                string cad_sql = @"update destinos set
                           Descripcion = @Descripcion, PrecioPorPersona = @PrecioPorPersona,
                           FechaInicioDisponibilidad = @FechaInicioDisponibilidad, FechaFinDisponibilidad = @FechaFinDisponibilidad, 
                           Disponibilidad = @Disponibilidad
                           where ID_Destino = @ID_Destino"; // Usar ID_Destino en lugar de cod
                int n = await bd.ExecuteAsync(cad_sql, new
                {
                    ID_Destino = destino.ID_Destino, // Utilizar ID_Destino en el objeto anónimo
                    Descripcion = destino.Descripcion,
                    PrecioPorPersona = destino.PrecioPorPersona,
                    FechaInicioDisponibilidad = destino.FechaInicioDisponibilidad,
                    FechaFinDisponibilidad = destino.FechaFinDisponibilidad,
                    Disponibilidad = destino.Disponibilidad,
                });
                return n > 0;
            }
        }




        public async Task<bool> EliminarDestino(string codigo)
        {
            using (var bd = Conectar())
            {
                string cad_sql = @"delete from destinos
                                   where ID_Destino = @cod";
                int n = await bd.ExecuteAsync(cad_sql, new { cod = codigo });
                return n > 0;
            }
        }


    }
}
