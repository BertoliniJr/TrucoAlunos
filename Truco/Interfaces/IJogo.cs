using Truco.Enumeradores;

namespace Truco.Interfaces
{
    public interface IJogo
    {
        EnumTipoJogo tipoJogo { get; set; }
        object infoJogo { get; set; }
    }
}
