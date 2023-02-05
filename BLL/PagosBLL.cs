using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

public class PagosBLL{

    private Contexto _contexto;

    public PagosBLL(Contexto contexto)
    {
        _contexto = contexto;
    }

    public bool Existe(int PagoId)
    {
        return _contexto.Pagos.Any(o => o.PagoId == PagoId);
    }

    private bool Insertar(Pagos pagos)
    {
        _contexto.Pagos.Add(pagos);
        return _contexto.SaveChanges() > 0;
    }

    private bool Modificar(Pagos pagos)
    {
        _contexto.Entry(pagos).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        return _contexto.SaveChanges() > 0;
    }

    public bool Guardar(Pagos pagos)
    {
        if (!Existe(pagos.PagoId))
            return this.Insertar(pagos);
        else
            return this.Modificar(pagos);
    }

    private bool Eliminar(Pagos pagos)
    {
        _contexto.Entry(pagos).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
        return _contexto.SaveChanges() > 0;
    }

    public Pagos? Buscar(int PagoId)
    {
        return _contexto.Pagos.Where(o => o.PagoId == PagoId).AsNoTracking().SingleOrDefault();
    }

    public List<Pagos> GetList()
    {
        return _contexto.Pagos.ToList();
    }

}