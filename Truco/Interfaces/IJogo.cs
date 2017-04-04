using Truco.Enumeradores;

namespace Truco.Interfaces
{
    interface IJogo
    {
        EnumTipoJogo GetTipoJogo();
        object GetInfoJogo();
    }
}
