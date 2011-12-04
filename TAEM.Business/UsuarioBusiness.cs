using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TAEM.Domain;
using TAEM.Business.Tools;

namespace TAEM.Business
{
    public class UsuarioBusiness
    {
        public IList<Usuario> ListUsuarios()
        {
            var pm = new PersistenceManager();
            return pm.ListAll<Usuario>();
        }

        public IList<UsuarioLugar> ListUsuariosLugares()
        {
            var pm = new PersistenceManager();
            return pm.ListAll<UsuarioLugar>();
        }
    }
}
