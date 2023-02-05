using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

public class PagosDetalleBLL{

    private Contexto _contexto;

    public PagosDetalleBLL(Contexto contexto)
    {
        _contexto = contexto;
    }

    public bool Existe(int Id)
    {
        return _contexto.PagosDetalles.Any(o => o.PagoId == Id);
    }

    private bool Insertar(PagosDetalle pagosDetalle)
    {
        _contexto.PagosDetalles.Add(pagosDetalle);
        return _contexto.SaveChanges() > 0;
    }

    private bool Modificar(PagosDetalle pagosDetalle)
    {
        _contexto.Entry(pagosDetalle).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        return _contexto.SaveChanges() > 0;
    }

    public bool Guardar(PagosDetalle pagosDetalle)
    {
        if (!Existe(pagosDetalle.Id))
            return this.Insertar(pagosDetalle);
        else
            return this.Modificar(pagosDetalle);
    }

    private bool Eliminar(PagosDetalle pagosDetalle)
    {
        _contexto.Entry(pagosDetalle).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
        return _contexto.SaveChanges() > 0;
    }

    public PagosDetalle? Buscar(int Id)
    {
        return _contexto.PagosDetalles.Where(o => o.Id == Id).AsNoTracking().SingleOrDefault();
    }

    public List<PagosDetalle> GetList()
    {
        return _contexto.PagosDetalles.ToList();
    }

}