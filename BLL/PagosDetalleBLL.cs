using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

public class PagosDetalleBLL{

    private Contexto _contexto;

        public PagosDetalleBLL(Contexto contexto)
        {
            _contexto = contexto;
        }

        public bool Existe(int id)
        {
            return _contexto.PagosDetalle.Any(o => o.Id == id);
        }

        private bool Insertar(PagosDetalle pagoDetalle)
        {
            _contexto.PagosDetalle.Add(pagoDetalle);
            return _contexto.SaveChanges() > 0;
        }

        private bool Modificar(PagosDetalle pagoDetalle)
        {
            var pagoDetalleEncontrada = _contexto.PagosDetalle.Find(pagoDetalle.Id);

            if(pagoDetalleEncontrada != null){
                _contexto.Entry(pagoDetalle).CurrentValues.SetValues(pagoDetalle);
                return _contexto.SaveChanges() > 0;
            }

            return false;
        }

        public bool Guardar(PagosDetalle pagosDetalle)
        {
            if (!Existe(pagosDetalle.Id))
                return this.Insertar(pagosDetalle);
            else
                return this.Modificar(pagosDetalle);
        }

        public bool Eliminar(int id)
        {
            var pagoDetalleEncontrada = _contexto.PagosDetalle.Where(o => o.Id == id).SingleOrDefault();
            if(pagoDetalleEncontrada != null){
                _contexto.Entry(pagoDetalleEncontrada).State = EntityState.Deleted;
                return  _contexto.SaveChanges() > 0;
            }

            return false;
        }

        public PagosDetalle? Buscar(int id)
        {
            return _contexto.PagosDetalle.Where(o => o.Id == id).AsNoTracking().SingleOrDefault();
        }

        public List<PagosDetalle> GetList(Expression<Func<PagosDetalle, bool>> criterio)
        {
            return _contexto.PagosDetalle.AsNoTracking().Where(criterio).ToList();
        }
}