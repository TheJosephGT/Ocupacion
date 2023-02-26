using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

public class PagosBLL{

private Contexto _contexto;

        public PagosBLL(Contexto contexto)
        {
            _contexto = contexto;
        }

        public bool Existe(int pagosId)
        {
            return _contexto.Pagos.Any(o => o.PagoId == pagosId);
        }

        private bool Insertar(Pagos pagos)
        {
            _contexto.Pagos.Add(pagos);
            return _contexto.SaveChanges() > 0;
        }

        private bool Modificar(Pagos pagos)
        {
            var pagosEncontrada = _contexto.Pagos.Find(pagos.PagoId);

            if(pagosEncontrada != null){
                _contexto.Entry(pagos).CurrentValues.SetValues(pagos);
                return _contexto.SaveChanges() > 0;
            }

            return false;
        }

        public bool Guardar(Pagos pagos)
        {
            if (!Existe(pagos.PagoId))
                return this.Insertar(pagos);
            else
                return this.Modificar(pagos);
        }

        public bool Eliminar(int pagosId)
        {
            var pagoEncontrada = _contexto.Pagos.Where(o => o.PagoId == pagosId).SingleOrDefault();
            if(pagoEncontrada != null){
                _contexto.Entry(pagoEncontrada).State = EntityState.Deleted;
                return  _contexto.SaveChanges() > 0;
            }

            return false;
        }

        public Pagos? Buscar(int pagosId)
        {
            return _contexto.Pagos.Where(o => o.PagoId == pagosId).AsNoTracking().SingleOrDefault();
        }

        public List<Pagos> GetList(Expression<Func<Pagos, bool>> criterio)
        {
            return _contexto.Pagos.AsNoTracking().Where(criterio).ToList();
        }

}