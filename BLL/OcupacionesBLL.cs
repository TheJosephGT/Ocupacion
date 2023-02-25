using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;



    public class OcupacionesBLL
    {
        private Contexto _contexto;

        public OcupacionesBLL(Contexto contexto)
        {
            _contexto = contexto;
        }

        public bool Existe(int ocupacionId)
        {
            return _contexto.Ocupaciones.Any(o => o.OcupacionID == ocupacionId);
        }

        private bool Insertar(Ocupaciones ocupacion)
        {
            _contexto.Ocupaciones.Add(ocupacion);
            return _contexto.SaveChanges() > 0;
        }

        private bool Modificar(Ocupaciones ocupacion)
        {
            var ocupacionEncontrada = _contexto.Ocupaciones.Find(ocupacion.OcupacionID);

            if(ocupacionEncontrada != null){
                _contexto.Entry(ocupacion).CurrentValues.SetValues(ocupacion);
                return _contexto.SaveChanges() > 0;
            }

            return false;
        }

        public bool Guardar(Ocupaciones ocupacion)
        {
            if (!Existe(ocupacion.OcupacionID))
                return this.Insertar(ocupacion);
            else
                return this.Modificar(ocupacion);
        }

        public bool Eliminar(int ocupacionId)
        {
            var ocupacionEncontrada = _contexto.Ocupaciones.Where(o => o.OcupacionID == ocupacionId).SingleOrDefault();
            if(ocupacionEncontrada != null){
                _contexto.Entry(ocupacionEncontrada).State = EntityState.Deleted;
                return  _contexto.SaveChanges() > 0;
            }

            return false;
        }

        public Ocupaciones? Buscar(int ocupacionId)
        {
            return _contexto.Ocupaciones.Where(o => o.OcupacionID == ocupacionId).AsNoTracking().SingleOrDefault();
        }

        public List<Ocupaciones> GetList(Expression<Func<Ocupaciones, bool>> criterio)
        {
            return _contexto.Ocupaciones.AsNoTracking().Where(criterio).ToList();
        }
    }