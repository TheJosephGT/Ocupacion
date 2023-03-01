using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

public class PagosBLL{

private Contexto _contexto;

        public PagosBLL(Contexto contexto)
        {
            _contexto = contexto;
        }

        public bool Existe(int pagoId)
        {
            return _contexto.Pagos.Any(o => o.PagoId == pagoId);
        }

        private bool Insertar(Pagos pago)
        {
            _contexto.Pagos.Add(pago);
            return _contexto.SaveChanges() > 0;
        }

        private bool Modificar(Pagos pago)
        {
            _contexto.Entry(pago).State = EntityState.Modified;
            return _contexto.SaveChanges() > 0;
        }

        public bool Guardar(Pagos pago)
        {
            if (!Existe(pago.PagoId))
                return this.Insertar(pago);
            else
                return this.Modificar(pago);
        }

        public bool Eliminar(Pagos pago)
        {
            _contexto.Entry(pago).State = EntityState.Deleted;
            return  _contexto.SaveChanges() > 0;
        }

        public Pagos? Buscar(int pagoId)
        {
            return _contexto.Pagos.Include(o => o.PagosDetalle).Where(o => o.PagoId == pagoId).AsNoTracking().SingleOrDefault();
        }

        public List<Pagos> GetList(Expression<Func<Pagos, bool>> criterio)
        {
            return _contexto.Pagos.AsNoTracking().Where(criterio).ToList();
        }

}