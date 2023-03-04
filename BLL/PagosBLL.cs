using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

public class PagosBLL
{

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
        AgregarPagoDetalle(pago);
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
        return _contexto.SaveChanges() > 0;
    }

    public Pagos? Buscar(int pagoId)
    {
        return _contexto.Pagos.Include(o => o.PagosDetalle).Where(o => o.PagoId == pagoId).AsNoTracking().SingleOrDefault();
    }

    public void AgregarPagoDetalle(Pagos pago)
    {

        if (pago.PagosDetalle != null)
        {
            foreach (var item in pago.PagosDetalle)
            {
                var prestamo = _contexto.Prestamos.Find(item.PrestamoId);
                if (prestamo != null)
                {
                    prestamo.Balance = prestamo.Balance - item.ValorPagado;
                    _contexto.Entry(prestamo).State = EntityState.Modified;
                    _contexto.SaveChanges();
                }
            }
            var persona = _contexto.Personas.Find(pago.PersonaId);
            if (persona != null)
            {
                persona.Balance = persona.Balance - pago.Monto;
                _contexto.Entry(persona).State = EntityState.Modified;
                _contexto.SaveChanges();
            }
        }
    }

    public List<Pagos> GetList(Expression<Func<Pagos, bool>> criterio)
    {
        return _contexto.Pagos.AsNoTracking().Where(criterio).ToList();
    }

}