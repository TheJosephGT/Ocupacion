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
            return _contexto.ocupaciones.Any(o => o.OcupacionID == ocupacionId);
        }

        private bool Insertar(Ocupaciones ocupacion)
        {
            _contexto.ocupaciones.Add(ocupacion);
            return _contexto.SaveChanges() > 0;
        }

        private bool Modificar(Ocupaciones ocupacion)
        {
            _contexto.Entry(ocupacion).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return _contexto.SaveChanges() > 0;
        }

        public bool Guardar(Ocupaciones ocupacion)
        {
            if (!Existe(ocupacion.OcupacionID))
                return this.Insertar(ocupacion);
            else
                return this.Modificar(ocupacion);
        }

        private bool Eliminar(Ocupaciones ocupacion)
        {
            _contexto.Entry(ocupacion).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            return  _contexto.SaveChanges() > 0;
        }

        public Ocupaciones? Buscar(int ocupacionId)
        {
            return _contexto.ocupaciones.Where(o => o.OcupacionID == ocupacionId).AsNoTracking().SingleOrDefault();
        }

        public List<Ocupaciones> GetList()
        {
            return _contexto.ocupaciones.ToList();
        }
    }